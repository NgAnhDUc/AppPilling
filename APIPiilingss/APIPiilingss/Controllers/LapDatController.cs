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
    public class LapDatController : ControllerBase
    {
        private readonly APIDatabaseContext _context;

        public LapDatController(APIDatabaseContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var dsLapDat = _context.LapDats.ToList();
            return Ok(dsLapDat);
        }

        [HttpGet("{maNv}")]
        public IActionResult GetByMaNv(int maNv)
        {
            try
            {
                var lapDat = _context.LapDats.SingleOrDefault(ld => ld.MaNv == maNv);
                if (lapDat != null)
                {
                    return Ok(lapDat);
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
        public IActionResult Create(LapDat model)
        {
            try
            {
                var lapDat = new LapDat
                {
                    MaSp = model.MaSp,
                    Ngaylapdat = model.Ngaylapdat,
                    TenKh = model.TenKh
                };

                _context.Add(lapDat);
                _context.SaveChanges();
                return Ok(lapDat);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{maNv}")]
        public IActionResult Edit(int maNv, LapDat lapDatEdit)
        {
            try
            {
                var lapDat = _context.LapDats.SingleOrDefault(ld => ld.MaNv == maNv);
                if (lapDat != null)
                {
                    lapDat.MaSp = lapDatEdit.MaSp;
                    lapDat.Ngaylapdat = lapDatEdit.Ngaylapdat;
                    lapDat.TenKh = lapDatEdit.TenKh;

                    _context.SaveChanges();
                    return Ok(lapDat);
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
