using HubMarketplace.api.Options;
using HubMarketplace.api.Services.ApiExternalService;
using HubMarketplace.api.Services.ApiExternalService.Interface;
using HubMarketplace.api.Services.MercadoLivreService;
using HubMarketplace.api.Services.MercadoLivreService.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

//Options
builder.Services.Configure<MercadoLivreOptions>(builder.Configuration.GetSection(MercadoLivreOptions.SectionName));

builder.Services.AddHttpClient("ApiExternal");

builder.Services.AddScoped<IApiExternalService, ApiExternalService>();
builder.Services.AddScoped<IAuthMercadoLivreService, AuthMercadoLivreService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
