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
    public class SanPhamController : ControllerBase
    {
        private readonly APIDatabaseContext _context;

        public SanPhamController(APIDatabaseContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var dsSanPham = _context.SanPhams.ToList();
            return Ok(dsSanPham);
        }

        [HttpGet("{maSp}")]
        public IActionResult GetByMaSp(int maSp)
        {
            try
            {
                var sanPham = _context.SanPhams.SingleOrDefault(sp => sp.MaSp == maSp);
                if (sanPham != null)
                {
                    return Ok(sanPham);
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
        public IActionResult Create(SanPham model)
        {
            try
            {
                var sanPham = new SanPham
                {
                    TenSp = model.TenSp,
                    LoaiSanPham = model.LoaiSanPham
                };

                _context.Add(sanPham);
                _context.SaveChanges();
                return Ok(sanPham);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{maSp}")]
        public IActionResult Edit(int maSp, SanPham sanPhamEdit)
        {
            try
            {
                var sanPham = _context.SanPhams.SingleOrDefault(sp => sp.MaSp == maSp);
                if (sanPham != null)
                {
                    sanPham.TenSp = sanPhamEdit.TenSp;
                    sanPham.LoaiSanPham = sanPhamEdit.LoaiSanPham;

                    _context.SaveChanges();
                    return Ok(sanPham);
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
