using System;
using System.Collections.Generic;

#nullable disable

namespace APIPiilingss.Models
{
    public partial class LapDat
    {
        public int MaNv { get; set; }
        public int? MaSp { get; set; }
        public DateTime? Ngaylapdat { get; set; }
        public string TenKh { get; set; }
    }
}
