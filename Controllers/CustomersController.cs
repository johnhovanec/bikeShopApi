using System;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Collections.Generic;
using bikeShopApi.Models;

namespace bikeShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly StoreContext _context;

        public CustomersController(StoreContext context)
        {
            _context = context;

            if (_context.Customers.Count() == 0)
            {
                _context.Customers.Add(new Customer { Name = "Customer1" });
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public ActionResult<List<Customer>> GetAll()
        {
            return _context.Customers.ToList();
        }

        [HttpGet("{id}", Name = "GetCustomers")]
        public ActionResult<Customer> GetById(int id)
        {
            var customer = _context.Customers.Find(id);
            if (customer == null)
            {
                return NotFound();
            }
            return customer;
        }

        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();

            return CreatedAtRoute("GetCustomers", new { id = customer.ID }, customer);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Customer item)
        {
            var customer = _context.Customers.Find(id);
            if (customer == null)
            {
                return NotFound();
            }

            customer.Name = item.Name;
            customer.Address = item.Address;
            customer.City = item.City;
            customer.Email = item.Email;
            customer.FailedLogins = item.FailedLogins;
            customer.LastLogin = item.LastLogin;
            customer.Orders = item.Orders;
            customer.ShoppingCarts = item.ShoppingCarts;
            customer.State = item.State;
            customer.Zip = item.Zip;

            _context.Customers.Update(customer);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var customer = _context.Customers.Find(id);
            if (customer == null)
            {
                return NotFound();
            }

            _context.Customers.Remove(customer);
            _context.SaveChanges();
            return NoContent();
        }

    }
}
