using BelleChao.Data;
using BelleChao.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BelleChao.Web.Controllers
{
    [ApiController]
    [Route("api/order")]
    public class ApiOrderController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ApiOrderController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> PlaceOder(Order order)
        {
            if (ModelState.IsValid)
            {
                await _context.Orders.AddAsync(order);
                return Ok();
            }
            return BadRequest();
        }
    }
}
