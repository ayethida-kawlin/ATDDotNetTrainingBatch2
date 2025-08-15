using ATDDotNetTrainingBatch2.DI_Database.AppDbContextModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ATDDotNetTrainingBatch2.DISample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly AppDbContext _db;
        private readonly IConfiguration _configuration;

        public ProductController(AppDbContext db, IConfiguration configuration)
        {
            _db = db;
            _configuration = configuration;
        }
        [HttpGet]
        public IActionResult Get()
        {
            // Validation
            // Logic
            // Data Access
            var products = _db.TblProducts.ToList();
            return Ok(products);
        }
        [HttpGet("GetConnectionString")]
        public IActionResult GetConnectionString()
        {
            return Ok(_configuration.GetConnectionString("DbConnection"));
        }

    }
}
