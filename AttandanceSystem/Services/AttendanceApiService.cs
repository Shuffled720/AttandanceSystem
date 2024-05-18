using AttandanceSystem.Models.ApiModels;

using System.Net.Http.Json;

namespace AttandanceSystem.Services
{
    internal class AttendanceApiService
    {
        private readonly HttpClient _httpClient;
        public AttendanceApiService()
        {
            _httpClient = new HttpClient { BaseAddress = new Uri(Constants.AttendanceUrl) };
            _httpClient.Timeout = TimeSpan.FromSeconds(7);
        }
        public async Task<AttendanceApiResponse?> PostAttendanceInfo(string employeeId, string status)
        {
            try
            {
                var content = JsonContent.Create(new { id = employeeId, status });

                if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
                {
                    return null;
                }
                return await _httpClient.PostAsync("", content).Result.Content.ReadFromJsonAsync<AttendanceApiResponse>();
            }
            catch (Exception)
            {
                Console.WriteLine("Error");
                return null;
            }
        }
    }
}
