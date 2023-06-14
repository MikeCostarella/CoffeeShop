using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoffeeShop.Models
{
    public class Order
    {
        public int Id { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Email { get; set; }

        public string? Phone { get; set; }

        public string? Address { get; set; }

        [Column(TypeName = "decimal (5,2)")]
        public decimal OrderTotal { get; set; }

        public DateTime OrderPlaced { get; set; }

        public List<OrderDetail>? OrderDetails { get; set; }
    }
}
