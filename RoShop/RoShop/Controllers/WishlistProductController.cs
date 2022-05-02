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
      IEnumerable<Product> objList = _context.Product.AsNoTracking().Join(
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
        }).ToList();

      return View(objList);
    }

    [HttpGet]
    public IActionResult AddToWishlist(int? id)
    {

      {
        if (id == null || id == 0)
        {
          return NotFound();
        }
        var obj = _context.Product.AsNoTracking().Join(
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
          }).ToList().Where(a => a.Id == id).SingleOrDefault();

        return View();
      }
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
      UserWishlistProduct wishlistProduct = new UserWishlistProduct();
      string email = HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;
      User user = _context.User.Where(a => a.Email == email).SingleOrDefault();
      wishlistProduct.IdProduct = obj.Id;
      wishlistProduct.IdUser = user.Id;
      wishlistProduct.User = user;
      wishlistProduct.Product = obj;
      _context.UserWishlistProduct.Add(wishlistProduct);
      _context.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}
