using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace APIsanPham.Data
{
    [Table("Accounts")]
    public class AccountData
    {
        [Key] 
        public string UserName { get; set; }
        public string role { get; set; }
        public string password { get; set; }
        
    }
}
