using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;
using Scrabex.WebApi.Contexts;
using Scrabex.WebApi.Controllers;
using Scrabex.WebApi.Dtos;
using Scrabex.WebApi.Mappers;
using Scrabex.WebApi.Models;
using System.Net;
using Microsoft.EntityFrameworkCore;
using Scrabex.WebApi.Services;

var builder = WebApplication.CreateBuilder(args);

#region Swagger
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
#endregion

#region EF
builder.Configuration.SetBasePath(Directory.GetCurrentDirectory());
builder.Configuration.AddJsonFile("appsettings.json");
var connectionString = builder.Configuration.GetConnectionString("devConnection");
#endregion

#region Bindings
// DB
builder.Services.AddDbContext<UserContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddDbContext<ScenarioContext>(options => options.UseSqlServer(connectionString));

// services
builder.Services.AddScoped<IObjectService<User, CreateUserDto, UserDto>, UserService>();
builder.Services.AddScoped<IObjectService<Scenario, CreateScenarioDto, ScenarioDto>, ScenarioService>();

// mappers
builder.Services.AddScoped<IMapper<User, CreateUserDto, UserDto>, UserMapper>();
builder.Services.AddScoped<IMapper<UserDetail, CreateUserDetailDto, UserDetailDto>, UserDetailMapper>();
builder.Services.AddScoped<IMapper<Scenario, CreateScenarioDto, ScenarioDto>, ScenarioMapper>();
builder.Services.AddScoped<IMapper<ScenarioComponent, CreateScenarioComponentDto, ScenarioComponentDto>, ScenarioComponentMapper>();
builder.Services.AddScoped<IMapper<ScenarioStep, CreateScenarioStepDto, ScenarioStepDto>, ScenarioStepMapper>();

// facades
builder.Services.AddScoped<IObjectServiceFacade, ObjectServiceFacade>();

#endregion

#region Security
builder
    .Services
    .AddCors(
    c => c.AddPolicy("AllowOrigin",
    options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));

builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(10);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
#endregion

#region Serialization
builder
    .Services
    .AddControllersWithViews()
    .AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore)
    .AddNewtonsoftJson(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());
#endregion

builder.Services.AddControllers();

#region SSL
if (!builder.Environment.IsDevelopment())
{
    builder.Services.AddHttpsRedirection(options =>
    {
        options.RedirectStatusCode = (int)HttpStatusCode.PermanentRedirect;
        options.HttpsPort = 443;
    });
}
#endregion

var app = builder.Build();

#region Dev Options
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
#endregion

app.UseHttpsRedirection();

app.UseSession();

app.UseAuthorization();

app.MapControllers();

app.Run();
