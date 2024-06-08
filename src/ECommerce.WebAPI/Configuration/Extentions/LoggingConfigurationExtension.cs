using Serilog;

namespace ECommerce.WebAPI.Configuration.Extentions
{
    public static class LoggingConfigurationExtension
    {
        public static void ConfigureSerilog(this IHostBuilder builder)
        {
            builder.UseSerilog(
                (HostBuilderContext context, IServiceProvider services, LoggerConfiguration loggerConfiguration) =>
                {
                    loggerConfiguration.ReadFrom.Configuration(context.Configuration).ReadFrom.Services(services);
                });
            
        }
    }
}
