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
    public class HopDongController : ControllerBase
    {
        public static List<HopDong> hopdongs = new List<HopDong>();
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(hopdongs);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            try
            {
                var hopdong = hopdongs.SingleOrDefault(sp => sp.MaHopDong == Guid.Parse(id));
                if (hopdong == null)
                {

                    return NotFound();
                }
                return Ok(hopdong);
            }
            catch
            {

                return BadRequest();
            }
        }
        [HttpPost]
        public IActionResult Create(HopDongVM hopdongVM)
        {
            var hopdong = new HopDong
            {
                MaHopDong = Guid.NewGuid(),
                DienSinhHoat = hopdongVM.DienSinhHoat,
                NuocSach = hopdongVM.NuocSach,
                TenChuSoHuu = hopdongVM.TenChuSoHuu,
                DonGia=hopdongVM.DonGia
            };
            hopdongs.Add(hopdong);
            return Ok(new
            {
                Success = true,
                Data = hopdong
            });
        }
        [HttpPut("{id}")]
        public IActionResult Edit(String id, HopDong hopdongEdit)
        {
            try
            {
                var hopdong = hopdongs.SingleOrDefault(sp => sp.MaHopDong == Guid.Parse(id));
                if (hopdong == null)
                {

                    return NotFound();
                }
                if (id != hopdong.MaHopDong.ToString())
                {
                    return BadRequest();
                }
                //update 
               
        
                hopdong.DienSinhHoat = hopdongEdit.DienSinhHoat;
                hopdong.NuocSach = hopdongEdit.NuocSach;
                hopdong.TenChuSoHuu = hopdongEdit.TenChuSoHuu;
                hopdong.DonGia = hopdongEdit.DonGia;
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
                var hopdong = hopdongs.SingleOrDefault(sp => sp.MaHopDong == Guid.Parse(id));
                if (hopdong == null)
                {

                    return NotFound();
                }

                //detele
                hopdongs.Remove(hopdong);

                return Ok();
            }
            catch
            {

                return BadRequest();
            }


        }

    
}
}
