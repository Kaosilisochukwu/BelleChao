using AutoMapper;
using BelleChao.Data;
using BelleChao.Data.DTOs;
using BelleChao.Data.Models;
using BelleChao.Web.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace BelleChao.Web.Controllers
{

    public class MenuItemsController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IOptions<CloudinarySettings> _cloudinaryConfig;
        private readonly IMapper _mapper;
        private readonly Request _requestMaker;


        public MenuItemsController(AppDbContext context, IOptions<CloudinarySettings> cloudinaryConfig, IMapper mapper, Request requestMaker)
        {
            _context = context;
            _cloudinaryConfig = cloudinaryConfig;
            _mapper = mapper;
            _requestMaker = requestMaker;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> AddMenuItem(MenuItemToAddDTO model)
        {
            if (ModelState.IsValid)
            {
                return View();
            }
            if (ModelState.IsValid)
            {

                var managePhoto = new CloudinaryConfig(_cloudinaryConfig);
                var uploadResult = await managePhoto.UploadPhoto(model.Photo);

                if (uploadResult.StatusCode == HttpStatusCode.OK)
                {
                    var menuItem = _mapper.Map<MenuItemToAddDTO, MenuItemToPost>(model);
                    menuItem.PhotoUrl = uploadResult.Url.ToString();
                    menuItem.PhotoPublicId = uploadResult.PublicId;
                    var response = await _requestMaker.PostForm($"api/menu/add", menuItem);
                    var json = await response.Content.ReadAsStringAsync();
                    var responseModel = JsonSerializer.Deserialize<MenuItemToPost>(json);
                    return View();
                }
            }
            return View();
        }

    }
}
