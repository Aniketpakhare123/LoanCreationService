using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanTable.Application.DTO
{
  public class BranchDTO
  {
    public int id { get; set; }

    public string name { get; set; }

    public string code { get; set; }

    public string address { get; set; }

    public int cityId { get; set; }

    public int areaId { get; set; }

    public string branchManager { get; set; }

    public int contact { get; set; }

    public string email { get; set; }

    public bool isActive { get; set; }
  }
}
