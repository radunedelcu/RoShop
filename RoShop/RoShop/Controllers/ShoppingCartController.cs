using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RoShop.Data;
using RoShop.Helpers;
using RoShop.Models;

namespace RoShop.Controllers
{
  public class ShoppingCartController : Controller
  {
    private readonly ApplicationDbContext _context;

    public ShoppingCartController(ApplicationDbContext applicationDbContext)
    {
      _context = applicationDbContext;
    }

    [Route("index")]
    public IActionResult Index()
    {
      var cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
      if (cart == null)
      {
        ViewBag.total = new List<Item>();
      }
      else
      {
        ViewBag.cart = cart;
        ViewBag.total = cart.Sum(item => item.Product.Price * item.Quantity);
      }
      return View();
    }

    [Route("buy/{id}")]
    public IActionResult Buy(int id)
    {
      Product productModel = new Product();
      if (SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart") == null)
      {
        List<Item> cart = new List<Item>();
        cart.Add(new Item
        {
          Product = _context.Product.AsNoTracking().Join(
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
        }).ToList().Where(a => a.Id == id).SingleOrDefault(),
          Quantity = 1
        });
        SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
      }
      else
      {
        List<Item> cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
        int index = isExist(id);
        if (index != -1)
        {
          cart[index].Quantity++;
        }
        else
        {
          cart.Add(new Item
          {
            Product = _context.Product.AsNoTracking().Join(
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
        }).ToList().Where(a => a.Id == id).SingleOrDefault(),
            Quantity = 1
          });
        }
        SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
      }
      return RedirectToAction("Index");
    }


    public IActionResult Remove(int id)
    {
      List<Item> cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
      int index = isExist(id);
      cart.RemoveAt(index);
      SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
      return RedirectToAction("Index");
    }

    private int isExist(int id)
    {
      List<Item> cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
      for (int i = 0; i < cart.Count; i++)
      {
        if (cart[i].Product.Id.Equals(id))
        {
          return i;
        }
      }
      return -1;
    }
  }
}
