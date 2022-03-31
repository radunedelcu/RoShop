using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoShop.Models
{
    public class Role
    {
        public int Id { get; set; }
        public string NormalUser { get; set; }
        public string Administrator { get; set; }
    }
}
