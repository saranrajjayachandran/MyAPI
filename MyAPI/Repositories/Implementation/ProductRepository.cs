using System;
using Microsoft.EntityFrameworkCore;
using MyAPI.Data;
using MyAPI.Models;
using MyAPI.Repositories.Interface;

namespace MyAPI.Repositories.Implementation;

public class ProductRepository : IProductRepository
{
private readonly AppDbContext dbContext;

    public ProductRepository(AppDbContext context)
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

    public async Task<bool> DeleteCategory(String ID)
    {
        var category = await dbContext.Categories.FindAsync(int.Parse(ID));
        if(category == null) return false;
        dbContext.Categories.Remove(category!);
        await dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteProduct(String ID)
    {
        var product = await dbContext.Products.FindAsync(int.Parse(ID));
        if(product == null) return false;
        dbContext.Products.Remove(product!);
        await dbContext.SaveChangesAsync();
        return true;
    }
}
