namespace HubMarketplace.api.Options
{
    public class MercadoLivreOptions
    {
        public const string SectionName = "MercadoLivreCreddentials";

        public string ClientId { get; set; } = string.Empty;
        public string ClientSecret { get; set; } = string.Empty;
        public string RedicrecUri { get; set; } = string.Empty;
    }
}
