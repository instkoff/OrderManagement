using System.ComponentModel.DataAnnotations.Schema;

namespace OrderManagement.DataAccess.Entities
{
    public class OrderItemEntity : BaseEntity
    {
        public string Name { get; set; }
        [Column(TypeName = "decimal(18,3)")]
        public decimal Quantity { get; set; }
        public string Unit { get; set; }
    }
}