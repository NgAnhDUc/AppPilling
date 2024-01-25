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
    public class AccountController : ControllerBase
    {
        private readonly APIDatabaseContext _context;

        public AccountController(APIDatabaseContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var dsAccount = _context.Accounts.ToList();
            return Ok(dsAccount);
        }
        [HttpGet("login")]
        public IActionResult Login([FromQuery] int id, [FromQuery] string pass)
        {
            try
            {
                var account = _context.Accounts.SingleOrDefault(acc => acc.Cmnd == id && acc.Passwordd == pass);
                if (account != null)
                {
                    return Ok(account);
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
        public IActionResult Create(Account model)
        {

            try
            {
                var account = new Account
                {
                    Cmnd = model.Cmnd,
                    Passwordd = model.Passwordd,
                    Ten = model.Ten,
                    Email = model.Email,
                    GioiTinh = model.GioiTinh,
                    Diachi = model.Diachi
                };
                _context.Add(account);
                _context.SaveChanges();
                return Ok(account);

            }
            catch
            {
                return BadRequest();
            }
        }



        [HttpPut("{id}")]
        public IActionResult Edit(int id, Account accoutEdit)
        {
            try
            {
                var account = _context.Accounts.SingleOrDefault(acc => acc.Cmnd == id);
                if (account != null)
                {
                    // Cập nhật thông tin tài khoản
                    account.Passwordd = accoutEdit.Passwordd;
                    account.Email = accoutEdit.Email;
                    account.Ten = accoutEdit.Ten;
                    account.GioiTinh = accoutEdit.GioiTinh;
                    account.Diachi = accoutEdit.Diachi;

                    _context.SaveChanges();
                    return Ok(account);
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
