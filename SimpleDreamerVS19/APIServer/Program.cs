using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SimpleDreamer_Backend.Behavior;

namespace APIServer
{
    public class Program
    {
        public static SimpleDreamerContentProvider _simpleDreamerContentProvider;

        public static void Main(string[] args)
        {
            _simpleDreamerContentProvider = new SimpleDreamerContentProvider();

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
