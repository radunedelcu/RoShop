using Microsoft.EntityFrameworkCore;
using RoShop.Models;

namespace RoShop.Data
{
  public class ApplicationDbContext : DbContext
  {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    public DbSet<User> User { get; set; }
    public DbSet<Role> Role { get; set; }
    public DbSet<UserProduct> UserProduct { get; set; }
    public DbSet<Product> Products { get; set; }

  }
}
