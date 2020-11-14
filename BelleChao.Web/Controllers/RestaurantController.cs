using BelleChao.Data.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BelleChao.Web.Controllers
{
    public class RestaurantController : Controller
    {
        public IActionResult Register()
        {
            return View();
        }
        public IActionResult Register([FromForm] RestaurantToRegisterDTO model)
        {
            return View();
        }
    }
}
