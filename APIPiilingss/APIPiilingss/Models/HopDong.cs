using System;
using System.Collections.Generic;

#nullable disable

namespace APIPiilingss.Models
{
    public partial class HopDong
    {
        public int MHopDong { get; set; }
        public string LoaiSanPham { get; set; }
        public string TenChuSoHuu { get; set; }
        public int IdNguoidung { get; set; }
        public int? MHoaDon { get; set; }
    }
}
