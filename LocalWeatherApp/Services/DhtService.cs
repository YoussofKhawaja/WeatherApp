using LocalWeatherApp.Interfaces;
using LocalWeatherApp.Models;
using Newtonsoft.Json;
using System.Net.Http;

namespace LocalWeatherApp.Services
{
    public class DhtService
    {
        private readonly IHttpClient _httpClient;
        private readonly IConfigurationWrapper _configuration;

        public DhtService(IHttpClient httpClient, IConfigurationWrapper configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task<List<DhtData>> GetDHTDataAsync()
        {
            string baseUrl = _configuration?.GetValue("ApiBaseUrl") ?? "";
            string apiEndpoint = _configuration?.GetValue("ApiEndpoint") ?? "";

            string apiUrl = $"{baseUrl}/{apiEndpoint}";

            try
            {
                var response = await _httpClient.GetAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    var jsonDeserializeObject = JsonConvert.DeserializeObject<List<DhtData>>(data);
                    return jsonDeserializeObject ?? new List<DhtData>();
                }
            }
            catch (Exception ex)
            {
               Console.WriteLine(ex.Message);
            }
            return new List<DhtData>();
        }
    }
}
