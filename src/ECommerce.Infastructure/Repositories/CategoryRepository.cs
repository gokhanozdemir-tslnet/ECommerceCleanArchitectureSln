
using ECommerce.Core.Domain.Entities;
using ECommerce.Core.Domain.RepositoryContracts;
using ECommerce.Core.DTOs.Response;
using ECommerce.Core.Exceptions;
using ECommerce.Infastructure.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;

namespace ECommerce.Infastructure.Repositories
{
    public class CategoryRepository : ICategoriesRepository
    {
        private readonly AppDbContext _db;

        public CategoryRepository(AppDbContext db)
        {
            _db = db;
        }
        public async Task<Category> AddCategoryAsync(Category category)
        {
            if (await CategoryNameIsExists(category.Name))
            {
                throw new CategoryIsExsistExceptions($"Category {category.Name} zaten tanımlı");
            }

            await _db.Categories.AddAsync(category);
            var resutl = await _db.SaveChangesAsync();
            return category;
        }



        public async Task<List<Category>> GetAllCategoriesASync()
        {
            return await _db.Categories.ToListAsync();
        }
        public IQueryable<Category> GetAllCategories()
        {
            return _db.Categories.AsQueryable();
        }
        public async Task<Category> UpdateCategoryAsync(Category category)
        {
            Category? updatedCategory = await _db.Categories.FirstOrDefaultAsync(temp => temp.Id == category.Id);
            if (updatedCategory == null)
            {
                throw new ArgumentException("Given person id doesn't exist");
            }

            //update all details
            updatedCategory.Name = category.Name;
            updatedCategory.Description = category.Description;
            updatedCategory.UpdatedDate = category.UpdatedDate;
            updatedCategory.ParentCategoryId = category.ParentCategoryId;
            updatedCategory.Tags = category.Tags;
            await _db.SaveChangesAsync(); //UPDATE
            return category;
        }
        public Task<Category> GetCategoryById(int id) => _db.Categories.FirstOrDefaultAsync(x => x.Id == id);
        public async Task<bool> CategoryNameIsExists(string name)
        {
            var result = await _db.Categories.AnyAsync(x => x.Name == name);
            return result;
        }

        public Task<bool> DeleteCategoryAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Category> GetCategoryByUId(Guid uid)
        {
            return _db.Categories.FirstOrDefaultAsync(x => x.Id == 1);
        }
    }
}



  //public IQueryable<Category> GetAllCategories()
        //{
        //    return _db.Categories.AsQueryable();
        //}