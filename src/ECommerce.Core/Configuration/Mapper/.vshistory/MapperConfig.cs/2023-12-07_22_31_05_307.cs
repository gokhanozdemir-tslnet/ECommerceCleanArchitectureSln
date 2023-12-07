
using AutoMapper;
using ECommerce.Core.Domain.Entities;
using ECommerce.Core.DTOs.Response;

namespace ECommerce.Core.Configuration.Mapper
{
    public class MapperConfig:Profile
    {
        public MapperConfig()
        {
            CreateMap<Product, AddProductResponse>().ReverseMap();            
        }
    }
}
