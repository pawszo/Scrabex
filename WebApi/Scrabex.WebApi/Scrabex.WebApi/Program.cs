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
using Scrabex.WebApi.Dtos.User;
using Scrabex.WebApi.Dtos.Scenario;
using Microsoft.AspNetCore.Authentication;
using Scrabex.WebApi.Handlers;

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
builder.Services.AddScoped<IObjectService<User, CreateUserDto, UserDto, UpdateUserDto>, UserService>();
builder.Services.AddScoped<IObjectService<Scenario, CreateScenarioDto, ScenarioDto, UpdateScenarioDto>, ScenarioService>();
builder.Services.AddScoped<IAuthService, UserService>();

// mappers
builder.Services.AddScoped<IMapper<User, CreateUserDto, UserDto, UpdateUserDto>, UserMapper>();
builder.Services.AddScoped<IMapper<UserDetail, CreateUserDetailDto, UserDetailDto, UpdateUserDetailDto>, UserDetailMapper>();
builder.Services.AddScoped<IMapper<Scenario, CreateScenarioDto, ScenarioDto, UpdateScenarioDto>, ScenarioMapper>();
builder.Services.AddScoped<IMapper<ScenarioComponent, CreateScenarioComponentDto, ScenarioComponentDto, UpdateScenarioComponentDto>, ScenarioComponentMapper>();
builder.Services.AddScoped<IMapper<ScenarioStep, CreateScenarioStepDto, ScenarioStepDto, UpdateScenarioStepDto>, ScenarioStepMapper>();

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

builder
    .Services
    .AddAuthentication("BasicAuthentication")
    .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);

builder.Services.AddAuthorization();
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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
