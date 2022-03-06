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
            if(user.Email == user.Nick)
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
    }
}
