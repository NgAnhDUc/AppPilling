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
    public class TienNuocController : ControllerBase
    {
        private readonly APIDatabaseContext _context;

        public TienNuocController(APIDatabaseContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var dsTienNuoc = _context.TienNuocs.ToList();
            return Ok(dsTienNuoc);
        }

        [HttpGet("{mNuoc}")]
        public IActionResult GetByMNuoc(int mNuoc)
        {
            try
            {
                var tienNuoc = _context.TienNuocs.SingleOrDefault(tn => tn.MNuoc == mNuoc);
                if (tienNuoc != null)
                {
                    return Ok(tienNuoc);
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
        public IActionResult Create(TienNuoc model)
        {
            try
            {
                var tienNuoc = new TienNuoc
                {
                    Dongia = model.Dongia,
                    Sonuoc = model.Sonuoc,
                    Thang = model.Thang,
                    Nam = model.Nam
                };

                _context.Add(tienNuoc);
                _context.SaveChanges();
                return Ok(tienNuoc);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{mNuoc}")]
        public IActionResult Edit(int mNuoc, TienNuoc tienNuocEdit)
        {
            try
            {
                var tienNuoc = _context.TienNuocs.SingleOrDefault(tn => tn.MNuoc == mNuoc);
                if (tienNuoc != null)
                {
                    tienNuoc.Dongia = tienNuocEdit.Dongia;
                    tienNuoc.Sonuoc = tienNuocEdit.Sonuoc;
                    tienNuoc.Thang = tienNuocEdit.Thang;
                    tienNuoc.Nam = tienNuocEdit.Nam;

                    _context.SaveChanges();
                    return Ok(tienNuoc);
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
