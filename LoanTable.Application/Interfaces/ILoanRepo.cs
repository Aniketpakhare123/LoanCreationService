using LoanTable.Application.DTO;
using LoanTable.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanTable.Application.Interfaces
{
  public interface ILoanRepo
  {

    Task<LoanDTO> CreateLoanAsync(CreateLoanRequest dto);
    Task<LoanDTO?> GetLoanByIdAsync(int loanId);
    Task<LoanDTO> GetLoansByCustomerAsync(int customerId);
    //Task<List<EmiScheduleResponse>> GetEmiScheduleAsync(int id);
    Task<OutstandingResponse> GetOutstandingAsync(int loanId);
    Task<BalanceResponse> GetBalanceAsync(int loanId);
    Task<bool> UpdateStatusAsync(int loanId, string status);
    Task<List<LoanDTO>> GetActiveLoansAsync();
  }
}
