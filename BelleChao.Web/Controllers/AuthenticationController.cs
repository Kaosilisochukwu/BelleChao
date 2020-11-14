using BelleChao.Data.DTOs;
using Microsoft.AspNetCore.Mvc;

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

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login([FromForm] UserToLoginDTO model)
        {
            if (ModelState.IsValid)
            {
                return Ok();
            }
            return RedirectToAction("Login");
        }
    }
}
