using System;

namespace OrderManagement.Domain.Contracts.Exceptions
{
    public class OrderNotFoundException : Exception
    {
        public OrderNotFoundException(string message)
        : base(message)
        {
            
        }
    }
}
