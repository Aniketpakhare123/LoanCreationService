using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanTable.Application.DTO
{
  public class LoanDTO
  {
    public int LoanId { get; set; }
    public int DealId { get; set; }
    public int SanctionId { get; set; }
    public int DisbursementId { get; set; }
    public int CustomerId { get; set; }
    public int ScorecardId { get; set; }
    public int LoanTypeId { get; set; }
    public int? BranchId { get; set; }
    public string? SanctionNo { get; set; }
    public decimal SanctionedAmount { get; set; }
    public decimal InterestRate { get; set; }
    public int TenureMonths { get; set; }
    public decimal EmiAmount { get; set; }
    public decimal DisbursedAmount { get; set; }
    public DateTime DisbursementDate { get; set; }
    public string? TransactionReference { get; set; }

    public DateTime dueDate { get; set; }
    public int? scheduleId{ get; set; }
    public int EmiDay { get; set; }
    public DateTime MaturityDate { get; set; }
    public DateTime FirstEmiDate { get; set; }
    public decimal OutstandingPrincipal { get; set; }
    public decimal OutstandingInterest { get; set; }
    public decimal TotalOutstanding { get; set; }
    public int RemainingTenure { get; set; }
    public int Dpd { get; set; }
    public string AccountStatus { get; set; }
    public DateTime? LastPaymentDate { get; set; }
    public DateTime? NextEmiDate { get; set; }
    public DateTime CreatedAt { get; set; }

    public DateTime? ModifiedAt { get; set; }

    public string CreatedBy { get; set; }

    public decimal eligibleAmount { get; set; }
    public string deletedBy { get; set; }

  }

  public class CreateLoanRequest
  {
    [Required]
    public int DealId { get; set; }
    [Required]
    public int SanctionId { get; set; }
    [Required]
    public int DisbursementId { get; set; }
    [Required]
    public int CustomerId { get; set; }
    [Required]
    public int ScorecardId { get; set; }
    [Required]
    public int LoanTypeId { get; set; }

    public decimal Amount { get; set; }
    public int BranchId { get; set; }
  }

  public class EmiScheduleResponse
  {
    public int ScheduleId { get; set; }
    public int LoanId { get; set; }
    public int InstallmentNumber { get; set; }
    public DateTime DueDate { get; set; }
    public decimal EmiAmount { get; set; }
    public decimal PrincipalComponent { get; set; }
    public decimal InterestComponent { get; set; }
    public decimal OpeningBalance { get; set; }
    public decimal ClosingBalance { get; set; }
    public string PaymentStatus { get; set; }
    public decimal PaidAmount { get; set; }
    public DateTime? PaidDate { get; set; }
    public decimal PendingAmount { get; set; }
    public decimal PenaltyAmount { get; set; }
    public decimal TotalDue { get; set; }
    public int DaysOverdue { get; set; }
    public decimal RemainingBalance { get; set; }
  }

  public class OutstandingResponse
  {
    public int LoanId { get; set; }
    public decimal OutstandingPrincipal { get; set; }
    public decimal OutstandingInterest { get; set; }
    public decimal TotalPenalties { get; set; }
    public decimal TotalOutstanding { get; set; }
  }

  public class BalanceResponse
  {
    public int LoanId { get; set; }
    public decimal SanctionedAmount { get; set; }
    public decimal OutstandingPrincipal { get; set; }
    public decimal OutstandingInterest { get; set; }
    public decimal TotalPaid { get; set; }
    public int RemainingTenure { get; set; }
    public int Dpd { get; set; }
    public string AccountStatus { get; set; }
  }
  public class UpdateLoanStatusRequest
  {
    [Required]
    public string Status { get; set; }
  }





}
