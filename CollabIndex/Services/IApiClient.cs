
namespace CollabIndex.Services
{
    public interface IApiClient
    {
        Task<T?> GetAsync<T>(string url);
        Task<bool> PostAsync<T>(string url, T data);
    }
}


