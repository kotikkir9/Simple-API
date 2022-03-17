using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleAPI.Models.Entities
{
    public class Product
    {
        [Key]
        public Guid Id { get; set; } 

        [Required(ErrorMessage = "Product name is missing.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Product price is missing.")]
        public double? Price { get; set; }
        [Required(ErrorMessage = "Product category is missing.")]
        public string Category { get; set; }
        public string Description { get; set; }
    }
}
