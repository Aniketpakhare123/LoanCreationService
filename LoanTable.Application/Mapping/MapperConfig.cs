using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using LoanTable.Application.DTO;
using LoanTable.Domain.Model;

namespace LoanTable.Application.Mapping
{
  public class MapperConfig : Profile
  {
    public MapperConfig() {
      CreateMap<LoanDTO, LoanTables>().ReverseMap();
      CreateMap<LoanTables, LoanDTO>().ReverseMap();
    } 
  }
}
