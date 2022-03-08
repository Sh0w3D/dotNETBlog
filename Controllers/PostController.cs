using Microsoft.AspNetCore.Mvc;
using dotNETBlog.Data;
using dotNETBlog.Models;

namespace dotNETBlog.Controllers
{
    public class PostController : Controller
    {

        private readonly applicationDbContext _db;

        public PostController(applicationDbContext db) { _db = db; }


        public IActionResult Index()
        {
            IEnumerable<Post> dbPosts = _db.Posts;

            return View(dbPosts);

        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Post post)
        {
            if (ModelState.IsValid)
            {
                _db.Posts.Add(post);
                _db.SaveChanges();
                TempData["success"] = "Post added successfully!";
                return RedirectToAction("Index");
            }

            return View(post);
        }
    }
}
