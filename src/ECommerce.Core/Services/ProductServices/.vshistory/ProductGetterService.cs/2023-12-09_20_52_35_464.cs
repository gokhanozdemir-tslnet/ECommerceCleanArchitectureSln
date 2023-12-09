﻿
using ECommerce.Core.Domain.Entities;
using ECommerce.Core.Domain.RepositoryContracts;
using ECommerce.Core.DTOs.Request;
using ECommerce.Core.DTOs.Response;
using ECommerce.Core.Helpers.Mapper;
using ECommerce.Core.Helpers.Validations;
using ECommerce.Core.ServiceContracts.ProductContracts;
using FluentValidation;

namespace ECommerce.Core.Services.ProductServices
{
    public class ProductGetterService : IProductGetterService
    {
        ProductGetterValidator _validator;
        IProductsRepository _productsRepository;

        public ProductGetterService(IProductsRepository productsRepository)
        {
            _validator = new ProductGetterValidator();
            _productsRepository = productsRepository;
        }

        public GetProductResponse GetProduct(GetProductRequest request)
        {
     
            _validator.ValidateAndThrow(request);
            var product = _productsRepository.GetProductById(request.Id);        
            GetProductResponse response = AppMapperBase.Mapper.Map<GetProductResponse>(product);
            return response;
        }
    }
}
