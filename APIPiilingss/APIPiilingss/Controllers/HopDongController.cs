using APIPiilingss.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIPiilingss.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HopDongController : ControllerBase
    {
        private readonly APIDatabaseContext _context;

        public HopDongController(APIDatabaseContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var dsHopDong = _context.HopDongs.ToList();
            return Ok(dsHopDong);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var hopDong = _context.HopDongs.SingleOrDefault(hd => hd.MHopDong == id);
                if (hopDong != null)
                {
                    return Ok(hopDong);
                }
                else
                {
                    return NotFound();
                }
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult Create(HopDong model)
        {
            try
            {
                var hopDong = new HopDong
                {
                    LoaiSanPham = model.LoaiSanPham,
                    TenChuSoHuu = model.TenChuSoHuu,
                    IdNguoidung = model.IdNguoidung,
                    MHoaDon = model.MHoaDon
                };

                _context.Add(hopDong);
                _context.SaveChanges();
                return Ok(hopDong);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public IActionResult Edit(int id, HopDong hopDongEdit)
        {
            try
            {
                var hopDong = _context.HopDongs.SingleOrDefault(hd => hd.MHopDong == id);
                if (hopDong != null)
                {
                    hopDong.LoaiSanPham = hopDongEdit.LoaiSanPham;
                    hopDong.TenChuSoHuu = hopDongEdit.TenChuSoHuu;
                    hopDong.IdNguoidung = hopDongEdit.IdNguoidung;
                    hopDong.MHoaDon = hopDongEdit.MHoaDon;

                    _context.SaveChanges();
                    return Ok(hopDong);
                }
                else
                {
                    return NotFound();
                }
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}

