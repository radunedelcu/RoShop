using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RoShop.Models
{
  public class User
  {
    [Key]
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public int IdRole { get; set; }
    public Role Role { get; set; }
    public ICollection<UserProduct> UserProducts { get; set; }

  }
}
