using ATDDotNetTrainingBatch2.Database2.AppDbContextModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ATDDotNetTrainingBatch2.WebApi2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly AppDbContext _db;
        public ProductController()
        {
            _db = new AppDbContext();
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            var lst = _db.TblProducts.Where(x => x.IsDelete == false).ToList(); // pagination
            return Ok(lst);
        }

        [HttpPost]
        public IActionResult CreateProduct(TblProduct product)
        {
            _db.TblProducts.Add(product);
            _db.SaveChanges();
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpsertProduct(int id, TblProduct product)
        {
            var item = _db.TblProducts.FirstOrDefault(x => x.ProductId == id);
            if (item is null)
            {
                _db.TblProducts.Add(product);
                _db.SaveChanges();
            }
            else
            {
                item.ProductItem = product.ProductItem;
                item.ProductCode = product.ProductCode;
                item.Price = product.Price;
                _db.SaveChanges();
            }
            return Ok();
        }

        [HttpPatch("{id}")]
        public IActionResult UpdateProduct(int id, TblProduct product)
        {
            var item = _db.TblProducts.FirstOrDefault(x => x.ProductId == id);
            if (item is null)
            {
                return NotFound();
            }

            item.ProductItem = product.ProductItem;
            item.ProductCode = product.ProductCode;
            item.Price = product.Price;
            _db.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var item = _db.TblProducts.FirstOrDefault(x => x.ProductId == id);
            if (item is null)
            {
                return NotFound();
            }

            item.IsDelete = true;
            _db.SaveChanges();
            return Ok();
        }
    }

}
