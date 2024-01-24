using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIsanPham.Models
{
    public class NhanVienVM
    {
        public string TenNV { get; set; }
        public bool GioiTinh { get; set; }
        public string DiaChi { get; set; }
        public double SDT { get; set; }
        public string Email { get; set; }
        public int CCCD { get; set; }
    }
    public class NhanVien : NhanVienVM
    {
        public Guid MaNV { get; set; }
    }
}
