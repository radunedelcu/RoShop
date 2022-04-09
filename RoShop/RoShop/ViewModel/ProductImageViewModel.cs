using Microsoft.AspNetCore.Http;

namespace RoShop.ViewModel
{
  public class ProductImageViewModel
  {
    public string Name { get; set; }
    public int Price { get; set; }
    public string Description { get; set; }
    public IFormFile Image { get; set; }

  }
}
