using Microsoft.AspNetCore.Mvc;
using dotNETBlog.Data;
using dotNETBlog.Models;

namespace dotNETBlog.Controllers
{
    public class UserController : Controller
    {

        private readonly applicationDbContext _db;

        public UserController(applicationDbContext db) { _db = db; }


        public IActionResult Index()
        {
            IEnumerable<User> dbUserList = _db.Users;

            return View(dbUserList);
        }

        public IActionResult Create() { return View(); }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(User user)
        {
            if (user.Email == user.Nick)
            {
                ModelState.AddModelError("nick", "User name can't be the same as email!");
            }

            if (ModelState.IsValid)
            {
                _db.Users.Add(user);
                _db.SaveChanges();
                TempData["success"] = "User created successfully!";
                return RedirectToAction("Index");
            }

            return View(user);
        }

        public IActionResult Edit(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userFromDb = _db.Users.Find(id);

            if (userFromDb == null)
            {
                return NotFound();
            }

            return View(userFromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                _db.Users.Update(user);
                _db.SaveChanges();
                TempData["success"] = "User updated successfully!";
                return RedirectToAction("Index");
            }

            return View(user);
        }

        public IActionResult Delete(string? id)
        {
            if (id == null || id == 0.ToString())
            {
                return NotFound();
            }

            var userFromDb = _db.Users.Find(id);

            if (userFromDb == null)
            {
                return NotFound();
            }

            return View(userFromDb);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(string? id)
        {

            var userFromDb = _db.Users.Find(id);

            if (userFromDb == null) return NotFound();

            _db.Users.Remove(userFromDb);
            _db.SaveChanges();
            TempData["success"] = "User removed successfully";
            return RedirectToAction("Index");

        }
    }
}
