using HubMarketplace.api.Model;

namespace HubMarketplace.api.Services.MercadoLivreService.Interface
{
    public interface IAuthMercadoLivreService
    {
        string GetAutorizathonUrl();
        Task<TokenMercadoLivreReponse> ExchangForTokenAsync(string code);
        Task<TokenMercadoLivreReponse> RefeshToken(string tokenRefresh);
    }
}
