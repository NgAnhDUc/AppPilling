using System;
using System.Collections.Generic;

#nullable disable

namespace APIPiilingss.Models
{
    public partial class TienNuoc
    {
        public TienNuoc()
        {
            Hoadons = new HashSet<Hoadon>();
        }

        public int MNuoc { get; set; }
        public decimal? Dongia { get; set; }
        public int? Sonuoc { get; set; }
        public int? Thang { get; set; }
        public int? Nam { get; set; }

        public virtual ICollection<Hoadon> Hoadons { get; set; }
    }
}
