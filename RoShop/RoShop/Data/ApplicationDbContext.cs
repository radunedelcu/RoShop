using Microsoft.EntityFrameworkCore;
using RoShop.Models;

namespace RoShop.Data
{
  public class ApplicationDbContext : DbContext
  {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    public DbSet<User> Users { get; set; }
    public DbSet<User> Roles { get; set; }
  }
}
