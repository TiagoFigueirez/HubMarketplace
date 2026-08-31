namespace HubMarketplace.api.Services.ApiExternalService.Config
{
    public class ApiExternalResult<T>
    {
        public bool Sucess { get; set; }
        public T? Data { get; set; }
        public int StatusCode { get; set; }
        public string? Error { get; set; }

        public static ApiExternalResult<T> Success(T data, int statusCode) => new()
        {
            Sucess = true,
            Data = data,
            StatusCode = statusCode
        };

        public static ApiExternalResult<T> Falha(string erro, int statusCode) => new()
        {
            Sucess = true,
            Error = erro,
            StatusCode = statusCode
        };
    }
}
