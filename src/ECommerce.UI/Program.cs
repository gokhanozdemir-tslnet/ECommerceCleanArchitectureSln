using Autofac;
using Autofac.Extensions.DependencyInjection;
using ECommerce.Core.Domain.IdentityEntities;
using ECommerce.Core.Domain.RepositoryContracts;
using ECommerce.Core.ServiceContracts.CategoryContracts;
using ECommerce.Core.ServiceContracts.ProductContracts;
using ECommerce.Core.Services.CategoryServices;
using ECommerce.Core.Services.ProductServices;
using ECommerce.Infastructure.DbContexts;
using ECommerce.Infastructure.Repositories;
using ECommerce.UI.Extensions.Startup;
using ECommerce.UI.Resources;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);



//Logging Serilog
builder.Host.UseSerilog(
    (HostBuilderContext context, IServiceProvider services, LoggerConfiguration loggerConfiguration)
    =>
    {
        loggerConfiguration.ReadFrom.Configuration(context.Configuration)
        .ReadFrom.Services(services);
    }
    );

//IOC Continer
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
{
    containerBuilder.RegisterType<ProductRepository>()
    .As<IProductsRepository>().SingleInstance();

    containerBuilder.RegisterType<ProductGetterService>()
    .As<IProductGetterService>()
    .UsingConstructor(typeof(IProductsRepository))
    .InstancePerLifetimeScope();

    containerBuilder.RegisterType<ProductAdderService>()
   .As<IProductAdderService>()
   .UsingConstructor(typeof(IProductsRepository))
   .InstancePerLifetimeScope();

    containerBuilder.RegisterType<CategoryRepository>()
    .As<ICategoriesRepository>().SingleInstance();

    containerBuilder.RegisterType<CategoryGetterService>()
    .As<ICategoryGetterService>()
    .UsingConstructor(typeof(ICategoriesRepository))
    .SingleInstance();

    containerBuilder.RegisterType<CategoryAdderService>()
    .As<ICategoryAdderService>()
    .UsingConstructor(typeof(ICategoriesRepository))
    .InstancePerLifetimeScope();



});



builder.Services.ConfigureServices(builder.Configuration);




var name = typeof(AppDbContext).Assembly.GetName().Name;



var app = builder.Build();


app.UseRequestLocalization();
app.UseSerilogRequestLogging();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "Admin",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
