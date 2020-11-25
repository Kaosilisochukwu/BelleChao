using BelleChao.Data.DTOs;
using BelleChao.Data.Models;
using BelleChao.Web.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;
using System.IO;

namespace BelleChao.Web.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly Request _requestMaker;
        private readonly IOptions<CloudinarySettings> _cloudinaryConfig;
        private readonly UserManager<ApplicationUser> _userManager;

        public AuthenticationController(IOptions<CloudinarySettings> cloudinaryConfig, UserManager<ApplicationUser> userManager)
        {
            _requestMaker = new Request(new HttpContextAccessor());
            _cloudinaryConfig = cloudinaryConfig;
            _userManager = userManager;
        }
        public async Task<IActionResult> Register()
        {
            var response = await _requestMaker.GetMethod("/api/register");
            var dataString = await response.Content.ReadAsStringAsync();
            
            return View();
        }

        [HttpPost]
        public async Task<IActionResult >Register([FromForm] UserToRegisterDTO model)
        {
            var pic = model.Avatar;
            if (ModelState.IsValid)
            {
              //  var userToUpdate = await _userManager.FindByIdAsync(Id);
                var managePhoto = new CloudinaryConfig(_cloudinaryConfig);
                var uplResult = managePhoto.UploadPhoto(model.Avatar);
              //  userToUpdate.AvatarUrl = uplResult.Url.ToString();
                //userToUpdate.PublicId = uplResult.PublicId;
             //   await _userManager.UpdateAsync(userToUpdate);
              //  var response = await _requestMaker.PostForm("/api/register", model);
                return View();
            }
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(UserToLoginDTO model)
        {
            if (ModelState.IsValid)
            {
                var response = await _requestMaker.PostForm("/api/login", model);
                var responseBody = await response.Content.ReadAsStringAsync();
                return View();
            }
            return RedirectToAction("Login");
        }
    }
}
