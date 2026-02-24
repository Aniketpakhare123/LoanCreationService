using System.Net.Http.Json;

namespace LoanTable.Application.DTO
{
    public class SanctionClient
    {
        private readonly HttpClient client;

        public SanctionClient(HttpClient http)
        {
            this.client = http;
        }

        public async Task<GetSanctionDTO> GetSanctionDetails(int id)
        {
            var response = await client.GetFromJsonAsync<SanctionApiResponse<GetSanctionDTO>>($"/api/Sanction/{id}");
            return response?.Data;
        }
    }

    public class SanctionApiResponse<T>
    {
        public bool Success { get; set; }
        public T Data { get; set; }
        public string Message { get; set; }
    }
}
