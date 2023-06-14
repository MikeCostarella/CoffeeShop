using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoffeeShop.Models
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }

        public int ProductId { get; set; }

        public Product? Product { get; set; }

        public int OrderId { get; set; }

        public Order? Order { get; set; }

        public int Quantity { get; set; }

        [Column(TypeName = "decimal (5,2)")]
        public decimal Price { get; set; }  
    }
}
