using BelleChao.Data;
using BelleChao.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BelleChao.Web.Controllers
{

    public class MenuItemsController : Controller
    {
        private readonly AppDbContext _context;

        public MenuItemsController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddMenuItem([FromForm] MenuItem model)
        {
            if (ModelState.IsValid)
            {
                return Ok();
            }
            return BadRequest();
        }

    }
}
