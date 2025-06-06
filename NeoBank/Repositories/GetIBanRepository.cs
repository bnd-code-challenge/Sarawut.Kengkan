
using Microsoft.AspNetCore.Mvc;
using NeoBank.Configurations;

namespace NeoBank.Repositories
{
    public class GetIBanRepository : IGetIBanRepository
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public GetIBanRepository(IHttpClientFactory httpClientFactory) 
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<string> GetIBAN(string country)
        {
            try
            {
                string IBAN = "";
                var httpClient = _httpClientFactory.CreateClient("Randommer");
                var httpResponseMessage = await httpClient.GetAsync($"Finance/Iban/{country}");

                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    IBAN = await httpResponseMessage.Content.ReadAsStringAsync();
                }

                return await Task.FromResult( IBAN );
            }
            catch (Exception ex)
            {
               throw new Exception($"Failed to Fetch IBAN: {ex.Message}");
            }
        }
    }
}
