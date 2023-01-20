using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Nadafa.Api;
using Nadafa.Gateway.Helpers;
using Microsoft.Extensions.DependencyInjection;
using Nadafa.SharedKernal.Application;
using Nadafa.SharedKernal.Api;
using Serilog;
using Nadafa.SharedKernal.Application.Swagger;
using Nadafa.SharedKernal.Application.Versioning;
using Nadafa.SharedKernal.Application.Exceptions;
using Nadafa.SharedKernal.Application.JwtAuthorization;
using Nadafa.Requests.Api;

var builder = WebApplication.CreateBuilder(args);

#region AppSettings

builder.Configuration
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", true, true)
    .AddEnvironmentVariables();

#endregion

#region .Net Services

builder.Services.AddControllersWithViews();

builder.Services.AddControllers(options =>
{
    options.Conventions.Add(new RouteTokenTransformerConvention(new SlugifyParameterTransformer()));
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddHttpContextAccessor();
#endregion


#region Shared Kernal

builder.Services.AddSharedKernal(builder.Configuration);
builder.Host.UseSerilog();
builder.Services.AddBaseSwagger(builder.Configuration);
builder.Services.AddBaseApiVersioning();
builder.Services.AddExceptionHandling();
#endregion

#region Application Module

builder.Services.AddUser(builder.Configuration).AddRequest(builder.Configuration);

#endregion

#region Authorization

builder.Services.AddBaseAuthorization(builder.Configuration);

#endregion

var app = builder.Build();
IWebHostEnvironment env = app.Environment;


#region Shared Kernal Package

app.UseExceptionHandling();
app.UseBaseSwagger(builder.Configuration);

#endregion


using(var scope = app.Services.CreateScope())
{
    await scope.MigrateDatabase();
}

app.Run();
