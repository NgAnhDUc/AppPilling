using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace APIsanPham.Data
{   [Table("SanPham")]
    public class SanPhamData
    {   [Key]
        public Guid MaSanPham { get; set; }
        public string TenSanPham { get; set; }
        public double DonGia { get; set; }
        public Guid? MaHh { get; set; }
        [ForeignKey("MaHh")]
        public HangHoa Ma { get; set; }
    }
}
