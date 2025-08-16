using ATDDotNetTrainingBatch2.DI_Database.AppDbContextModels;
using ATDDotNetTrainingBatch2.DISample.Bl;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ATDDotNetTrainingBatch2.DISample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductV2Controller : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductV2Controller(ProductService productService) 
        { 
            _productService = productService;
        }
        //https://localhost:5000/api/ProductV2/1/10
        [HttpGet("{pageNo}/{pageSize}")]
        public IActionResult GetProducts(int pageNo, int pageSize)
        {
            var result = _productService.GetProducts(pageNo, pageSize);
            return Ok(result);
        }

        [HttpGet("List/{pageNo}/{pageSize}")]
        public async Task<IActionResult> GetProductsAsync(int pageNo, int pageSize)
        {
            var result = await _productService.GetProductsAsync(pageNo, pageSize);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> CreateProductAsync(TblProduct product)
        {
            if (product is null)
            {
                return BadRequest("Product cannot be null");
            }
            var result = await _productService.AddProductAsync(product);
            return Ok(result);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateProductAsync(int id, TblProduct product)
        {
            if (id == 0)
            {
                return BadRequest("Invalid Product Id");
            }
            product.ProductId = id;
            var result = await _productService.UpdateProductAsync(product);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductAsync(int id)
        {
            if (id == 0)
            {
                return BadRequest("Invalid Product Id");
            }
            
            var result = await _productService.DeleteProductAsync(id);
            return Ok(result);
        }
    }
}
