using System;
using MyAPI.DTO;
using MyAPI.Models;

namespace MyAPI.Services;

public interface IproductService
{
    Task<IEnumerable<ProductResponseDTO>> GetProducts();
    Task<IEnumerable<CategoryResponseDTO>> GetCategories();
    Task InsertProducts(ProductModel product);
    Task InsertCategory(CategoryModel category);
}
