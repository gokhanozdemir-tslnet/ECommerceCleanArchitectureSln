using Autofac;
using Autofac.Extensions.DependencyInjection;
using ECommerce.Core.Domain.RepositoryContracts;
using ECommerce.Core.ServiceContracts.CategoryContracts;
using ECommerce.Core.ServiceContracts.ProductContracts;
using ECommerce.Core.Services.CategoryServices;
using ECommerce.Core.Services.ProductServices;
using ECommerce.Infastructure.Repositories;

namespace ECommerce.WebAPI.Configuration.Extentions
{
    public static class LifetimeServicesCollectionExtension
    {
        public static WebApplicationBuilder ConfigureAutofacServiceProvider(this WebApplicationBuilder builder)
        {
            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
            return builder;
        }

        public static WebApplicationBuilder AddLifetimeServices(this WebApplicationBuilder builder)
        {

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

            return builder;
        }
    }
}
