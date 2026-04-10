using System;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using MyAPI.Data;
using MyAPI.DTO;
using MyAPI.Models;
using MyAPI.Repositories.Interface;

namespace MyAPI.Services;

public class ProductService : IproductService
{
    private readonly IProductRepository productRepo;

    public ProductService(IProductRepository repo)
    {
        productRepo = repo;
    }


    public async Task<IEnumerable<ProductResponseDTO>> GetProducts()
    {
        var lst_products  = await productRepo.GetProducts();
        return lst_products.Select(p => new ProductResponseDTO
        {
            Id = p.Id,
            Name = p.Name,
            Description = p.Description,
            Price = p.Price,
            CategoryName = p.Category.Name ?? "NIL",
        });
    }

    public async Task<IEnumerable<CategoryResponseDTO>> GetCategories()
    {
        var lst_categories = await productRepo.GetCategories();
        return lst_categories.Select(p => new CategoryResponseDTO
        {
            Id = p.Id,
            Name = p.Name
        });
    }

    public async Task InsertProducts(ProductModel model)
    {
         await productRepo.InsertProducts(model);
         
    }

    public async Task InsertCategory(CategoryModel model)
    {
        await productRepo.InsertCategory(model);
    }

}
