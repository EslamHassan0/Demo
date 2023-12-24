using Microsoft.EntityFrameworkCore;

namespace Demo.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<Product> Products { get; set; }
    }
}
