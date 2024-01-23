using APIsanPham.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIsanPham.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NhanVienController : ControllerBase
    {
        public static List<NhanVien> nhanviens = new List<NhanVien>();
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(nhanviens);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            try
            {
                var nhanvien = nhanviens.SingleOrDefault(sp => sp.MaNV == Guid.Parse(id));
                if (nhanvien == null)
                {

                    return NotFound();
                }
                return Ok(nhanvien);
            }
            catch
            {

                return BadRequest();
            }
        }
        [HttpPost]
        public IActionResult Create(NhanVienVM nhanvienVM)
        {
            var nhanvien = new NhanVien
            {
                MaNV = Guid.NewGuid(),
                TenNV = nhanvienVM.TenNV,
                GioiTinh = true,
                DiaChi = nhanvienVM.DiaChi,
                SDT = nhanvienVM.SDT,
                Email = nhanvienVM.Email,
                CCCD = nhanvienVM.CCCD
            };
            nhanviens.Add(nhanvien);
            return Ok(new
            {
                Success = true,
                Data = nhanvien
            });
        }
        [HttpPut("{id}")]
        public IActionResult Edit(String id, NhanVien nhanvienEdit)
        {
            try
            {
                var nhanvien = nhanviens.SingleOrDefault(sp => sp.MaNV == Guid.Parse(id));
                if (nhanvien == null)
                {

                    return NotFound();
                }
                if (id != nhanvien.MaNV.ToString())
                {
                    return BadRequest();
                }
                //update 
                nhanvien.TenNV = nhanvienEdit.TenNV;
                nhanvien.GioiTinh = false;
                nhanvien.DiaChi = nhanvienEdit.DiaChi;
                nhanvien.SDT = nhanvienEdit.SDT;
                nhanvien.Email = nhanvienEdit.Email;
                nhanvien.CCCD = nhanvienEdit.CCCD;
                return Ok();
            }
            catch
            {

                return BadRequest();
            }

        }
        [HttpDelete("{id}")]
        public IActionResult Remove(String id)
        {
            try
            {
                var nhanvien = nhanviens.SingleOrDefault(sp => sp.MaNV == Guid.Parse(id));
                if (nhanvien == null)
                {

                    return NotFound();
                }

                //detele
                nhanviens.Remove(nhanvien);

                return Ok();
            }
            catch
            {

                return BadRequest();
            }


        }
    
}
}
