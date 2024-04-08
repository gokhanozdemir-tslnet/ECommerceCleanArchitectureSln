
using AutoMapper;
using ECommerce.Core.Domain.Entities;
using ECommerce.Core.Domain.IdentityEntities;
using ECommerce.Core.DTOs.Request;
using ECommerce.Core.DTOs.Request.AppUser;
using ECommerce.Core.DTOs.Response;

namespace ECommerce.Core.Configuration.Mapper
{
    public class MapperConfig:Profile
    {
        public MapperConfig()
        {
            CreateMap<Product, AddProductResponse>().ReverseMap(); 
            CreateMap<Product, GetProductResponse>().ReverseMap();
            CreateMap<Product,AddProductRequest>().ReverseMap();

            CreateMap<Category,AddCategoryRequest>().ReverseMap();  
            CreateMap<Category,AddCategoryResponse>().ReverseMap();
            CreateMap<Category, GetCategoryResponse>().ReverseMap();


            //Identity 
            CreateMap<AppUser, RegisterRequest>().ReverseMap();
        }
    }
}
