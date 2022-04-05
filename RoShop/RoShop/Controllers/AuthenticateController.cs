using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoShop.Data;
using RoShop.Models;

namespace RoShop.Controllers
{
  public class AuthenticateController : Controller
  {
    private readonly ApplicationDbContext _context;

    public AuthenticateController(ApplicationDbContext applicationDbContext)
    {
      _context = applicationDbContext;
    }

    public ActionResult RegisterView()
    {
      return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]

    public IActionResult Register(User user)
    {
      //if (!ModelState.IsValid)
      //{
      User User = new User();
      _context.User.Add(User);
      _context.SaveChanges();
      //}

      return RedirectToAction("RegisterView");

    }


    // GET: AuthenticateController
    public ActionResult Index()
    {
      var test = _context.Role.ToList();
      return View();
    }

    // GET: AuthenticateController/Details/5
    public ActionResult Details(int id)
    {
      return View();
    }

    // GET: AuthenticateController/Create
    public ActionResult Create()
    {
      return View();
    }

    // POST: AuthenticateController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(IFormCollection collection)
    {
      try
      {
        return RedirectToAction(nameof(Index));
      }
      catch
      {
        return View();
      }
    }

    // GET: AuthenticateController/Edit/5
    public ActionResult Edit(int id)
    {
      return View();
    }

    // POST: AuthenticateController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(int id, IFormCollection collection)
    {
      try
      {
        return RedirectToAction(nameof(Index));
      }
      catch
      {
        return View();
      }
    }

    // GET: AuthenticateController/Delete/5
    public ActionResult Delete(int id)
    {
      return View();
    }

    // POST: AuthenticateController/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(int id, IFormCollection collection)
    {
      try
      {
        return RedirectToAction(nameof(Index));
      }
      catch
      {
        return View();
      }
    }
  }
}
