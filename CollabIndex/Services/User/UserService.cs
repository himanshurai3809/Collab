using CollabIndex.Schema.User;

namespace CollabIndex.Services.User
{
    public class UserService
    {
        private readonly IApiClient _apiClient;

        public UserService(IApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<UserProfile?> GetUserProfileAsync()
        {
            return await _apiClient.GetAsync<UserProfile>("api/user/profile");
        }
    }
}
