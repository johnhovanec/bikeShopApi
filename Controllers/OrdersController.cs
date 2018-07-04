using System;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Collections.Generic;
using bikeShopApi.Models;

namespace bikeShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly StoreContext _context;

        public OrdersController(StoreContext context)
        {
            _context = context;

            if (_context.Orders.Count() == 0)
            {
                _context.Orders.Add(new Order { DateCreated = DateTime.Now.ToLocalTime() });
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public ActionResult<List<Order>> GetAll()
        {
            return _context.Orders.ToList();
        }

        [HttpGet("{id}", Name = "GetOrders")]
        public ActionResult<Order> GetById(int id)
        {
            var order = _context.Orders.Find(id);
            if (order == null)
            {
                return NotFound();
            }
            return order;
        }

        [HttpPost]
        public IActionResult Create(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();

            return CreatedAtRoute("GetOrders", new { id = order.ID }, order);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Order item)
        {
            var order = _context.Orders.Find(id);
            if (order == null)
            {
                return NotFound();
            }

            order.Customer = item.Customer;
            order.CustomerID = item.CustomerID;
            order.DateCreated = item.DateCreated;
            order.Products = item.Products;
            order.ShoppingCart = item.ShoppingCart;
            order.ShoppingCartID = item.ShoppingCartID;
            order.Subtotal = item.Subtotal;
            order.Tax = item.Tax;
            order.Total = item.Total;

            _context.Orders.Update(order);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var order = _context.Orders.Find(id);
            if (order == null)
            {
                return NotFound();
            }

            _context.Orders.Remove(order);
            _context.SaveChanges();
            return NoContent();
        }

    }
}
