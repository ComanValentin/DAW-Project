using CarPartShop.Models.Entities;
using CarPartShop.Services;
using CarPartShop.Helper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarPartShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartItemController : ControllerBase
    {
        private readonly CartItemService _cartItemService;

        public CartItemController(CartItemService cartItemService)
        {
            _cartItemService = cartItemService;
        }
        private User GetUser()
        {
            return (User)HttpContext.Items["User"]!;
        }
        [HttpGet]
        [Authorize]
        public IActionResult GetAll()
        {
            var user = GetUser();
            return Ok(_cartItemService.GetAllItemsForUser(user));
        }
        [HttpPut("{carPartId}")]
        [Authorize]
        public IActionResult AddCartItem(long carPartId)
        {
            try
            {
                var result = _cartItemService.AddCartItemForUser(GetUser(), carPartId);
                return Ok(result);
            }catch(KeyNotFoundException exception)
            {
                return NotFound("Id " + carPartId + " doesn't exist");
           
            }
        }
        [HttpDelete("{carPartId}")]
        [Authorize]
        public IActionResult RemoveCartItem(long carPartId)
        {
            try
            {
                var result = _cartItemService.RemoveCartItemForUser(GetUser(), carPartId);
                return Ok(result);

            }catch (KeyNotFoundException exception)
            {
                return NotFound(exception.Message);
            }
        }
        [HttpPatch("{carPartId}")]
        [Authorize]
        public IActionResult ModifyQuantity(long carPartId, [FromBody] int quantity)
        {
            try
            {
                var result = _cartItemService.UpdateCartItemQuantity(GetUser(), carPartId, quantity);
                return Ok(result);
            }catch(KeyNotFoundException exception)
            {
                return NotFound(exception.Message);
            }
        }
    }
}
