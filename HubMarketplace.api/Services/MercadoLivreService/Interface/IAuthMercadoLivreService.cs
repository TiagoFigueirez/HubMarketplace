using HubMarketplace.api.Model;

namespace HubMarketplace.api.Services.MercadoLivreService.Interface
{
    public interface IAuthMercadoLivreService
    {
        Task<MercadoLivreConfig> ExchangForTokenAsync(string code);
    }
}
