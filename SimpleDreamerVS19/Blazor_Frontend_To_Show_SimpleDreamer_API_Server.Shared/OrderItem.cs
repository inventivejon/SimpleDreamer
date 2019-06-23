using System;
using System.Collections.Generic;
using System.Text;

namespace Blazor_Frontend_To_Show_SimpleDreamer_API_Server.Shared
{
    public class OrderItem
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public int OrderId { get; set; }
    }
}
