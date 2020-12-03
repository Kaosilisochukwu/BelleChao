using BelleChao.Data.DTOs;
using BelleChao.Data.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BelleChao.Web.Controllers
{
    [ApiController]
    public class ApiOrder : ControllerBase
    {
        private readonly IOrderRepository _orderRepo;

        public ApiOrder(IOrderRepository orderRepo)
        {
            _orderRepo = orderRepo;
        }
        public async Task<IActionResult> GetOrders()
        {
            try
            {
                var orders = await _orderRepo.GetOrders();
                if(orders == null)
                {
                    return BadRequest();
                }
                return Ok(orders);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        public async Task<IActionResult> GetOrdersByUserId(string userId)
        {
            try
            {
                var orders = await _orderRepo.GetOrdersByUserId(userId);
                if(orders == null)
                {
                    return BadRequest();
                }
                return Ok(orders);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        public async Task<IActionResult> GetOrdersByRestaurant(string restaurantId)
        {
            try
            {
                var orders = await _orderRepo.GetOrdersByRestaurant(restaurantId);
                if(orders == null)
                {
                    return BadRequest();
                }
                return Ok(orders);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        public async Task<IActionResult> GetOrdersById(string orderId)
        {
            try
            {
                var orders = await _orderRepo.GetOrdersById(orderId);
                if(orders == null)
                {
                    return BadRequest();
                }
                return Ok(orders);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        public async Task<IActionResult> PlaceOrder(OrderToPlaceDTO order)
        {
            try
            {
                var orderId = await _orderRepo.PlaceOrder(order);
                if (orderId == null)
                {
                    return BadRequest();
                }
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();   
            }
        }
        public async Task<IActionResult> CancelOrder(string orderId)
        {
            try
            {
                var cancelled = await _orderRepo.CancelOrder(orderId);
                if (!cancelled)
                {
                    return BadRequest();
                }
                return Ok("Order Successfully cancelled");
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        public async Task<IActionResult> ApproveOrder(string orderId)
        {
            try
            {
                var approved = await _orderRepo.ApproveOrder(orderId);
                if (!approved)
                {
                    return BadRequest();
                }
                return Ok("Order has been successfully approved");
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        public async Task<IActionResult> DeclineOrder(string orderId)
        {
            try
            {
                var declined = await _orderRepo.DeclineOrder(orderId);
                if (!declined)
                {
                    return BadRequest();
                }
                return Ok("Order has been successfully declined");
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        public async Task<IActionResult> DispatchOrder(string orderId)
        {
            try
            {
                var dispatched = await _orderRepo.DispatchOrder(orderId);
                if (!dispatched)
                {
                    return BadRequest();
                }
                return Ok("Order has been successfully dispatced");
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        public async Task<IActionResult> RecieveOrder(string orderId)
        {
            try
            {
                var recieved = await _orderRepo.RecieveOrder(orderId);
                if (!recieved)
                {
                    return BadRequest();
                }
                return Ok("Order has been successfully recieved");
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        
    }
}
