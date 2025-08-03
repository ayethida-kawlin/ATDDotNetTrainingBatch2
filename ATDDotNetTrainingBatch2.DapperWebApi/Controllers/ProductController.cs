using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;

namespace ATDDotNetTrainingBatch2.DapperWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]


    public class ProductController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public ProductController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("DbConnection")))
            {
                db.Open();
                var lst = db.Query<ProductModel>("select * from Tbl_Product where IsDelete=0;");
                return Ok(lst);
            }

        }

        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("DbConnection")))
            {
                db.Open();
                var item = db.QueryFirstOrDefault<ProductModel>("select * from Tbl_Product where ProductId = @ProductId;", new
                {
                    ProductId = id
                });
                //if(item == null)
                if (item is null)
                {
                    return NotFound();
                }
                return Ok(item);
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpsertProduct(int id, ProductRequestModel requestModel)
        {
            using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("DbConnection")))
            {
                db.Open();
                var item = db.QueryFirstOrDefault<ProductModel>("select * from Tbl_Product where ProductId = @ProductId;", new
                {
                    ProductId = id
                });
                if(item is null)
                {
                    string query = @"INSERT INTO [dbo].[Tbl_Product]
           ([ProductCode]
           ,[ProductItem]
           ,[Price]
           ,[IsDelete])
     VALUES
           (@ProductCode
           ,@ProductItem
           ,@Price
           ,0)";
                    int result = db.Execute(query, requestModel);
                    return Ok(result > 0 ? "Creating successful" : " Creating Failed");
                }
                else
                {
                    string query = @"UPDATE [dbo].[Tbl_Product]
   SET [ProductCode] = @ProductCode
      ,[ProductItem] = @ProductItem
      ,[Price] = @Price
 WHERE ProductId = @ProductId;";
                    int result = db.Execute(query, new
                    {
                        ProductCode = requestModel.ProductCode,
                        ProductItem = requestModel.ProductItem,
                        Price = requestModel.Price,
                        ProductId = id
                    });
                    return Ok(result > 0 ? "Updating successful" : "Updating Failed");
                }
            }
        }

        [HttpPost]
        public IActionResult CreateProduct(ProductRequestModel requestModel)
        {
            string query = @"INSERT INTO [dbo].[Tbl_Product]
           ([ProductCode]
           ,[ProductItem]
           ,[Price]
           ,[IsDelete])
     VALUES
           (@ProductCode
           ,@ProductItem
           ,@Price
           ,0)";
            using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("DbConnection")))
            {
                db.Open();
                int result = db.Execute(query, requestModel);
                return Ok(result > 0 ? "Saving Successful" : "Saving Failed");
            }

        }

        [HttpPatch("{id}")]
        public IActionResult UpdateProduct(int id, ProductRequestModel requestModel)
        {
            string query = @"UPDATE [dbo].[Tbl_Product]
   SET [ProductCode] = @ProductCode
      ,[ProductItem] = @ProductItem
      ,[Price] = @Price
 WHERE ProductId = @ProductId;";
            using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("DbConnection")))
            {
                db.Open();
                int result = db.Execute(query, new
                {
                    ProductCode = requestModel.ProductCode,
                    ProductItem = requestModel.ProductItem,
                    Price = requestModel.Price,
                    ProductId = id
                });
                return Ok(result > 0 ? "Updating Successful." : "Updating Failed.");
            }
        }

      
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            string query = @"UPDATE [dbo].[Tbl_Product]
   SET IsDelete = 1
 WHERE ProductId = @ProductId;";
            using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("DbConnection")))
            {
                db.Open();
                int result = db.Execute(query, new
                {
                    ProductId = id
                });
                return Ok(result > 0 ? "Deleting Successful." : "Deleting Failed.");
            }
        }
    }


    public class ProductModel
    {
        public int ProductId { get; set; }
        public string ProductCode { get; set; }
        public string ProductItem { get; set; }
        public decimal Price { get; set; }
        public bool IsDelete { get; set; }

    }

    public class ProductRequestModel
    {
        public string ProductCode { get; set; }
        public string ProductItem { get; set; }
        public decimal Price { get; set; }
    }
}
