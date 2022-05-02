using System.ComponentModel.DataAnnotations;

namespace RoShop.Models
{
  public class UserWishlistProduct
  {
    [Key]
    public int IdUserWishlistProduct { get; set; }
    public int IdProduct { get; set; }
    public int IdUser { get; set; }
    public User User { get; set; }
    public Product Product { get; set; }
  }
}
