﻿// <auto-generated />
using System;
using APIsanPham.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace APIsanPham.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20240117030706_AddTblSanPhamDatabase")]
    partial class AddTblSanPhamDatabase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("APIsanPham.Data.HangHoa", b =>
                {
                    b.Property<Guid>("MaHh")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("DonGia")
                        .HasColumnType("float");

                    b.Property<byte>("GiamGia")
                        .HasColumnType("tinyint");

                    b.Property<Guid?>("HangHoaMaHh")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("MoTa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenHh")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("MaHh");

                    b.HasIndex("HangHoaMaHh");

                    b.ToTable("HangHoa");
                });

            modelBuilder.Entity("APIsanPham.Data.SanPhamData", b =>
                {
                    b.Property<Guid>("MaSanPham")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("DonGia")
                        .HasColumnType("float");

                    b.Property<Guid?>("MaHh")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("TenSanPham")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaSanPham");

                    b.HasIndex("MaHh");

                    b.ToTable("SanPham");
                });

            modelBuilder.Entity("APIsanPham.Data.HangHoa", b =>
                {
                    b.HasOne("APIsanPham.Data.HangHoa", null)
                        .WithMany("HangHoas")
                        .HasForeignKey("HangHoaMaHh");
                });

            modelBuilder.Entity("APIsanPham.Data.SanPhamData", b =>
                {
                    b.HasOne("APIsanPham.Data.HangHoa", "Ma")
                        .WithMany()
                        .HasForeignKey("MaHh");

                    b.Navigation("Ma");
                });

            modelBuilder.Entity("APIsanPham.Data.HangHoa", b =>
                {
                    b.Navigation("HangHoas");
                });
#pragma warning restore 612, 618
        }
    }
}
