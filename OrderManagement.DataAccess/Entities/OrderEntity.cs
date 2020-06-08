using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderManagement.DataAccess.Entities
{
    public class OrderEntity : BaseEntity
    {
        public string Name { get; set; }
        [Column(TypeName = "datetime2(7)")]
        public DateTime Date { get; set; } = DateTime.Now;
        public ProviderEntity Provider { get; set; }
        public ICollection<OrderItemEntity> OrderItems { get; set; }
    }
}
