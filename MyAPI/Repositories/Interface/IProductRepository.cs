using System;
using MyAPI.Models;

namespace MyAPI.Repositories.Interface;

public interface IProductRepository
{
    Task<IEnumerable<ProductModel>> GetProducts();
    Task<IEnumerable<CategoryModel>> GetCategories();
    Task InsertProducts(ProductModel product);
    Task InsertCategory(CategoryModel category);
}
