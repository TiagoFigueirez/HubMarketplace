using HubMarketplace.api.Services.ApiExternalService.Config;
using HubMarketplace.api.Services.ApiExternalService.Interface;
using System.Text;
using System.Text.Json;

namespace HubMarketplace.api.Services.ApiExternalService
{
    public class ApiExternalService : IApiExternalService
    {
        private readonly HttpClient _httpClient;
        private static readonly JsonSerializerOptions JsonOptions = new()
        {
            PropertyNameCaseInsensitive = true
        };

        public ApiExternalService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ApiExternalResult<T>> GetAsync<T>(string url, Dictionary<string, string>? headers = null)
        {
            using var request = new HttpRequestMessage(HttpMethod.Get, url);
            ApliccationHeaders(request, headers);

            return await EnviarAsync<T>(request);
        }

        private async Task<ApiExternalResult<T>> EnviarAsync<T>(HttpRequestMessage request)
        {
            try
            {
                using var response = await _httpClient.SendAsync(request);
                var content = await response.Content.ReadAsStringAsync();

                if(!response.IsSuccessStatusCode)
                    return ApiExternalResult<T>.Falha(content, (int)response.StatusCode);

                var data = JsonSerializer.Deserialize<T>(content, JsonOptions);

                return ApiExternalResult<T>.Success(data!, (int)response.StatusCode);
            }
            catch (Exception ex)
            {
                return ApiExternalResult<T>.Falha(ex.Message, 0);
            }
        }

        public Task<ApiExternalResult<T>> PostAsync<T>(string url, Dictionary<string, string>? headers = null)
        {
            throw new NotImplementedException();
        }
        private static StringContent BuildContent<T>(T corpo)
        {
            var json = JsonSerializer.Serialize(corpo, JsonOptions);
            return new StringContent(json, Encoding.UTF8, "application/json");
        }

        private static void ApliccationHeaders(HttpRequestMessage request, Dictionary<string, string>? headers)
        {
            if (headers is null)
                return;

            foreach(var (chave, valor) in headers)
                request.Headers.TryAddWithoutValidation(chave, valor);
        }
    }
}
