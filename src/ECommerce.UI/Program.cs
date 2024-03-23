using Autofac;
using Autofac.Extensions.DependencyInjection;
using ECommerce.Core.Domain.RepositoryContracts;
using ECommerce.Core.ServiceContracts.CategoryContracts;
using ECommerce.Core.ServiceContracts.ProductContracts;
using ECommerce.Core.Services.CategoryServices;
using ECommerce.Core.Services.ProductServices;
using ECommerce.Infastructure.DbContexts;
using ECommerce.Infastructure.Repositories;
using ECommerce.UI.Resources;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

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
    .InstancePerLifetimeScope();

    containerBuilder.RegisterType<CategoryAdderService>()
    .As<ICategoryAdderService>()
    .UsingConstructor(typeof(ICategoriesRepository))
    .InstancePerLifetimeScope();



});

//end of IOc container

// add fluent validation
builder.Services.AddControllersWithViews().AddFluentValidation(
    x => x.RegisterValidatorsFromAssemblyContaining<ProductAdderService>()  );

//multi language
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");
CultureInfo[] suportedCultures = new[]
{
    new CultureInfo("tr-TR"),
    new CultureInfo("en-GB")

};
builder.Services.Configure<RequestLocalizationOptions>(
    options =>
    {
        options.DefaultRequestCulture = new RequestCulture("tr-TR");
        
        options.SupportedCultures = suportedCultures;
        options.SupportedUICultures = suportedCultures;
        options.RequestCultureProviders = new List<IRequestCultureProvider>
        {
            new QueryStringRequestCultureProvider(),
            new CookieRequestCultureProvider(),
        };

    }
    );
//eend of middle



builder.Services.AddControllersWithViews().AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix);
builder.Services.AddSingleton<GlobalResource>();

// Add services to the container.
builder.Services.AddControllersWithViews();


var name = typeof(AppDbContext).Assembly.GetName().Name;

builder.Services.AddDbContext<AppDbContext>(
    options =>
    {
        options.UseSqlServer(
            builder.Configuration.GetConnectionString("ECommerceDb")
            );
    }
    );

var app = builder.Build();


app.UseRequestLocalization();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "Admin",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
