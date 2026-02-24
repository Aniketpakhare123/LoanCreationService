using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanTable.Application.DTO
{
  public class RepaymentDTO
  {
    public int EmiNo { get; set; }

    public DateTime DueDate { get; set; }

    public decimal PrincipalAmount { get; set; }

    public decimal InterestAmount { get; set; }

    public decimal TotalEmi { get; set; }

    public decimal BalancePrincipal { get; set; }

    public string Status { get; set; } = "Pending";
    // Pending / Paid / Overdue
  }
}
