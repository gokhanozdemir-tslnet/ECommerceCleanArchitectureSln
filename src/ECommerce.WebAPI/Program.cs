using ECommerce.WebAPI.Configuration.Extentions;
using ECommerce.WebAPI.Filters;
using Serilog;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.ConfigureAutofacServiceProvider().AddLifetimeServices();
builder.Services.AddConfig(builder.Configuration);
builder.Services.AddControllers( options =>
{
    options.Filters.Add(typeof(GlobalExceptionHandlerFilter));
});
builder.ConfigureDbContext();
builder.Host.ConfigureSerilog(); 





builder.Services.ConfigureCors();

var app = builder.Build();

app.UseSerilogRequestLogging();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    //    app.UseDeveloperExceptionPage();
    //    app.UseDatabaseErrorPage();
}
else
{
    //    app.UseExceptionHandler("/Error");
    //    app.UseHsts();
}
// Configure the HTTP request pipeline.



app.UseHttpsRedirection();

app.UseAuthentication();
//app.UseAuthorization();

app.MapControllers();

app.Run();
