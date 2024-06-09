using ECommerce.WebAPI.Configuration.Extentions;
using ECommerce.WebAPI.Filters;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.IdentityModel.Tokens;
using Serilog;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.ConfigureAutofacServiceProvider().AddLifetimeServices();
builder.Services.AddConfig(builder.Configuration);

//jwt
builder.Services.AddAuthentication(options=>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;    
}).AddJwtBearer(
        options =>
        {
            options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
            {
                ValidateAudience = true,
                ValidAudience = builder.Configuration["Jwt:Audience"],
                ValidateIssuer = true,
                ValidIssuer = builder.Configuration["Jwt:Issuer"],
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
            };
        }
    );

builder.Services.AddAuthorization();

builder.Services.AddControllers( options =>
{
    options.Filters.Add(typeof(GlobalExceptionHandlerFilter));
    options.Filters.Add(new ProducesAttribute("application/json"));
    options.Filters.Add(new ConsumesAttribute("application/json"));

    //Authorization policy
    var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
    options.Filters.Add(new AuthorizeFilter(policy));
});
builder.ConfigureDbContext();
builder.Host.ConfigureSerilog(); 





builder.Services.ConfigureCors();

var app = builder.Build();

app.UseSerilogRequestLogging();

app.UseAuthentication();
app.UseAuthorization();

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
