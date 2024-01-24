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
    public class TienDienController : ControllerBase
    {
        private readonly APIDatabaseContext _context;

        public TienDienController(APIDatabaseContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var dsTienDien = _context.TienDiens.ToList();
            return Ok(dsTienDien);
        }

        [HttpGet("{mDien}")]
        public IActionResult GetByMDien(int mDien)
        {
            try
            {
                var tienDien = _context.TienDiens.SingleOrDefault(td => td.MDien == mDien);
                if (tienDien != null)
                {
                    return Ok(tienDien);
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
        public IActionResult Create(TienDien model)
        {
            try
            {
                var tienDien = new TienDien
                {
                    Dongia = model.Dongia,
                    SoDien = model.SoDien,
                    Thang = model.Thang,
                    Nam = model.Nam
                };

                _context.Add(tienDien);
                _context.SaveChanges();
                return Ok(tienDien);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{mDien}")]
        public IActionResult Edit(int mDien, TienDien tienDienEdit)
        {
            try
            {
                var tienDien = _context.TienDiens.SingleOrDefault(td => td.MDien == mDien);
                if (tienDien != null)
                {
                    tienDien.Dongia = tienDienEdit.Dongia;
                    tienDien.SoDien = tienDienEdit.SoDien;
                    tienDien.Thang = tienDienEdit.Thang;
                    tienDien.Nam = tienDienEdit.Nam;

                    _context.SaveChanges();
                    return Ok(tienDien);
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
