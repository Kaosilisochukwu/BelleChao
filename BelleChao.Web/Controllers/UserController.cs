using Microsoft.AspNetCore.Mvc;

namespace BelleChao.Web.Controllers
{
    public class UserController : Controller
    {

        public IActionResult Profile(string username)
        {
            return View();
        }
    }
}
