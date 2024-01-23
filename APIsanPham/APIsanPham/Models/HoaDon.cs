using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIsanPham.Models
{
    public class HoaDonVM
    {
        public DateTime NgayLapDon { get; set; }
        public double TongTien { get; set; }
        public double DonGia { get; set; }

    }
    public class HoaDon : HoaDonVM
    {
         public Guid MaHoaDon { get; set; }
    }
}
