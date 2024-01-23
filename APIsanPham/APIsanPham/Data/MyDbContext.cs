using APIsanPham.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIsanPham.Data
{
    public class MyDbContext:DbContext
    {
        public MyDbContext(DbContextOptions options):base(options)
        {
        }
        #region DbSet
        public DbSet<HangHoa> HangHoas { get; set; }
        public DbSet<SanPhamData> SanPhamDatas { get; set; }
        public DbSet<AccountData> AccountDatas { get; set;}
        #endregion
    }
}
