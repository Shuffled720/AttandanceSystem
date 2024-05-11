using AttandanceSystem.Models.ApiModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace AttandanceSystem.Services
{
    internal class AttendanceApiService
    {
        private readonly HttpClient _httpClient;
        public AttendanceApiService()
        {
            _httpClient = new HttpClient { BaseAddress = new Uri(Constants.AttendanceUrl) };
        }

        public async Task<AttendanceApiResponse?> PostAttendanceInfo(int employeeId,string status)
        {
            try
            {
                var content = JsonContent.Create(new { id = employeeId, status = status });

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
