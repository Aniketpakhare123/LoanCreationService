using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanTable.Application.DTO
{
  public class LoantypeDTO
  {
    public int id { get; set; }

    public string name { get; set; }

    public decimal? maxInterestRate { get; set; }

    public decimal? minInterestRate { get; set; }
    public int mintenureMonths { get; set; }

    public int maxtenureMonths { get; set; }

    public decimal maxAmount { get; set; }

    public decimal minAmount { get; set; }

    public Boolean isActive { get; set; }
  }
}
