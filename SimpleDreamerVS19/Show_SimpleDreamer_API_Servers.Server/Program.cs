using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Show_SimpleDreamer_API_Servers.Server.Manager;

namespace Show_SimpleDreamer_API_Servers.Server
{
    public class Program
    {
        public static SimpleDreamerBackendRegistryClass _SimpleDreamerBackendRegistryClass;

        public static void Main(string[] args)
        {
            _SimpleDreamerBackendRegistryClass = new SimpleDreamerBackendRegistryClass();

            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseConfiguration(new ConfigurationBuilder()
                    .AddCommandLine(args)
                    .Build())
                .UseStartup<Startup>()
                .Build();
    }
}
