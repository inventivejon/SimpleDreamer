﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SimpleDreamer_Backend.Behvaior;

namespace SimpleDreamer_Backend
{
    public class Program
    {
        public static SimpleDreamerContentProvider _simpleDreamerContentProvider;

        public static void Main(string[] args)
        {
            _simpleDreamerContentProvider = new SimpleDreamerContentProvider();

            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
