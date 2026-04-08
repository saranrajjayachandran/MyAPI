using System;

namespace MyAPI.Models;

public class ProductModel
{
    public int Id {get; set;} 
    public string Name {get; set;} = string.Empty;
    public string Description {get; set;} = string.Empty;
    public decimal Price {get; set;}
    public int CategoryModelId {get; set;}
    public CategoryModel? Category {get; set;}
}
