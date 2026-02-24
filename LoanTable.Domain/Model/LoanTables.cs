using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanTable.Domain.Model
{
  public class LoanTables
  {
    [Key]
    public int LoanId { get; set; }

    public int dealId { get; set; }

    public int sanctionId { get; set; }

    public int disbursementId { get; set; }

    public int scoreCardId { get; set; }

    public int customerId { get; set; }

    public int loanTypeId { get; set; }

    public int branchId { get; set; }

    //sanction 
    public string sanctionNo { get; set; }

    public decimal sanctionedAmount { get; set; }

     public decimal interestRate { get; set; }

    public int tenureMonths { get; set; }

    public decimal emiAmount { get; set; }

    public int emiDay { get; set; } 

    public decimal DisbursedAmount { get; set; }
    public DateTime DisbursementDate { get; set; }
    public string TransactionReference { get; set; }

    public DateTime maturityDate { get; set; }

   public DateTime FirstEmiDate { get; set; }

   public decimal outstandingPrincipal { get; set; }

   public decimal outstandingInterest { get; set; }

   public decimal totalOutstanding { get; set; }

   public int remainingTenure { get; set; }

   public int dpd { get; set; }

   public string AccountStatus { get; set; } = "active";

   public DateTime? LastPaymentDate { get; set; }
   public DateTime? NextEmiDate { get; set; }

   public DateTime? DeletedAt { get; set; }
   public DateTime CreatedAt { get; set; }
   public DateTime ModifiedAt { get; set; }
   public string CreatedBy { get; set; }
   public string DeletedBy { get; set; }


  }

}
