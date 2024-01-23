using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APIsanPham.Models
{
    public class Account
    {
        [Key]
        public string UserName { get; set; }
        public string role { get; set; }
        public string password { get; set; }
    }
}
