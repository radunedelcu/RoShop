using System;
using System.ComponentModel.DataAnnotations;

namespace RoShop.Models
{
  public class Comment
  {
    public Comment()
    {
      CreatedOn = DateTime.Now;
    }
    [Key]
    public int Id { get; set; }
    public string Content { get; set; }
    public string UserEmail { get; set; }
    public Product Product { get; set; }
    public DateTime? CreatedOn { get; set; }
  }
}
