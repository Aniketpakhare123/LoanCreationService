using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace LoanTable.Application.DTO
{
  public class GetLoanClient
  {
    private readonly HttpClient client;

    public GetLoanClient(HttpClient http)
    {
       this.client = http;
    }

    public async Task<LoanDTO> GetDeal(int id)
    {
      return await client.GetFromJsonAsync<LoanDTO>($"/api/Deals/{id}");
    }

    public async Task<GetSanctionDTO> GetSanctionDetails(int id)
    {
      return await client.GetFromJsonAsync<GetSanctionDTO>($"/api/Sanctions/{id}");
    }

    public async Task<LoantypeDTO> GetLoanTypes(int id)
    {
      return await client.GetFromJsonAsync<LoantypeDTO>($"/api/loan-types/{id}");
    }


  }
}
