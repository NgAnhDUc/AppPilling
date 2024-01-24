using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIsanPham.Models
{
    
    public class KhachHangVM

    {
        
        public string TenKhachHang { get; set; }
        public string DiaChi { get; set; }
        public double SDT { get; set; }
        public string Email { get; set; }
        public int CCCD { get; set; }

    }
    public class KhachHang:KhachHangVM
    {
        public Guid MaKhachHang { get; set; }
    }
}
