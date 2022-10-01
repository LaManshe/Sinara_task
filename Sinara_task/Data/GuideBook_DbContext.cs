using Microsoft.EntityFrameworkCore;
using Sinara_task.Models;

namespace Sinara_task.Data
{
    public class GuideBook_DbContext : DbContext
    {
        public GuideBook_DbContext(DbContextOptions<GuideBook_DbContext> options)
        : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
    }
}
