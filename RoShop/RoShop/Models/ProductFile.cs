using System;
using System.ComponentModel.DataAnnotations;

namespace RoShop.Models
{
  public class ProductFile
  {
    public ProductFile()
    {
      CreatedOn = DateTime.Now;
    }
    [Key]
    public int Id { get; set; }
    [MaxLength(100)]
    public string Name { get; set; }
    [MaxLength(100)]
    public string FileType { get; set; }
    [MaxLength]
    public byte[] DataFiles { get; set; }
    public DateTime? CreatedOn { get; set; }
  }
}
