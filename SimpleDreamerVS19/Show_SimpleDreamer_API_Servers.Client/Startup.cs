using Blazor.FlexGrid;
using Show_SimpleDreamer_API_Servers.Client.GridConfigurations;
using Blazor.FlexGrid.Permission;
using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Show_SimpleDreamer_API_Servers.Client
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddFlexGrid(
                cfg =>
                {
                    cfg.ApplyConfiguration(new BasicBackendInformationGridConfiguration());
                },
                options =>
                {
                    options.IsServerSideBlazorApp = false;
                    options.UseAuthorizationForHttpRequests = true;
                }
            );

            services.AddSingleton<ICurrentUserPermission, TestCurrentUserPermission>();
            services.AddSingleton<IAuthorizationService, TestAuthorizationService>();
        }

        public void Configure(IComponentsApplicationBuilder app)
        {
            app.AddComponent<App>("app");
        }
    }
}
