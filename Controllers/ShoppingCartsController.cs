using System;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Collections.Generic;
using bikeShopApi.Models;

namespace bikeShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartsController : ControllerBase
    {
        private readonly StoreContext _context;

        public ShoppingCartsController(StoreContext context)
        {
            _context = context;

            if (_context.ShoppingCarts.Count() == 0)
            {
                _context.ShoppingCarts.Add(new ShoppingCart { Date = DateTime.Now.ToLocalTime() });
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public ActionResult<List<ShoppingCart>> GetAll()
        {
            return _context.ShoppingCarts.ToList();
        }

        [HttpGet("{id}", Name = "GetShoppingCarts")]
        public ActionResult<ShoppingCart> GetById(int id)
        {
            var shoppingCart = _context.ShoppingCarts.Find(id);
            if (shoppingCart == null)
            {
                return NotFound();
            }
            return shoppingCart;
        }

        [HttpPost]
        public IActionResult Create(ShoppingCart shoppingCart)
        {
            _context.ShoppingCarts.Add(shoppingCart);
            _context.SaveChanges();

            return CreatedAtRoute("GetShoppingCarts", new { id = shoppingCart.ID }, shoppingCart);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, ShoppingCart item)
        {
            var shoppingCart = _context.ShoppingCarts.Find(id);
            if (shoppingCart == null)
            {
                return NotFound();
            }

            shoppingCart.Customer = item.Customer;
            shoppingCart.CustomerID = item.CustomerID;
            shoppingCart.Date = item.Date;
            shoppingCart.Products = item.Products;

            _context.ShoppingCarts.Update(shoppingCart);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var shoppingCart = _context.ShoppingCarts.Find(id);
            if (shoppingCart == null)
            {
                return NotFound();
            }

            _context.ShoppingCarts.Remove(shoppingCart);
            _context.SaveChanges();
            return NoContent();
        }

    }
}
