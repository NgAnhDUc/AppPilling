using APIsanPham.Data;
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
    public class SanPhamController : ControllerBase
        
    {
        private readonly MyDbContext _context;
        public SanPhamController(MyDbContext context) { 
              _context = context;
        }
     
        [HttpGet]
        public IActionResult GetAll()
        { 
            var dssanphams = _context.SanPhamDatas.ToList();
            return Ok(dssanphams);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            try
            {
                var sanPham = _context.SanPhamDatas.SingleOrDefault(sp => sp.MaSanPham == Guid.Parse(id));
                if (sanPham == null)
                {

                    return NotFound();
                }
                return Ok(sanPham);
            }
            catch
            {

                return BadRequest();
            }
        }
        [HttpPost]
        public IActionResult Create(SanPhamVM model)
        {
            try
            {
                var sanpham = new SanPhamData
                {
                    MaSanPham = Guid.NewGuid(),
                    TenSanPham = model.TenSanPham,
                    DonGia = model.DonGia

                };
                _context.Add(sanpham);
                _context.SaveChanges();
                return Ok(sanpham);
            }
            catch
            {
                return BadRequest();
            }


        }
        [HttpPut("{id}")]
        public IActionResult Edit(String id,SanPhamVM model)
        {
            try
            {
                var sanPham = _context.SanPhamDatas.SingleOrDefault(sp => sp.MaSanPham == Guid.Parse(id));
                if (sanPham != null)
                {
                    sanPham.TenSanPham = model.TenSanPham;
                    sanPham.DonGia = model.DonGia;
                    _context.SaveChanges();
                    return NoContent();
                   
                }
                return NotFound();
            }
            catch
            {

                return BadRequest();
            }

        }
        //[HttpDelete("{id}")]
        //public IActionResult Remove(String id)
        //{
        //    try
        //    {
        //        var sanPham = sanphams.SingleOrDefault(sp => sp.MaSanPham == Guid.Parse(id));
        //        if (sanPham == null)
        //        {

        //            return NotFound();
        //        }
               
        //        //detele
        //        sanphams.Remove(sanPham);

        //        return Ok();
        //    }
        //    catch
        //    {

        //        return BadRequest();
        //    }


        //}

    }
}
