using dotNETBlog.Data;
using dotNETBlog.Models;
using Microsoft.AspNetCore.Mvc;

namespace dotNETBlog.Controllers
{
    public class CategoryController : Controller
    {
        private readonly applicationDbContext _db;
        public CategoryController(applicationDbContext db) { _db = db; }
        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryList = _db.Categories;
            return View(objCategoryList);
        }
    }
}
