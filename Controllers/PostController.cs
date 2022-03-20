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

        public IActionResult Edit(string? id)
        {
            if (id is null)
            {
                return NotFound();
            }

            var postFromDb = _db.Posts.Find(id);

            if (postFromDb is null)
            {
                return NotFound();
            }
            return View(postFromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Post post)
        {
            if (ModelState.IsValid)
            {
                _db.Posts.Update(post);
                _db.SaveChanges();
                TempData["success"] = "Post successfully updated!";
                return RedirectToAction("Index");
            }

            return View(post);
        }

        public IActionResult Delete(string? id)
        {
            if (id is null)
            {
                return NotFound();
            }

            var postFromDb = _db.Posts.Find(id);

            if (postFromDb is null)
            {
                return NotFound();
            }
            return View(postFromDb);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(string? id)
        {
            var postFromDb = _db.Posts.Find(id);
            if (postFromDb is null) return NotFound();

            _db.Posts.Remove(postFromDb);
            _db.SaveChanges();
            TempData["success"] = "User removed successfully";
            return RedirectToAction("Index");
        }
    }
}
