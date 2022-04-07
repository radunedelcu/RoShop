using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoShop.Data;
using RoShop.Models;
using RoShop.ViewModel;

namespace RoShop.Controllers
{
  public class AuthenticateController : Controller
  {
    private readonly ApplicationDbContext _context;

    public AuthenticateController(ApplicationDbContext applicationDbContext)
    {
      _context = applicationDbContext;
    }

    public ActionResult Register()
    {
      return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]

    public IActionResult Register(User user)
    {
      //TODO email should not be the same
      if (ModelState.IsValid && user.Password == user.ConfirmPassword)
      {
        user.Password = ComputeHash(user.Password, new SHA256CryptoServiceProvider());
        user.ConfirmPassword = ComputeHash(user.ConfirmPassword, new SHA256CryptoServiceProvider());
      }
      Role role = _context.Role.Where(a => a.Name == "user").FirstOrDefault();
      user.Role = role;
      user.IdRole = role.Id;
      _context.User.Add(user);
      _context.SaveChanges();


      return RedirectToAction("Login");

    }
    public IActionResult Login()
    {
      return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(LoginViewModel loginViewModel)
    {
      if (isloggedIn(HttpContext) == true)
        await LogOut();
      if (!ModelState.IsValid) { return RedirectToAction("Login"); }
      User user = _context.User.Where(a => a.Email == loginViewModel.Email).SingleOrDefault();
      if (user != null)
      {
        var hashpassword = ComputeHash(loginViewModel.Password, new SHA256CryptoServiceProvider());
        if (hashpassword == user.Password)
        {
          //TODO implement
          Role role = _context.Role.Where(a => a.Id == user.IdRole).SingleOrDefault();

          var userClaim = new List<Claim>()
                    {
                        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                        new Claim(ClaimTypes.Email, user.Email),
                        new Claim(ClaimTypes.Role, role.Name)
                    };
          var userIdentity = new ClaimsIdentity(userClaim, "user identity");

          var userPrinciple = new ClaimsPrincipal(new[] { userIdentity });

          await HttpContext.SignInAsync(userPrinciple);
        }
        else
        {
          ModelState.AddModelError("", "Email or password are incorrect");
        }
      }
      return View();
    }

    public bool isloggedIn(HttpContext httpcontext)
    {
      var email = httpcontext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;
      if (email != null)
        return true;
      return false;
    }

    public async Task<IActionResult> LogOut()
    {
      await HttpContext.SignOutAsync();
      return RedirectToAction("Index", "Home");
    }

    /// <summary>
    /// Hash function for encrypting password
    /// </summary>
    /// <param name="input"></param>
    /// <param name="algorithm"></param>
    /// <returns></returns>
    private string ComputeHash(string input, HashAlgorithm algorithm)
    {
      Byte[] inputBytes = Encoding.UTF8.GetBytes(input);

      Byte[] hashedBytes = algorithm.ComputeHash(inputBytes);

      return BitConverter.ToString(hashedBytes);
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
