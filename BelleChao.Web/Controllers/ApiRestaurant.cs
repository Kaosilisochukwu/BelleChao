using BelleChao.Data;
using BelleChao.Data.DTOs;
using BelleChao.Data.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BelleChao.Web.Controllers
{
    public class ApiRestaurant : ControllerBase
    {
        private readonly IRestaurantRepository _restrurantRepo;

        public ApiRestaurant(IRestaurantRepository restrurantRepo)
        {
            _restrurantRepo = restrurantRepo;
        }

        [HttpPost]
        public IActionResult Index(RestaurantToRegisterDTO model)
        {
            if (ModelState.IsValid)
            {
                _restrurantRepo.AddRestaurant(model);
            }
            return Ok();
        }
    }
}
