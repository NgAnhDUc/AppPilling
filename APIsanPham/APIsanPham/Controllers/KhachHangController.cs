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
    public class KhachHangController : ControllerBase
    {
        public static List<KhachHang> khachhangs = new List<KhachHang>();
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(khachhangs);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            try
            {
                var khachHang = khachhangs.SingleOrDefault(sp => sp.MaKhachHang == Guid.Parse(id));
                if (khachHang == null)
                {

                    return NotFound();
                }
                return Ok(khachHang);
            }
            catch
            {

                return BadRequest();
            }
        }
        [HttpPost]
        public IActionResult Create(KhachHangVM khachHangVM)
        {
            var khachhang = new KhachHang
            {
                MaKhachHang = Guid.NewGuid(),
                TenKhachHang = khachHangVM.TenKhachHang,
                DiaChi = khachHangVM.DiaChi,
                SDT= khachHangVM.SDT,
                Email = khachHangVM.Email,
                CCCD= khachHangVM.CCCD
            };
            khachhangs.Add(khachhang);
            return Ok(new
            {
                Success = true,
                Data = khachhang
            });
        }
        [HttpPut("{id}")]
        public IActionResult Edit(String id, KhachHang khachhangEdit)
        {
            try
            {
                var khachhang = khachhangs.SingleOrDefault(sp => sp.MaKhachHang == Guid.Parse(id));
                if (khachhang == null)
                {

                    return NotFound();
                }
                if (id != khachhang.MaKhachHang.ToString())
                {
                    return BadRequest();
                }
                //update 
                khachhang.TenKhachHang = khachhangEdit.TenKhachHang;
                khachhang.DiaChi = khachhangEdit.DiaChi;
                khachhang.SDT = khachhangEdit.SDT;
                khachhang.Email = khachhangEdit.Email;
                khachhang.CCCD = khachhangEdit.CCCD;
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
                var khachhang = khachhangs.SingleOrDefault(sp => sp.MaKhachHang == Guid.Parse(id));
                if (khachhang == null)
                {

                    return NotFound();
                }

                //detele
                khachhangs.Remove(khachhang);

                return Ok();
            }
            catch
            {

                return BadRequest();
            }


        }
    }
}
