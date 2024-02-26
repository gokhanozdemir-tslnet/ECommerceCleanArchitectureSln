

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

        public static AddCategoryResponse ToCategory(this Category reqCategory)
        {
            AddCategoryResponse category = AppMapperBase
            .Mapper
            .Map<AddCategoryResponse>(reqCategory);
            return category;
        }
    }
}
