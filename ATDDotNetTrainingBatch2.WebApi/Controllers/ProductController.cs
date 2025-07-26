using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ATDDotNetTrainingBatch2.WebApi.Controllers
{
    // api/product
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            //process
            //data
            return Ok("GET");
        }

        [HttpPost]
        public IActionResult Create()
        {
            //process
            //data
            return Ok("CREATE");
        }

        [HttpPut]
        public IActionResult Upset()
        {
            //process
            //data
            return Ok("UPSET");
        }

        [HttpPatch]
        public IActionResult Update()
        {
            //process
            //data
            return Ok("UPDATE");
        }

        [HttpDelete]
        public IActionResult Delete()
        {
            //process
            //data
            return Ok("DELETE");
        }
    }
}
