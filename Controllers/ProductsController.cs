using System;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Collections.Generic;
using bikeShopApi.Models;

namespace bikeShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly StoreContext _context;

        public ProductsController(StoreContext context)
        {
            _context = context;

            if (_context.Products.Count() == 0)
            {
                _context.Products.Add(new Product { Name = "Product1" });
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public ActionResult<List<Product>> GetAll()
        {
            return _context.Products.ToList();
        }

        [HttpGet("{id}", Name = "GetProducts")]
        public ActionResult<Product> GetById(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            return product;
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();

            return CreatedAtRoute("GetProducts", new { id = product.ID }, product);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Product item)
        {
            var product = _context.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }

            product.Color = item.Color;
            product.Description = item.Description;
            product.ImagePath = item.ImagePath;
            product.Manufacturer = item.Manufacturer;
            product.Model = item.Model;
            product.Name = item.Name;
            product.Price = item.Price;
            product.QuantityAvailable = item.QuantityAvailable;
            product.Size = item.Size;

            _context.Products.Update(product);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            _context.SaveChanges();
            return NoContent();
        }

    }
}
