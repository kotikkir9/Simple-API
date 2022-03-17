using Microsoft.EntityFrameworkCore;
using SimpleAPI.Models.Entities;

namespace SimpleAPI.Models.DBContext
{
    public class ProductsDbContext : DbContext
    {
        public ProductsDbContext(DbContextOptions<ProductsDbContext> options) : base(options) { }
        public DbSet<Product> Products { get; set; }
    }
}
