using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIsanPham.Models
{
    public class HopDongVM
    {
        public string DienSinhHoat { get; set; }
        public string NuocSach { get; set; }
        public string TenChuSoHuu { get; set; }
        public double DonGia { get; set; }

    }
    public class HopDong : HopDongVM
    {
        public Guid MaHopDong { get; set; }
    }
}
