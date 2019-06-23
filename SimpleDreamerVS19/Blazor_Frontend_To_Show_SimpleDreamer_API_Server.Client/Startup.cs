using Blazor.FlexGrid;
using Blazor_Frontend_To_Show_SimpleDreamer_API_Server.Client.GridConfigurations;
using Blazor.FlexGrid.Permission;
using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Blazor_Frontend_To_Show_SimpleDreamer_API_Server.Client
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddFlexGrid(
                cfg =>
                {
                    cfg.ApplyConfiguration(new CustomerGridConfiguration());
                    cfg.ApplyConfiguration(new OrderGridConfiguration());
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
