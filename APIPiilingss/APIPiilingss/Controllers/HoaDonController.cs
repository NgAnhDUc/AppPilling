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
    public class HoaDonController : ControllerBase
    {
        private readonly APIDatabaseContext _context;

        public HoaDonController(APIDatabaseContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var dsHoaDon = _context.Hoadons.ToList();
            return Ok(dsHoaDon);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var hoaDon = _context.Hoadons.SingleOrDefault(hd => hd.MHoaDon == id);
                if (hoaDon != null)
                {
                    return Ok(hoaDon);
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
        public IActionResult Create(Hoadon model)
        {
            try
            {
                var hoaDon = new Hoadon
                {
                    MHopDong = model.MHopDong,
                    MDien = model.MDien,
                    MNuoc = model.MNuoc
                };

                _context.Add(hoaDon);
                _context.SaveChanges();
                return Ok(hoaDon);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public IActionResult Edit(int id, Hoadon hoaDonEdit)
        {
            try
            {
                var hoaDon = _context.Hoadons.SingleOrDefault(hd => hd.MHoaDon == id);
                if (hoaDon != null)
                {
                    hoaDon.MHopDong = hoaDonEdit.MHopDong;
                    hoaDon.MDien = hoaDonEdit.MDien;
                    hoaDon.MNuoc = hoaDonEdit.MNuoc;

                    _context.SaveChanges();
                    return Ok(hoaDon);
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

