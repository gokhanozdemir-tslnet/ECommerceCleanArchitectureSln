namespace ECommerce.WebAPI.Configuration.Extentions
{
    public static class ConfigurePoliciesExtension
    {
        public static IServiceCollection ConfigureCors(this IServiceCollection services)
        {


            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    );

            });

            return services;
        }
    }
}
