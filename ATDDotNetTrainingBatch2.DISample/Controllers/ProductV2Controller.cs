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
    }
}
