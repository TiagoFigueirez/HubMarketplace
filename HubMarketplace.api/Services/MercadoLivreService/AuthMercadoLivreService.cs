using HubMarketplace.api.Model;
using HubMarketplace.api.Options;
using HubMarketplace.api.Services.ApiExternalService.Interface;
using HubMarketplace.api.Services.MercadoLivreService.Interface;

namespace HubMarketplace.api.Services.MercadoLivreService
{
    public class AuthMercadoLivreService : IAuthMercadoLivreService
    {
        //essa classe faz a autenticação com o mercado livre

        private readonly IApiExternalService _apiExternalService;
        private readonly MercadoLivreOptions _configuration;

        public AuthMercadoLivreService(IApiExternalService? apiExternalService)
        {
            _apiExternalService = apiExternalService;
        }

        //faz a autenticação inicial e pega o token do mercado livre
        public async Task<TokenMercadoLivreReponse> ExchangForTokenAsync(string code)
        {
            var paramiters = new MercadoLivreConfig()
            {
                GrantType = "authorization_code",
                ClientId = _configuration.ClientId,
                Code = code,
                RedirectUri = _configuration.RedirectUri,
            };

            var urlToken = _configuration.ApiUrl + "/oauth/token";

            var cliente = await _apiExternalService.PostAsync<MercadoLivreConfig, TokenMercadoLivreReponse>(urlToken, paramiters);
            throw new NotImplementedException();
        }

        //acessa uma conta do mercado livre via browser
        public string GetAutorizathonUrl()
        {
            return $"https://auth.mercadolivre.com.br/authorization" +
                   $"?response_type=code" +
                   $"&client_id={_configuration.ClientId}" +
                   $"&redirect_uri={Uri.EscapeDataString(_configuration.RedirectUri)}";                          
        }

        public Task<TokenMercadoLivreReponse> RefeshToken(string tokenRefresh)
        {
            throw new NotImplementedException();
        }
    }
}
