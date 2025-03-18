namespace CollabIndexUI.ApiServices
{
    using System.Net.Http;
    using System.Net.Http.Json;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using CollabIndexUI.Models;

    public class ApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // Get all projects
        public async Task<List<ListedProject>> GetProjectsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<ListedProject>>("api/listedprojects");
        }

        public async Task<bool> CreateProjectAsync(ListedProject listing)
        {
            var response = await _httpClient.PostAsJsonAsync("api/listedprojects", listing);
            return response.IsSuccessStatusCode;
        }
    }
}
