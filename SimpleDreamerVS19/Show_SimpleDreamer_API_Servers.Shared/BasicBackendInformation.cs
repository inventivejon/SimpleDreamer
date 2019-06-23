using System;
using System.Collections.Generic;
using System.Text;

namespace Show_SimpleDreamer_API_Servers.Shared
{
    public class BasicBackendInformation
    {
        public string IpAddress { get; set; }

        public string Port { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Tags { get; set; }

        public string Country { get; set; }

        public override string ToString()
            => $"Server with name {Name} and address {IpAddress}:{Port} is in {Country}";
    }
}
