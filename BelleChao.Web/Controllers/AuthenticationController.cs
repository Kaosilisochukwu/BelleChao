using BelleChao.Data.DTOs;
using BelleChao.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace BelleChao.Web.Controllers
{
    public class AuthenticationController : Controller
    {
        public AuthenticationController()
        {

        }
        public async Task<IActionResult> Register()
        {

            var baseUrl = HttpContext.Request.Host.ToUriComponent();
            var url = $"http://{baseUrl}/api/register";
            HttpClient client = new HttpClient();
            HttpRequestMessage message = new HttpRequestMessage();
            message.RequestUri = new Uri(url);
            var response = await client.SendAsync(message);
            var dataString = await response.Content.ReadAsStringAsync();
            
            return View();
        }

        [HttpPost]
        public IActionResult Register([FromForm] UserToRegisterDTO model)
        {
            if (ModelState.IsValid)
            {

            }
            return View();
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
