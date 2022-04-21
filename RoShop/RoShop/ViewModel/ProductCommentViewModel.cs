using System.ComponentModel.DataAnnotations;
using RoShop.Models;

namespace RoShop.ViewModel
{
  public class ProductCommentViewModel
  {
    [Required]
    public string Content { get; set; }
    public int IdProduct { get; set; }
    public Product Product { get; set; }
  }
}
