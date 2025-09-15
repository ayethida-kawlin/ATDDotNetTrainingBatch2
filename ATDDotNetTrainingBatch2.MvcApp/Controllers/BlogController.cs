using ATDDotNetTrainingBatch2.MVC_Blog.Database.AppDbContextModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ATDDotNetTrainingBatch2.MvcApp.Controllers
{
    //https://localhost:3000/Blog/BlogIndex
    //https://localhost:3000/Blog/Index
    public class BlogController : Controller
    {
        private readonly AppDbContext _db;

        public BlogController(AppDbContext db)
        {
            _db = db;
        }

        [ActionName("Index")]
        public async Task<IActionResult> BlogIndex()
        {
           var lst = await _db.TblBlogs.ToListAsync();
            return View("BlogIndex", lst);
        }

        [ActionName("Generate")]
        public async Task<IActionResult> BlogGenerate() 
        {
            for (int i = 0; i < 20; i++)
            {
                int rowNo = i + 1;
                var blog = new TblBlog
                {
                    BlogId = Ulid.NewUlid().ToString(),
                    BlogTitle = "My first blog " + rowNo,
                    BlogAuthor = "Admin " + rowNo,
                    BlogContent = " This is my first blog content " + rowNo,
                    CreatedBy = "Admin",
                    CreatedDateTime = DateTime.Now,
                    DeleteFlag = false
                };
                _db.TblBlogs.Add(blog);
                await _db.SaveChangesAsync();
            }
            return RedirectToAction("Index");
            
        }
    }
}
