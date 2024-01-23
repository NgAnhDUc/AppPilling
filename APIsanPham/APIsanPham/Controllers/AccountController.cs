
using APIsanPham.Data;
using APIsanPham.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace APIaccout.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly MyDbContext _context;

        public AccountController(MyDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var dsAccount = _context.AccountDatas.ToList();
            return Ok(dsAccount);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            try
            {
                var account = _context.AccountDatas.SingleOrDefault(acc => acc.UserName ==id);
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
                var account = new AccountData
                {
                    UserName = model.UserName,
                    role = model.role,
                    password = model.password

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
        public IActionResult Edit(String id, Account accoutEdit)
        {
            try
            {
                var account = _context.AccountDatas.SingleOrDefault(acc => acc.UserName == id);
                if (account != null)
                {
                    account.password = account.password;
                    account.role = account.role;
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
        //[HttpDelete("{id}")]
        //public IActionResult Remove(String id)
        //{
        //    try
        //    {
        //        var accout = accouts.SingleOrDefault(acc => acc.UserName==id);
        //        if (accout == null)
        //        {

        //            return NotFound();
        //        }

        //        //detele
        //        accouts.Remove(accout);

        //        return Ok();
        //    }
        //    catch
        //    {

        //        return BadRequest();
        //    }


        //}
    }
}
