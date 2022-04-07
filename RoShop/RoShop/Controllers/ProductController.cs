using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace RoShop.Controllers
{
  [Authorize(Roles = "user")]

  public class ProductController : Controller
  {
    public IActionResult Index()
    {
      return View();
    }
  }
}
