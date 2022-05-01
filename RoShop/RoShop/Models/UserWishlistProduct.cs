using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RoShop.Models
{
  public class UserWishlistProduct
  {
    public UserWishlistProduct()
    {
      Products = new List<Product>();
    }
    [Key]
    public int IdUserWishlistProduct { get; set; }
    public int IdProduct { get; set; }
    public int IdUser { get; set; }
    public User User { get; set; }
    public ICollection<Product> Products { get; set; }
  }
}
