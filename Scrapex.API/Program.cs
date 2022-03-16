using OpenQA.Selenium;
using Scrapex.Infrastructure.Factories;
using Scrapex.Application.Configs;
using Scrapex.Application.Factories;
using Scrapex.Application.Services;
using Scrapex.Infrastructure.Configs;
using Scrapex.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IFactory<IWebDriver>, WebDriverFactory>(); 
builder.Services.AddSingleton<IConfig, InCodeConfig>();
builder.Services.AddTransient<IMediaService, MediaService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
