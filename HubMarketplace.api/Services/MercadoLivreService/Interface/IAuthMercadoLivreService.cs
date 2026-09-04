using HubMarketplace.api.Model;

namespace HubMarketplace.api.Services.MercadoLivreService.Interface
{
    public interface IAuthMercadoLivreService
    {
        string GetAutorizathonUrl();
        Task<MercadoLivreConfig> ExchangForTokenAsync(string code);
        Task<MercadoLivreConfig> RefeshToken(string tokenRefresh);
    }
}
