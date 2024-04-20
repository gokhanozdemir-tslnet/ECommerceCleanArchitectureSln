

using ECommerce.Core.Domain.Entities;
using ECommerce.Core.DTOs.Request;
using ECommerce.Core.DTOs.Response;
using ECommerce.Core.Helpers.Mapper;

namespace ECommerce.Core.Helpers.Extensions
{
    public static class CategoryExtensions
    {
        public static Category ToCategory(this AddCategoryRequest reqCategory)
        {
            Category category = AppMapperBase
            .Mapper
            .Map<Category>(reqCategory);
            return category;
        }

        public static Category ToCategory(this UpdateCategoryRequest reqCategory)
        {
            Category category = AppMapperBase
            .Mapper
            .Map<Category>(reqCategory);
            return category;
        }

        public static AddCategoryResponse ToAddCategoryResponse(this Category reqCategory)
        {
            AddCategoryResponse category = AppMapperBase
            .Mapper
            .Map<AddCategoryResponse>(reqCategory);
            return category;
        }

        public static GetCategoryResponse ToGetCategoryResponse(this Category reqCategory)
        {
            GetCategoryResponse category = AppMapperBase
            .Mapper
            .Map<GetCategoryResponse>(reqCategory);
            return category;
        }

        public static UpdateCategoryResponse ToUpdateCategoryResponse(this Category reqCategory)
        {
            UpdateCategoryResponse category = AppMapperBase
            .Mapper
            .Map<UpdateCategoryResponse>(reqCategory);
            return category;
        }
        public static GetCategoryResponse ToGetCategoryResponse(this UpdateCategoryRequest reqCategory)
        {
            GetCategoryResponse category = AppMapperBase
            .Mapper
            .Map<GetCategoryResponse>(reqCategory);
            return category;
        }
    }
}
