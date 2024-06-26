﻿
using ECommerce.Core.Domain.Entities;
using ECommerce.Core.DTOs.Response;

namespace ECommerce.Core.ServiceContracts.CategoryContracts
{
    public interface ICategoryGetterService
    {
        Task<IQueryable<GetCategoryResponse>> GetCategories();
        Task<List<Category>> GetAllCategoriesASync();
        Task<GetCategoryResponse> GetCategoryById(int id);
        //Task<GetCategoryResponse> GetCategoryByIdAsync(Guid uId);
        Task<GetCategoryResponse> GetCategoryByUId(Guid uid);
        Task<GetCategoryResponse> GetCategoryByName(string name);
    }
}
