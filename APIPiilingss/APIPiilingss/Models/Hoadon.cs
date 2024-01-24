using System;
using System.Collections.Generic;

#nullable disable

namespace APIPiilingss.Models
{
    public partial class Hoadon
    {
        public int MHoaDon { get; set; }
        public int? MHopDong { get; set; }
        public int? MDien { get; set; }
        public int? MNuoc { get; set; }
        public double tongtien { get; set;}
        public virtual TienDien MDienNavigation { get; set; }
        public virtual TienNuoc MNuocNavigation { get; set; }
    }
}
