using System;
using System.Collections.Generic;
using System.Text;

namespace Show_SimpleDreamer_API_Servers.Shared
{
    public class OrderItem
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public int OrderId { get; set; }
    }
}
