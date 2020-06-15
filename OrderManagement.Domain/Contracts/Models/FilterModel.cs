using System;

namespace OrderManagement.Domain.Contracts.Models
{
    public class FilterModel
    {
        public string OrderName { get; set; }
        public DateTime OrderDate { get; set; }
        public int OrderProviderId { get; set; }
        public string OrderItemName { get; set; }
        public string OrderItemUnit { get; set; }
        public string OrderProviderName { get; set; }
    }
}
