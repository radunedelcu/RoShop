using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RoShop.Data;
using RoShop.Models;

namespace RoShop.Controllers
{
  [Authorize(Roles = "admin")]

  public class ProductController : Controller
  {
    private readonly ApplicationDbContext _context;

    public ProductController(ApplicationDbContext applicationDbContext)
    {
      _context = applicationDbContext;
    }
    public IActionResult Index()
    {
      IEnumerable<Product> objList = _context.Product;
      return View(objList);
    }

    [HttpGet]
    public IActionResult Create()
    {
      return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]

    public IActionResult Create(Product obj)
    {
      if (ModelState.IsValid)
      {
        _context.Product.Add(obj);
        _context.SaveChanges();

        //add UserProduct in database
        UserProduct userProduct = new UserProduct();
        string email = HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;
        User user = _context.User.Where(a => a.Email == email).SingleOrDefault();
        userProduct.IdUser = user.Id;
        userProduct.User = user;
        _context.UserProduct.Add(userProduct);
        _context.SaveChanges();

        obj.UserProduct = userProduct;
        obj.IdUserProduct = userProduct.IdUserProduct;
        _context.Product.Update(obj);
        _context.SaveChanges();

        return RedirectToAction("Index");
      }
      return View(obj);
    }
  }
}
