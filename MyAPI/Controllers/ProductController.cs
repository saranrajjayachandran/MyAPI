using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyAPI.Data;
using MyAPI.DTO;
using MyAPI.Models;
using MyAPI.Services;

namespace MyAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IproductService _productService;
        public ProductController(IproductService service)
        {
            _productService = service;
        }

        [HttpPost]
        public async Task<IActionResult> InsertProducts(ProductModel product)
        {
            await _productService.InsertProducts(product);
            var successMsg = new SuccessResponseModel<string>{
                resultCode = "01",
                errorMsg = "Product Created Successfully"
            };
            return Ok(successMsg);
        }

        [HttpPost]
        public async Task<IActionResult> InsertCategory(CategoryModel category)
        {
            await _productService.InsertCategory(category);
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
            var lst_products = await _productService.GetProducts();
            var response = new SuccessResponseModel<ProductResponseDTO>
            {
                resultCode = "01",
                errorMsg = "",
                Data = lst_products.ToList() 
            };
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var lst_categories = await _productService.GetCategories();
            var response = new SuccessResponseModel<CategoryResponseDTO>
            {
                resultCode = "01",
                errorMsg = "",
                Data = lst_categories.ToList()
            };
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteProduct(String ID)
        {
            var result = await _productService.DeleteProduct(ID);
            var response = result == true ? new SuccessResponseModel<String>
            {
                resultCode = "01",
                errorMsg = "Product Deleted Successfully",
                Data = []
            } : 
            new SuccessResponseModel<String>
            {
                resultCode = "00",
                errorMsg = "Product Does not found, Try with different Product ID.",
                Data = []
            };
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteCategory(String ID)
        {
            var result = await _productService.DeleteCategory(ID);
            var response = result == true ? new SuccessResponseModel<String>
            {
                resultCode = "01",
                errorMsg = "Catgory Deleted Successfully",
                Data = []
            } : 
            new SuccessResponseModel<String>
            {
                resultCode = "00",
                errorMsg = "Category Does not Found. Try with Different Category ID",
                Data = []
            };
            return Ok(response);
        }
    }
}
