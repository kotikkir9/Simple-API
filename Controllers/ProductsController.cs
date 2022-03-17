using Microsoft.AspNetCore.Mvc;
using SimpleAPI.Models.DBContext;
using SimpleAPI.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleAPI.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductsController : Controller
    {
        private readonly ProductsDbContext _ctx;

        public ProductsController(ProductsDbContext ctx)
        {
            _ctx = ctx;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetProducts()
        {
            var products = _ctx.Products;
            return Ok(products);
        }

        [HttpGet("{productId}")]
        public ActionResult<Product> GetProduct(Guid productId)
        {
            var product = _ctx.Products.FirstOrDefault(e => e.Id == productId);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPost]
        public ActionResult CreateProduct(Product product)
        {
            _ctx.Products.Add(product);
            _ctx.SaveChanges();

            return Created($"/api/products/{product.Id}", product);
        }

        [HttpPut]
        public ActionResult UpdateProduct(Product product)
        {
            if(product == null)
            {
                return BadRequest();
            }

            var existingProduct = _ctx.Products.FirstOrDefault(e => e.Id == product.Id);
            if(existingProduct == null)
            {
                return NotFound();
            }

            existingProduct.Name = product.Name;
            existingProduct.Price = product.Price;
            existingProduct.Category = product.Category;
            existingProduct.Description = product.Description;

            _ctx.SaveChanges();

            return Ok(existingProduct);
        }

        [HttpDelete("{productId}")]
        public ActionResult DeleteProduct(Guid productId)
        {
            var product = _ctx.Products.FirstOrDefault(e => e.Id == productId);
            if(product != null)
            {
                _ctx.Products.Remove(product);
                _ctx.SaveChanges();
            }

            return NoContent();
        }
    }
}
