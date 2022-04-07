using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RoShop.Models
{
  public class User
  {
    [Key]
    public int Id { get; set; }
    [Required]
    [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Name must contain just letters")]
    [Display(Name = "First Name")]
    public string FirstName { get; set; }
    [Required]
    [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Name must contain just letters")]
    [Display(Name = "Second Name")]
    public string LastName { get; set; }
    [Required]
    [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "This is not a valid mail")]
    [Display(Name = "Email")]
    public string Email { get; set; }
    [Required]
    //[StringLength(20, MinimumLength = 5, ErrorMessage = "Password must have more then 5 characters")]
    [Display(Name = "Password")]
    public string Password { get; set; }
    [Required]
    [Compare("Password", ErrorMessage = "Confirm password doesn't match, type again !")]
    [Display(Name = "Confirm Password")]
    public string ConfirmPassword { get; set; }
    public int IdRole { get; set; }
    public Role Role { get; set; }
    public ICollection<UserProduct> UserProducts { get; set; }

  }
}
