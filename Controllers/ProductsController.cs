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
        public ActionResult<IEnumerable<Product>> GetProducts([FromQuery]string search)
        {
            var collection = _ctx.Products as IQueryable<Product>;
            if (!string.IsNullOrWhiteSpace(search))
            {
                collection = collection.Where(p => p.Name.Contains(search) || p.Category.Contains(search) ||p.Description.Contains(search));
            }

            collection = collection.OrderBy(p => p.Category);

            return Ok(collection.ToList<Product>());
        }

        [HttpGet("{productId}", Name = "GetProduct")]
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

            return CreatedAtRoute("GetProduct" ,new { productId = product.Id}, product);
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
            if(product == null)
            {
                return NotFound();
            }

            _ctx.Products.Remove(product);
            _ctx.SaveChanges();

            return NoContent();
        }
    }
}
