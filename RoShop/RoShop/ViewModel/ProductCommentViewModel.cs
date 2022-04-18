using System.Collections.Generic;
using RoShop.Models;

namespace RoShop.ViewModel
{
  public class ProductCommentViewModel
  {
    public Product Product { get; set; }
    public ICollection<Comment> Comments { get; set; }
  }
}
