using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace APIPiilingss.Models
{
    public partial class APIDatabaseContext : DbContext
    {
        public APIDatabaseContext()
        {
        }

        public APIDatabaseContext(DbContextOptions<APIDatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Hoadon> Hoadons { get; set; }
        public virtual DbSet<HopDong> HopDongs { get; set; }
        public virtual DbSet<LapDat> LapDats { get; set; }
        public virtual DbSet<SanPham> SanPhams { get; set; }
        public virtual DbSet<TienDien> TienDiens { get; set; }
        public virtual DbSet<TienNuoc> TienNuocs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=LATOP-OFQUOCEM\\SQLEXPRESS;Initial Catalog=APIDatabase;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(e => e.Cmnd)
                    .HasName("PK__Account__F67C8D0A8541765B");

                entity.ToTable("Account");

                entity.Property(e => e.Cmnd)
                    .ValueGeneratedNever()
                    .HasColumnName("CMND");

                entity.Property(e => e.Diachi)
                    .HasMaxLength(50)
                    .HasColumnName("diachi");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.GioiTinh).HasMaxLength(50);

                entity.Property(e => e.IdNguoidung).HasColumnName("id_nguoidung");

                entity.Property(e => e.MaNv).HasColumnName("MaNV");

                entity.Property(e => e.Passwordd).HasMaxLength(50);

                entity.Property(e => e.Sdt).HasColumnName("SDT");

                entity.Property(e => e.Ten).HasMaxLength(50);
            });

            modelBuilder.Entity<Hoadon>(entity =>
            {
                entity.HasKey(e => e.MHoaDon)
                    .HasName("PK__Hoadon__57EF14801C442004");

                entity.ToTable("Hoadon");

                entity.Property(e => e.MHoaDon)
                    .ValueGeneratedNever()
                    .HasColumnName("mHoaDon");

                entity.Property(e => e.MDien).HasColumnName("mDien");

                entity.Property(e => e.MHopDong).HasColumnName("mHopDong");

                entity.Property(e => e.MNuoc).HasColumnName("mNuoc");

                entity.Property(e => e.tongtien).HasColumnName("tongtien");
                entity.HasOne(d => d.MDienNavigation)
                    .WithMany(p => p.Hoadons)
                    .HasForeignKey(d => d.MDien)
                    .HasConstraintName("FK__Hoadon__mDien__286302EC");

                entity.HasOne(d => d.MNuocNavigation)
                    .WithMany(p => p.Hoadons)
                    .HasForeignKey(d => d.MNuoc)
                    .HasConstraintName("FK__Hoadon__mNuoc__29572725");
            });

            modelBuilder.Entity<HopDong>(entity =>
            {
                entity.HasKey(e => new { e.MHopDong, e.IdNguoidung })
                    .HasName("PK__HopDong__E8284FE9139012F8");

                entity.ToTable("HopDong");

                entity.Property(e => e.MHopDong).HasColumnName("mHopDong");

                entity.Property(e => e.IdNguoidung).HasColumnName("id_nguoidung");

                entity.Property(e => e.LoaiSanPham).HasMaxLength(50);

                entity.Property(e => e.MHoaDon).HasColumnName("mHoaDon");

                entity.Property(e => e.TenChuSoHuu).HasMaxLength(50);
            });

            modelBuilder.Entity<LapDat>(entity =>
            {
                entity.HasKey(e => e.MaNv)
                    .HasName("PK__LapDat__2725D70AFA74C77E");

                entity.ToTable("LapDat");

                entity.Property(e => e.MaNv)
                    .ValueGeneratedNever()
                    .HasColumnName("MaNV");

                entity.Property(e => e.MaSp).HasColumnName("MaSP");

                entity.Property(e => e.Ngaylapdat)
                    .HasColumnType("datetime")
                    .HasColumnName("ngaylapdat");

                entity.Property(e => e.TenKh).HasMaxLength(50);
            });

            modelBuilder.Entity<SanPham>(entity =>
            {
                entity.HasKey(e => e.MaSp)
                    .HasName("PK__SanPham__2725081C68EA303B");

                entity.ToTable("SanPham");

                entity.Property(e => e.MaSp)
                    .ValueGeneratedNever()
                    .HasColumnName("MaSP");

                entity.Property(e => e.LoaiSanPham).HasMaxLength(50);

                entity.Property(e => e.TenSp)
                    .HasMaxLength(50)
                    .HasColumnName("TenSP");
            });

            modelBuilder.Entity<TienDien>(entity =>
            {
                entity.HasKey(e => e.MDien)
                    .HasName("PK__TienDien__0205364C731889D3");

                entity.ToTable("TienDien");

                entity.Property(e => e.MDien)
                    .ValueGeneratedNever()
                    .HasColumnName("mDien");

                entity.Property(e => e.Dongia)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("dongia");

                entity.Property(e => e.Nam).HasColumnName("nam");

                entity.Property(e => e.SoDien).HasColumnName("soDien");

                entity.Property(e => e.Thang).HasColumnName("thang");
            });

            modelBuilder.Entity<TienNuoc>(entity =>
            {
                entity.HasKey(e => e.MNuoc)
                    .HasName("PK__TienNuoc__ED3F5BFC7CE345D6");

                entity.ToTable("TienNuoc");

                entity.Property(e => e.MNuoc)
                    .ValueGeneratedNever()
                    .HasColumnName("mNuoc");

                entity.Property(e => e.Dongia)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("dongia");

                entity.Property(e => e.Nam).HasColumnName("nam");

                entity.Property(e => e.Sonuoc).HasColumnName("SONUOC");

                entity.Property(e => e.Thang).HasColumnName("thang");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
