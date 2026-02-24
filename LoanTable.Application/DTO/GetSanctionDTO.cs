using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanTable.Application.DTO
{
  public class  GetSanctionDTO
  {
    public int id { get; set; }

    public int dealid { get; set; }

    public string sanctionNo { get; set; }

    public decimal loanAmount { get; set; }

    public decimal interestRate { get; set; }

    public decimal emiamount { get; set; }

    public int tenuremonths { get; set; }

    public DateTime createdAt { get; set; }

    public List<RepaymentDTO>? RepaymentSchedule { get; set; }

    public DateTime? AcceptedDate { get; set;} 

    public bool? customerAccepted { get; set; }

    public string? pdfPath { get; set; }

    public string currentStatus { get; set; }
  }
}
