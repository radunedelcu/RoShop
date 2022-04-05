using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RoShop.Models
{
  public class UserProduct

  {

    public UserProduct()
    {
      Products = new List<Product>();
    }
    [Key]
    public int IdUserProduct { get; set; }
    public int IdUser { get; set; }
    public User User { get; set; }
    public ICollection<Product> Products { get; set; }

  }
}
