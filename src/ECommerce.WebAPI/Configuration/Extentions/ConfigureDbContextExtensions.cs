using ECommerce.Infastructure.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.WebAPI.Configuration.Extentions
{
    public static class ConfigureDbContextExtensions
    {
        public static WebApplicationBuilder ConfigureDbContext(this WebApplicationBuilder builder)
        {

            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("ECommerceDb"));
            });


            return builder;
        }
    }
}
