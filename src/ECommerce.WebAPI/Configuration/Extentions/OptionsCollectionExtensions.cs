using ECommerce.WebAPI.Configuration.Object;

namespace ECommerce.WebAPI.Configuration.Extentions
{
    public static class OptionsCollectionExtensions
    {
        public static IServiceCollection AddConfig(this IServiceCollection services,IConfiguration configuration)
        {
            services.Configure<DatabaseOption>(configuration.GetSection(DatabaseOption.SectionName));
            return services;
        }
    }
}
