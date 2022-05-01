using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RoShop.Models
{
  public class Product
  {
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public int Price { get; set; }
    public string Description { get; set; }
    public string Colour { get; set; }
    public string Material { get; set; }
    public UserProduct UserProduct { get; set; }
    public int IdUserProduct { get; set; }
    public UserWishlistProduct UserWishlistProduct { get; set; }
    public int IdUserWishlistProduct { get; set; }
    public int IdProductFile { get; set; }

    public ProductFile ProductFile { get; set; }

    public ICollection<Comment> Comments { get; set; }
  }
}
