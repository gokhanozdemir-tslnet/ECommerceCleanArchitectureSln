
using AutoMapper;
using ECommerce.Core.Configuration.Mapper;

namespace ECommerce.Core.Helpers.Mapper
{
    public static class AppMapperBase
    {
        private static readonly Lazy<IMapper> Lazy = new Lazy<IMapper>(() =>
        {
            var config = new MapperConfiguration(conf =>
            {
                conf.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
                conf.AddProfile<MapperConfig>();
            });
            var mapper = config.CreateMapper();
            return mapper;
        });

        public static IMapper Mapper => Lazy.Value;
        
    }
}
