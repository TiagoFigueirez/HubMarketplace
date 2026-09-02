using HubMarketplace.api.Services.ApiExternalService.Config;

namespace HubMarketplace.api.Services.ApiExternalService.Interface
{
    public interface IApiExternalService
    {
        Task<ApiExternalResult<TResponse>> GetAsync<TResponse>(string url, Dictionary<string, string>? headers = null);
        Task<ApiExternalResult<TResponse>> PostAsync<TRequest, TResponse>(string url, TRequest Body,Dictionary<string, string>? headers = null);
    }
}
