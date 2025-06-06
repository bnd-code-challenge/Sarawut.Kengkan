using Microsoft.EntityFrameworkCore;
using NeoBank.Configurations;
using NeoBank.Data;
using NeoBank.Repositories;
using NeoBank.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(option => option.UseInMemoryDatabase("NeoBank"));

builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("ApiSettings"));

builder.Services.AddHttpClient("Randommer", httpClient =>
{
    httpClient.BaseAddress = new Uri("https://randommer.io/api/");
    httpClient.DefaultRequestHeaders.Add("X-Api-Key", builder.Configuration.GetSection("ApiSettings:RandommerApiKey").ToString());
});

// Add services to the container.
builder.Services.AddScoped<IGetIBanRepository, GetIBanRepository>();
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<IAccountService, AccountService>();

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.MapControllers();

app.Run();
