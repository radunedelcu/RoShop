using System.ComponentModel.DataAnnotations;

namespace RoShop.ViewModel
{
  public class LoginViewModel
  {
    [Required]
    [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "This is not a valid mail")]
    [Display(Name = "Email")]
    public string Email { get; set; }

    [Required]
    [Display(Name = "Password")]
    public string Password { get; set; }
  }
}
