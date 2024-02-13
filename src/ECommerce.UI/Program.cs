using ECommerce.Infastructure.DbContexts;
using ECommerce.UI.Resources;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);



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


app.UseRequestLocalization(
    //(options) => options.SetDefaultCulture("tr-TR")
    );


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
