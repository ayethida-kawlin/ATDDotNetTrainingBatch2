using ATDDotNetTrainingBatch2.MVC_Blog.Database.AppDbContextModels;
using ATDDotNetTrainingBatch2.MvcApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ATDDotNetTrainingBatch2.MvcApp.Controllers
{
    public class CategoryController : Controller
    {
        private readonly AppDbContext _db;

        public CategoryController(AppDbContext db)
        {
            _db = db;
        }

        [ActionName("Index")]
        public IActionResult CategoryIndex()
        {
            return View("CategoryIndex");
        }

        [ActionName("List")]
        public async Task<IActionResult> CategoryListAsync()
        {
           var result = await _db.TblCategories.ToListAsync();
            List<CategoryViewModel> lst = result.Select(x => new CategoryViewModel
            {
                CategoryId = x.CategoryId,
                CategoryCode = x.CategoryCode,
                CategoryName = x.CategoryName,
            }).ToList();

            //List<CategoryViewModel> lst = new List<CategoryViewModel>();
            //foreach (var x in result)
            //{
            //    var item = new CategoryViewModel
            //    {
            //        CategoryId = x.CategoryId,
            //        CategoryCode = x.CategoryCode,
            //        CategoryName = x.CategoryName,

            //    };
            //    lst.Add(item);
            //}
            return Json(lst);
        }

        [ActionName("Create")]
        public IActionResult CategoryCreate() 
        {
            return View("CategoryCreate");
        }

        [HttpPost]
        [ActionName("Save")]
        public async Task<IActionResult> CategorySave(CategoryViewModel requestModel)
        {
            await _db.TblCategories.AddAsync(new TblCategory
            {
                CategoryId = Ulid.NewUlid().ToString(),
                CategoryCode = requestModel.CategoryCode,
                CategoryName = requestModel.CategoryName,
            });

            var result = await _db.SaveChangesAsync();
            var model = new CategoryViewResponseModel
            {
                IsSuccess = result > 0,
                Message = result > 0 ? "Saving Successful" : "Saving Failed"
            };
            return Json(model);
        }

        [HttpGet]
        [ActionName("Edit")]
        public async Task<IActionResult> CategoryEdit(string id)
        {
            var item = await _db.TblCategories.FirstOrDefaultAsync(x => x.CategoryId == id);
            if (item is null)
            {
                return RedirectToAction("Index");
            }
            var model = new CategoryEditRequestModel
            {
                CategoryId = item.CategoryId,
                CategoryCode = item.CategoryCode,
                CategoryName = item.CategoryName
            };

            return Json(model);
        }

    }

    public class CategoryViewModel
    {
        public string CategoryId { get; set; }
        public string CategoryCode { get; set; } = string.Empty;
        public string CategoryName { get; set; } = string.Empty;
    }

    public class CategoryViewResponseModel
    {
        public bool IsSuccess { get; set; } 
        public string Message { get; set; }
        
    }

    public class CategoryEditRequestModel
    {
        public string CategoryId { get; set; }
        public string CategoryCode { get; set; }
        public string CategoryName { get; set; }
    }
}
