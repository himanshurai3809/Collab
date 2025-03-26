namespace CollabIndex.Services.Wallet
{
    public class WalletAuthService
    {
        private readonly IApiClient _apiClient;

        public WalletAuthService(IApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<bool> VerifyWalletAuthAsync(string publicKey, string signature, string challenge)
        {
            var payload = new { PublicKey = publicKey, Signature = signature, Challenge = challenge };
            return await _apiClient.PostAsync("api/auth/verify", payload);
        }
    }
}
