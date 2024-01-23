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
    public class HoaDonController : ControllerBase
    {
        public static List<HoaDon> hoadons = new List<HoaDon>();
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(hoadons);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            try
            {
                var hoadon = hoadons.SingleOrDefault(sp => sp.MaHoaDon == Guid.Parse(id));
                if (hoadon == null)
                {

                    return NotFound();
                }
                return Ok(hoadon);
            }
            catch
            {

                return BadRequest();
            }
        }
        [HttpPost]
        public IActionResult Create(HoaDonVM hoadonVM)
        {
            var hoadon = new HoaDon
            {
                MaHoaDon = Guid.NewGuid(),
                NgayLapDon = DateTime.Now,
                TongTien = hoadonVM.TongTien,
                DonGia = hoadonVM.DonGia
            };
            hoadons.Add(hoadon);
            return Ok(new
            {
                Success = true,
                Data = hoadon
            });
        }
        [HttpPut("{id}")]
        public IActionResult Edit(String id, HoaDon hoadonEdit)
        {
            try
            {
                var hoadon = hoadons.SingleOrDefault(sp => sp.MaHoaDon == Guid.Parse(id));
                if (hoadon == null)
                {

                    return NotFound();
                }
                if (id != hoadon.MaHoaDon.ToString())
                {
                    return BadRequest();
                }
                //update 


                hoadon.NgayLapDon = hoadonEdit.NgayLapDon;
                hoadon.TongTien = hoadonEdit.TongTien;
                hoadon.DonGia = hoadonEdit.DonGia;
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
                var hoadon = hoadons.SingleOrDefault(sp => sp.MaHoaDon == Guid.Parse(id));
                if (hoadon == null)
                {

                    return NotFound();
                }

                //detele
                hoadons.Remove(hoadon);

                return Ok();
            }
            catch
            {

                return BadRequest();
            }


        }
    }
}
