using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RoShop.Data;
using RoShop.Models;

namespace RoShop.Controllers
{
  public class WishlistProductController : Controller
  {
    private readonly ApplicationDbContext _context;
    public WishlistProductController(ApplicationDbContext applicationDbContext)
    {
      _context = applicationDbContext;
    }

    public IActionResult Index()
    {
      string email = HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;
      User user = _context.User.Where(a => a.Email == email).SingleOrDefault();
      List<UserWishlistProduct> userWishlistProducts = _context.UserWishlistProduct.Where(a => a.IdUser == user.Id).ToList();

      List<Product> products = new List<Product>();
      foreach (var wish in userWishlistProducts)
      {
        Product product = _context.Product.AsNoTracking().Where(a => a.Id == wish.IdProduct).Join(
       _context.ProductFile,
       u => u.IdProductFile,
       z => z.Id,
       (u, z) => new Product()
       {
         Id = u.Id,
         Description = u.Description,
         Price = u.Price,
         Name = u.Name,
         ProductFile = z
       }).SingleOrDefault();
        products.Add(product);
      }
      return View(products);
    }

    [HttpGet]
    public IActionResult AddProductToWishlist(int? id)
    {
      if (id == null || id == 0)
      {
        return NotFound();
      }
      var obj = _context.Product.Where(a => a.Id == id).SingleOrDefault();
      if (obj == null)
      {
        return NotFound();
      }
      if (itemExist(obj) != true)
      {

        UserWishlistProduct wishlistProduct = new UserWishlistProduct();
        string email = HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;
        User user = _context.User.Where(a => a.Email == email).SingleOrDefault();
        wishlistProduct.IdProduct = obj.Id;
        wishlistProduct.IdUser = user.Id;
        wishlistProduct.User = user;
        wishlistProduct.Product = obj;
        _context.UserWishlistProduct.Add(wishlistProduct);
        _context.SaveChanges();
      }
      return RedirectToAction("Index");
    }

    public bool itemExist(Product product)
    {
      var obj = _context.UserWishlistProduct.Where(a => a.IdProduct == product.Id).SingleOrDefault();
      if (obj != null)
        return true;
      return false;
    }

    public IActionResult Remove(int id)
    {
      var obj = _context.UserWishlistProduct.Where(a => a.IdProduct == id).SingleOrDefault();
      if (obj == null)
      {
        return NotFound();
      }
      _context.UserWishlistProduct.Remove(obj);
      _context.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}
