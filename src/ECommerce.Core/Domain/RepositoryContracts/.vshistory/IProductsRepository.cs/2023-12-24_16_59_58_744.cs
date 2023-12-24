﻿

using ECommerce.Core.Domain.Entities;

namespace ECommerce.Core.Domain.RepositoryContracts
{
    public interface IProductsRepository
    {
        Product GetProductById(int productId);
        Product GetProductByName(string productName);
        Task<List<Product>> GetAllProductsAsync();
        Product AddProduct(Product product);

    }
}
