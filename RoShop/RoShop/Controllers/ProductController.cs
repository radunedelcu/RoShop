using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RoShop.Data;
using RoShop.Models;
using RoShop.ViewModel;

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
      IEnumerable<Product> objList = _context.Product.AsNoTracking().Join(
        _context.ProductFile,
        u => u.IdProductFile,
        z => z.Id,
        (u, z) => new Product()
        {
          Description = u.Description,
          Price = u.Price,
          Name = u.Name,
          ProductFile = z
        }).ToList();
      return View(objList);
    }

    [HttpGet]
    public IActionResult Create()
    {
      return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]

    public IActionResult Create(ProductImageViewModel productImageViewModel)
    {

      if (ModelState.IsValid)
      {
        var image = new ProductFile();

        if (productImageViewModel.Image != null)
        {
          if (productImageViewModel.Image.Length > 0)
          {
            //Getting FileName
            var fileName = Path.GetFileName(productImageViewModel.Image.FileName);
            //Getting FileExtension
            var fileExtension = Path.GetExtension(fileName);
            //FileName + FileExtension
            var newFileName = string.Concat(Convert.ToString(Guid.NewGuid()), fileExtension);
            image.Name = newFileName;
            image.FileType = fileExtension;
            using (var target = new MemoryStream())
            {
              productImageViewModel.Image.CopyTo(target);
              image.DataFiles = target.ToArray();
            }

            _context.ProductFile.Add(image);
            _context.SaveChanges();
          }
        }

        Product obj = new Product();
        obj.Name = productImageViewModel.Name;
        obj.Price = productImageViewModel.Price;
        obj.Description = productImageViewModel.Description;
        obj.IdProductFile = image.Id;
        obj.ProductFile = image;
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
      return View();
    }
  }
}
