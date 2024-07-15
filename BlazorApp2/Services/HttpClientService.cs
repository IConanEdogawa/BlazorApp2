using System.Net.Http.Json;
using TimerService.API.Models;

namespace BlazorApp2.Services
{
    public class HttpClientService
    {
        private readonly HttpClient _httpClient;

        public HttpClientService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ResponseModel> PostTimerDataAsync(TimerList timerData)
        {
            var response = await _httpClient.PostAsJsonAsync("https://localhost:7261/api/timer", timerData);
            return await response.Content.ReadFromJsonAsync<ResponseModel>();
        }

        public async Task<List<TimerList>> GetAllTimersAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<TimerList>>("https://localhost:7261/api/timer");
        }
    }
}
