using NeoBank.Configurations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("ApiSettings"));

builder.Services.AddHttpClient("Randommer", httpClient =>
{
    httpClient.BaseAddress = new Uri("https://randommer.io/api/");
    httpClient.DefaultRequestHeaders.Add("X-Api-Key", builder.Configuration.GetSection("ApiSettings:RandommerApiKey").ToString());
});

// Add services to the container.

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
