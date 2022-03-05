using dotNETBlog.Models;
using Microsoft.EntityFrameworkCore;

namespace dotNETBlog.Data
{
    public class applicationDbContext: DbContext
    {

        public applicationDbContext(DbContextOptions<applicationDbContext> options) :base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
