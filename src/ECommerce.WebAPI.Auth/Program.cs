using Autofac;
using Autofac.Core;
using Autofac.Extensions.DependencyInjection;
using ECommerce.Core.Domain.IdentityEntities;
using ECommerce.Core.Domain.RepositoryContracts.Auth;
using ECommerce.Core.Services.AuthService;
using ECommerce.Infastructure.DbContexts;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

//Identity service
string? identityConnection = builder.Configuration.GetConnectionString("IdentityConnection");

builder.Services.AddDbContext<AppUserDbContext>(options => options.UseSqlServer(identityConnection));

builder.Services.AddIdentity<AppUser, AppRole>(options =>
{
    options.Password.RequiredLength = 5;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = true;
    options.Password.RequireDigit = false;
    options.Password.RequiredUniqueChars = 3;
}
    )
    .AddEntityFrameworkStores<AppUserDbContext>()
    .AddDefaultTokenProviders()
    .AddUserStore<UserStore<AppUser, AppRole, AppUserDbContext, Guid>>()
    .AddRoleStore<RoleStore<AppRole, AppUserDbContext, Guid>>();


builder.Services.AddAuthorization(options =>
{
    options.FallbackPolicy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build(); //enforces authoriation policy (user must be authenticated) for all the action methods

    options.AddPolicy("NotAuthorized", policy =>
    {
        policy.RequireAssertion(context =>
        {
            return !context.User.Identity.IsAuthenticated;
        });
    });
});


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
