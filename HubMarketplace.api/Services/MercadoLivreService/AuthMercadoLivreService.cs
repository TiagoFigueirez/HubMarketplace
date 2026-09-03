using HubMarketplace.api.Model;
using HubMarketplace.api.Services.ApiExternalService.Interface;
using HubMarketplace.api.Services.MercadoLivreService.Interface;

namespace HubMarketplace.api.Services.MercadoLivreService
{
    public class AuthMercadoLivreService : IAuthMercadoLivreService
    {
        private readonly IApiExternalService? _apiExternalService;
        private readonly IConfiguration _configuration;

        public AuthMercadoLivreService(IApiExternalService? apiExternalService)
        {
            _apiExternalService = apiExternalService;
        }

        public Task<MercadoLivreConfig> ExchangForTokenAsync(string code)
        {
            var cliente = _apiExternalService.PostAsync();
            throw new NotImplementedException();
        }
    }
}
