using System;
using Microsoft.EntityFrameworkCore;
using MyAPI.Models;

namespace MyAPI.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}
    public DbSet<ProductModel> Products {get; set;}
    public DbSet<CategoryModel> Categories {get; set;}
}
