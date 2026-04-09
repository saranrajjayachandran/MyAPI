using System;
using MyAPI.Models;

namespace MyAPI.Services;

public interface IproductService
{
    Task<IEnumerable<ProductModel>> GetProducts();
    Task<IEnumerable<CategoryModel>> GetCategories();
    Task InsertProducts(ProductModel product);
    Task InsertCategory(CategoryModel category);
}
