namespace HubMarketplace.api.Options
{
    public class MercadoLivreOptions
    {
        public const string SectionName = "MercadoLivreCreddentials";

        public string ClientId { get; set; } = string.Empty;
        public string ClientSecret { get; set; } = string.Empty;
        public string RedirectUri { get; set; } = string.Empty;
        public string ApiUrl { get; set; } = string.Empty;
    }
}
