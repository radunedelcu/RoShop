﻿using System.ComponentModel.DataAnnotations;

namespace RoShop.Models
{
  public class Role
  {
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
  }
}
