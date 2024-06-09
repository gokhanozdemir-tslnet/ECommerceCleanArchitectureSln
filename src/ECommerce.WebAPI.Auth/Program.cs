using Autofac;
using Autofac.Extensions.DependencyInjection;
using ECommerce.Core.Domain.RepositoryContracts.Auth;
using ECommerce.Core.Services.AuthService;
using Microsoft.AspNetCore.Authentication;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(
    container =>
    {
        container.RegisterType<AuthService>().As<IAuthService>().InstancePerLifetimeScope();
    });

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
