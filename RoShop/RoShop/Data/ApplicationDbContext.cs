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
    public DbSet<Product> Product { get; set; }

    public DbSet<ProductFile> ProductFile { get; set; }
    public DbSet<Comment> Comment { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<User>().HasMany(e => e.UserProducts).WithOne(e => e.User).OnDelete(DeleteBehavior.NoAction);
      modelBuilder.Entity<UserProduct>().HasMany(e => e.Products).WithOne(e => e.UserProduct).OnDelete(DeleteBehavior.NoAction);
      modelBuilder.Entity<Product>().HasMany(e => e.Comments).WithOne(e => e.Product).OnDelete(DeleteBehavior.NoAction);

      modelBuilder.Entity<User>().ToTable("User");
      modelBuilder.Entity<Role>().ToTable("Role");
      modelBuilder.Entity<UserProduct>().ToTable("UserProduct");
      modelBuilder.Entity<Product>().ToTable("Product");
      modelBuilder.Entity<ProductFile>().ToTable("ProductFile");
      modelBuilder.Entity<Comment>().ToTable("Comment");

    }
  }
}
