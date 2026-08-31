using System.Text.Json.Serialization;

namespace HubMarketplace.api.Model
{
    public class TokenMercadoLivreReponse
    {
        [JsonPropertyName("access_token")]
        public string? AcessToken { get; set; }
        [JsonPropertyName("token_type")]
        public string? TokenType { get; set; }
        [JsonPropertyName("expires_in")]
        public int? ExpiresIn { get; set; }
        [JsonPropertyName("scope")]
        public string? Scope { get; set; }
        [JsonPropertyName("user_id")]
        public string? UsuarioId { get; set; }
        [JsonPropertyName("refresh_token")]
        public string? RefreshToken { get; set; }
    }
}
