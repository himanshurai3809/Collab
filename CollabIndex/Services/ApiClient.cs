using System.Net.Http.Json;

namespace CollabIndex.Services
{
    public class ApiClient : IApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<ApiClient> _logger;

        public ApiClient(HttpClient httpClient, ILogger<ApiClient> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<T?> GetAsync<T>(string url)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<T>(url);
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "GET request failed for {Url}", url);
                return default;
            }
        }

        public async Task<bool> PostAsync<T>(string url, T data)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync(url, data);
                if (!response.IsSuccessStatusCode)
                {
                    _logger.LogWarning("POST request failed for {Url} - Status: {StatusCode}", url, response.StatusCode);
                    return false;
                }
                return true;
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "POST request failed for {Url}", url);
                return false;
            }
        }
    }
}
