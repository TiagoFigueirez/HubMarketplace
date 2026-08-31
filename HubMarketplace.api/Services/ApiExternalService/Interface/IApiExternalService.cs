using HubMarketplace.api.Services.ApiExternalService.Config;

namespace HubMarketplace.api.Services.ApiExternalService.Interface
{
    public interface IApiExternalService
    {
        Task<ApiExternalResult<T>> GetAsync<T>(string url, Dictionary<string, string>? headers = null);
    }
}
