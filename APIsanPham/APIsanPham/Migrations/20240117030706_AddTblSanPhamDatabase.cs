using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace APIsanPham.Migrations
{
    public partial class AddTblSanPhamDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "HangHoaMaHh",
                table: "HangHoa",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SanPham",
                columns: table => new
                {
                    MaSanPham = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenSanPham = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DonGia = table.Column<double>(type: "float", nullable: false),
                    MaHh = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SanPham", x => x.MaSanPham);
                    table.ForeignKey(
                        name: "FK_SanPham_HangHoa_MaHh",
                        column: x => x.MaHh,
                        principalTable: "HangHoa",
                        principalColumn: "MaHh",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HangHoa_HangHoaMaHh",
                table: "HangHoa",
                column: "HangHoaMaHh");

            migrationBuilder.CreateIndex(
                name: "IX_SanPham_MaHh",
                table: "SanPham",
                column: "MaHh");

            migrationBuilder.AddForeignKey(
                name: "FK_HangHoa_HangHoa_HangHoaMaHh",
                table: "HangHoa",
                column: "HangHoaMaHh",
                principalTable: "HangHoa",
                principalColumn: "MaHh",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HangHoa_HangHoa_HangHoaMaHh",
                table: "HangHoa");

            migrationBuilder.DropTable(
                name: "SanPham");

            migrationBuilder.DropIndex(
                name: "IX_HangHoa_HangHoaMaHh",
                table: "HangHoa");

            migrationBuilder.DropColumn(
                name: "HangHoaMaHh",
                table: "HangHoa");
        }
    }
}
