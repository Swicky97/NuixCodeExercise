using InvestmentPerformanceApi.Repos;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Investment Performance API", Version = "v1" });
});

builder.Services.AddSingleton<InvestmentRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Investment Performance API v1");
    c.RoutePrefix = string.Empty;
});

//app.UseHttpsRedirection();

app.MapControllers();

app.Run();

