using System;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using MyAPI.Data;
using MyAPI.Models;

namespace MyAPI.Services;

public class ProductService : IproductService
{
    private readonly AppDbContext dbContext;

    public ProductService(AppDbContext context)
    {
        dbContext = context;
    }


    public async Task<IEnumerable<ProductModel>> GetProducts()
    {
        var lst_products  = await dbContext.Products.Include(p => p.Category).ToListAsync();
        return lst_products;
    }

    public async Task<IEnumerable<CategoryModel>> GetCategories()
    {
        var lst_categories = await dbContext.Categories.ToListAsync();
        return lst_categories;
    }

    public async Task InsertProducts(ProductModel model)
    {
         dbContext.Products.Add(model);
         await dbContext.SaveChangesAsync();
         
    }

    public async Task InsertCategory(CategoryModel model)
    {
        dbContext.Categories.Add(model);
        await dbContext.SaveChangesAsync();
    }

}
