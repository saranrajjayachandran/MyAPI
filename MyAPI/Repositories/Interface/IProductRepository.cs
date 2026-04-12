using System;
using MyAPI.Models;

namespace MyAPI.Repositories.Interface;

public interface IProductRepository
{
    Task<IEnumerable<ProductModel>> GetProducts();
    Task<IEnumerable<CategoryModel>> GetCategories();
    Task InsertProducts(ProductModel product);
    Task<bool> DeleteProduct(String ID);
    Task InsertCategory(CategoryModel category);
    Task<bool> DeleteCategory(String ID);
}
