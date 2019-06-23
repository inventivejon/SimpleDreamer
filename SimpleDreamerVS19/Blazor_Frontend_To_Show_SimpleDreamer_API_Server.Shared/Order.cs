using System;
using System.Collections.Generic;
using System.Text;

namespace Blazor_Frontend_To_Show_SimpleDreamer_API_Server.Shared
{
    public class Order
    {
        public int Id { get; set; }

        public DateTimeOffset OrderDate { get; set; }

        public OrderState Status { get; set; }

        public int CustomerId { get; set; }

        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

        public override string ToString()
            => $"{Id}, {OrderDate}, {Status}, {CustomerId}";
    }

    public enum OrderState
    {
        None = 0,
        New = 1,
        Cancelled = 2
    }
}
