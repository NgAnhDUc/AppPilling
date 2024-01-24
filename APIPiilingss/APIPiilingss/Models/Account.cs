using System;
using System.Collections.Generic;

#nullable disable

namespace APIPiilingss.Models
{
    public partial class Account
    {
        public int Cmnd { get; set; }
        public int? IdNguoidung { get; set; }
        public int? MaNv { get; set; }
        public string Passwordd { get; set; }
        public int? Rolee { get; set; }
        public string Ten { get; set; }
        public int? Sdt { get; set; }
        public string Email { get; set; }
        public string GioiTinh { get; set; }
        public string Diachi { get; set; }
    }
}
