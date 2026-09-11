using System.Text.Json.Serialization;

namespace HubMarketplace.api.Model
{
    public class MercadoLivreConfig
    {
        [JsonPropertyName("grant_type")]
        public string? GrantType { get; set; } = "authorization_code";
        [JsonPropertyName("client_id")]
        public string? ClientId { get; set; }
        [JsonPropertyName("client_secret")]
        public string? ClientSecret { get; set; }
        [JsonPropertyName("code")]
        public string? Code {get; set; }
        [JsonPropertyName("redirect_uri")]
        public string? RedirectUri { get; set; }
    }
}
