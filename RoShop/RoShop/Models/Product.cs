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
    public UserProduct UserProduct { get; set; }
    public int IdUserProduct { get; set; }
  }
}
