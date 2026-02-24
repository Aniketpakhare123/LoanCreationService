using System.Net.Http.Json;

namespace LoanTable.Application.DTO
{
    public class OriginationClient
    {
        private readonly HttpClient client;

        public OriginationClient(HttpClient http)
        {
            this.client = http;
        }

        public async Task<LoanDTO> GetDeal(int id)
        {
            var response = await client.GetFromJsonAsync<OriginationApiResponse<LoanDTO>>($"/api/LoanDeals/{id}");
            return response?.Data;
        }

        public async Task<LoantypeDTO> GetLoanTypes(int id)
        {
            var response = await client.GetFromJsonAsync<OriginationApiResponse<LoantypeDTO>>($"/api/LoanTypes/{id}");
            return response?.Data;
        }
    }

    public class OriginationApiResponse<T>
    {
        public bool Success { get; set; }
        public T Data { get; set; }
        public string Message { get; set; }
    }
}
