using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyAPI.Data;
using MyAPI.Models;

namespace MyAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ProductController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> InsertProducts(ProductModel product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            var successMsg = new SuccessResponseModel<string>{
                resultCode = "01",
                errorMsg = "Product Created Successfully"
            };
            return Ok(successMsg);
        }

        [HttpPost]
        public async Task<IActionResult> InsertCategory(CategoryModel category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            var successMsg = new SuccessResponseModel<string>
            {
                resultCode = "01",
                errorMsg = "Category Inserted Successfully"
            };
            return Ok(successMsg);
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var lst_products = await _context.Products.Include(p => p.Category).ToListAsync();
            var response = new SuccessResponseModel<ProductModel>
            {
                resultCode = "01",
                errorMsg = "",
                Data = lst_products 
            };
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var lst_categories = await _context.Categories.ToListAsync();
            var response = new SuccessResponseModel<CategoryModel>
            {
                resultCode = "01",
                errorMsg = "",
                Data = lst_categories
            };
            return Ok(response);
        }
    }
}
