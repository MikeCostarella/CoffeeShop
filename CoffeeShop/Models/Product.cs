using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoffeeShop.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Detail { get; set; }

        public string? ImageUrl { get; set; }

        [Column(TypeName = "decimal (5,2)")]
        public decimal Price { get; set; }

        public bool IsTrendingProduct { get; set; }
    }   
}
