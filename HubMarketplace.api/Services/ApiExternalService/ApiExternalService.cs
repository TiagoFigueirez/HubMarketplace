using HubMarketplace.api.Services.ApiExternalService.Config;
using HubMarketplace.api.Services.ApiExternalService.Interface;
using System.Text;
using System.Text.Json;

namespace HubMarketplace.api.Services.ApiExternalService
{
    public class ApiExternalService : IApiExternalService
    {
        private readonly IHttpClientFactory _httpClient;
        private static readonly JsonSerializerOptions JsonOptions = new()
        {
            PropertyNameCaseInsensitive = true
        };

        public ApiExternalService(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ApiExternalResult<T>> GetAsync<T>(string url, Dictionary<string, string>? headers = null)
        {
            using var request = new HttpRequestMessage(HttpMethod.Get, url);
            ApliccationHeaders(request, headers);

            return await EnviarAsync<T>(request);
        }

        public async Task<ApiExternalResult<TResponse>> PostAsync<TRequest, TResponse>
            (string url, TRequest Body, Dictionary<string, string>? headers = null)
        {
            using var request = new HttpRequestMessage(HttpMethod.Post, url)
            {
                Content = BuildContent(Body)
            };

            ApliccationHeaders(request, headers);

            return await EnviarAsync<TResponse>(request);
        }

        private async Task<ApiExternalResult<T>> EnviarAsync<T>(HttpRequestMessage request)
        {
            try
            {
                var client = _httpClient.CreateClient("ApiExternal");

                using var response = await client.SendAsync(request);
                var content = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                    return ApiExternalResult<T>.Falha(content, (int)response.StatusCode);

                var data = JsonSerializer.Deserialize<T>(content, JsonOptions);

                return ApiExternalResult<T>.Success(data!, (int)response.StatusCode);
            }
            catch (Exception ex)
            {
                return ApiExternalResult<T>.Falha(ex.Message, 0);
            }
        }

        private static StringContent BuildContent<T>(T body)
        {
            var json = JsonSerializer.Serialize(body, JsonOptions);
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
