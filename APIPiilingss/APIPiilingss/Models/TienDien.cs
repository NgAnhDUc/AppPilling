using System;
using System.Collections.Generic;

#nullable disable

namespace APIPiilingss.Models
{
    public partial class TienDien
    {
        public TienDien()
        {
            Hoadons = new HashSet<Hoadon>();
        }

        public int MDien { get; set; }
        public decimal? Dongia { get; set; }
        public int? SoDien { get; set; }
        public int? Thang { get; set; }
        public int? Nam { get; set; }

        public virtual ICollection<Hoadon> Hoadons { get; set; }
    }
}
