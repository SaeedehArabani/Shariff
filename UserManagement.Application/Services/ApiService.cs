using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace UserManagement.Application.Services
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GetProtectedDataAsync(string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = 
                new AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.GetAsync("protected-endpoint");

            if (response.IsSuccessStatusCode)
                return await response.Content.ReadAsStringAsync();

            return "Unauthorized!";
        }
    }
}
