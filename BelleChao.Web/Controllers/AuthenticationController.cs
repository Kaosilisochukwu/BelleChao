using BelleChao.Data.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BelleChao.Web.Controllers
{
    public class AuthenticationController : Controller
    {
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register([FromForm] UserToRegisterDTO model)
        {
            if (ModelState.IsValid)
            {
                return Ok();
            }
            return RedirectToAction("Register");
        }
    }
}
