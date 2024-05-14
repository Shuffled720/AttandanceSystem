using AttandanceSystem.Models.ApiModels;

using System.Net.Http.Json;

namespace AttandanceSystem.Services
{
    internal class LoginApiService
    {
        private readonly HttpClient _httpClient;
        public LoginApiService()
        {
            _httpClient = new HttpClient { BaseAddress = new Uri(Constants.LoginUrl) };
            _httpClient.Timeout = TimeSpan.FromSeconds(7);
        }
        public async Task<LoginApiResponse?> LoginUserInfo(string username, string password)
        {
            try
            {
                var content = JsonContent.Create(new { name = username, password });

                if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
                {
                    return null;
                }
                return await _httpClient.PostAsync("", content).Result.Content.ReadFromJsonAsync<LoginApiResponse>();
            }
            catch (Exception)
            {
                Console.WriteLine("Error");
                return null;
            }
        }
    }
}
