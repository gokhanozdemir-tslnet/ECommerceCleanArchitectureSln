using Autofac.Core;
using ECommerce.Core.Domain.IdentityEntities;
using ECommerce.Core.Services.ProductServices;
using ECommerce.Infastructure.DbContexts;
using ECommerce.UI.Resources;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace ECommerce.UI.Extensions.Startup
{
    public static class ConfigureServicesExtension
    {
        [Obsolete]
        public static IServiceCollection ConfigureServices(
            this IServiceCollection services,
            IConfiguration configuration)
        {


            #region FluentValidation
            _ = services.AddControllersWithViews()
                .AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<ProductAdderService>());
            #endregion

            #region LanguageSettings
            services.AddLocalization(options => options.ResourcesPath = "Resources");
            CultureInfo[] suportedCultures = new[]
            {
                new CultureInfo("tr-TR"),
                new CultureInfo("en-GB")
            };

            services.Configure<RequestLocalizationOptions>(options =>
            {
                options.DefaultRequestCulture = new RequestCulture("tr-TR");

                options.SupportedCultures = suportedCultures;
                options.SupportedUICultures = suportedCultures;
                options.RequestCultureProviders = new List<IRequestCultureProvider>
                {
                    new QueryStringRequestCultureProvider(),
                    new CookieRequestCultureProvider(),
                };

            });
            services.AddControllersWithViews().AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix);
            services.AddSingleton<GlobalResource>();
            #endregion

            #region IdentityConfigurationService
            //Identity service
            string? identityConnection = configuration.GetConnectionString("IdentityConnection");

            services.AddDbContext<AppUserDbContext>(options => options.UseSqlServer(identityConnection));

            services.AddIdentity<AppUser, AppRole>(options =>
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


            services.AddAuthorization(options =>
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

            services.ConfigureApplicationCookie(options => { options.LoginPath = "/Account/Login"; });

            #endregion

            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("ECommerceDb"));
            });


            services.AddControllersWithViews();

            return services;
        }
    }
}
