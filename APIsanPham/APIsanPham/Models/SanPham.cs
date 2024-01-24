using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIsanPham.Models
{
    public class SanPhamVM
    {
        public Guid MaSanPham { get; set; }
        public string TenSanPham { get; set; }
        public double DonGia { get; set; }
    }
   
}
