using AutoMapper;
using Azure.Core;
using LoanTable.Application;
using LoanTable.Application.DTO;
using LoanTable.Application.Interfaces;
using LoanTable.Domain.Model;
using LoanTable.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
namespace LoanTable.Infrastructure.Repository
{
  public class LoanAccountService : ILoanRepo
  {

    private readonly ApplicationDbContext db;
    IMapper mapper;
    OriginationClient originationClient;
    SanctionClient sanctionClient;

    public LoanAccountService(ApplicationDbContext db, IMapper mapper, OriginationClient originationClient, SanctionClient sanctionClient)
    {
      this.mapper = mapper;
      this.db = db;
      this.originationClient = originationClient;
      this.sanctionClient = sanctionClient;
    }

        public async Task<LoanDTO> CreateLoanAsync(CreateLoanRequest req)
         {

           if (req == null) {
              throw new Exception ("request not found");
           }

            decimal amount = req.Amount;
           var deal = await originationClient.GetDeal(req.DealId);
           var sanction = await sanctionClient.GetSanctionDetails(req.SanctionId);
           var type = await originationClient.GetLoanTypes(req.LoanTypeId);
        
            if (deal.DealId == null) { return null; }
            if(sanction.sanctionId== null) { return null; }
            if(type.id ==null) { return null; }
         //adding validation to validate data coming from Apis
      
        var loan = new LoanTables
        {
          dealId = sanction.dealid,
          sanctionId = sanction.sanctionId,
          sanctionedAmount = sanction.loanAmount,
          sanctionNo = sanction.sanctionNo,
          customerId = deal.custId,
          scoreCardId = deal.scorecardId,
          DisbursedAmount = deal.eligibleAmount,
          DisbursementDate = DateTime.Now,
          tenureMonths = sanction.tenuremonths,
          emiAmount = sanction.emiamount,
          emiDay = 0,
          FirstEmiDate = sanction.createdAt.AddDays(5),
          NextEmiDate = sanction.createdAt.AddMonths(1),
          maturityDate = sanction.createdAt.AddMonths(2),
          branchId = req.BranchId,
          loanTypeId = req.LoanTypeId,
          disbursementId = req.DisbursementId,
          outstandingPrincipal = sanction.loanAmount,
          outstandingInterest = 0,
          totalOutstanding = sanction.loanAmount,
          AccountStatus ="Active",
          remainingTenure = sanction.tenuremonths,
          dpd = 0,
          TransactionReference =  string.Empty,
          CreatedAt = DateTime.Now,
          ModifiedAt = DateTime.Now,
          CreatedBy = "Aniket",
          DeletedBy ="Aniket",
        };

            db.Loans.Add(loan);
            await db.SaveChangesAsync();

            var m = mapper.Map<LoanDTO>(loan);

          return m;
      }


     public async Task<LoanDTO> GetLoanByIdAsync(int id)
     {
        var data = await db.Loans.FindAsync(id);
        if (data == null)
        {
          return null;
        }

       var result= mapper.Map<LoanDTO>(data);
       return result;
     }

    public async Task<LoanDTO> GetLoansByCustomerAsync(int customerId)
    {
      var data = await db.Loans.FirstOrDefaultAsync(x => x.customerId == customerId) ;
      if (data == null)
      {
        return null;
      }

      var result = mapper.Map<LoanDTO>(data);
      return result;

    }

    public async Task<OutstandingResponse> GetOutstandingAsync(int customerId)
    {
      var loan = await db.Loans.FirstOrDefaultAsync(x => x.customerId == customerId);
      if (loan == null)
        return null;

      var data = new OutstandingResponse
      {
        LoanId = loan.LoanId,
        OutstandingInterest = loan.outstandingInterest,
        OutstandingPrincipal = loan.outstandingPrincipal,
        TotalOutstanding = loan.totalOutstanding,
      };

      return data;

    }

    public async Task<BalanceResponse> GetBalanceAsync(int customerId)
    {
      var data = await db.Loans.FirstOrDefaultAsync(x=> x.customerId ==customerId);

      if (data == null)
        return null;

      var balance = new BalanceResponse
      {
        LoanId = data.LoanId,
        SanctionedAmount = data.sanctionedAmount,
        OutstandingPrincipal = data.outstandingPrincipal,
        OutstandingInterest = data.outstandingInterest,
        TotalPaid = 0, // Set this appropriately if you have payment data
        RemainingTenure = data.remainingTenure,
        Dpd = data.dpd,
        AccountStatus = data.AccountStatus
      };

      return balance;
    }

    public async Task<bool> UpdateStatusAsync(int loanId, string status)
    {

      var loan = await db.Loans.FirstOrDefaultAsync(x => x.LoanId == loanId);

      if (loan == null) { return false; }

      loan.AccountStatus = status;

      await db.SaveChangesAsync();

      return true;
    }

    public async Task<List<LoanDTO>> GetActiveLoansAsync()
    {
      var loans = await db.Loans
        .Where(l => l.AccountStatus == "Active")
        .ToListAsync();
      return mapper.Map<List<LoanDTO>>(loans);
    }


  }
}
