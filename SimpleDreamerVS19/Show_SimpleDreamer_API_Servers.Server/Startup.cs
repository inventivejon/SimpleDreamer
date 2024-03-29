using Blazor.FlexGrid;
using Blazor.FlexGrid.DataSet;
using Blazor.FlexGrid.DataSet.Http;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Serialization;
using System;
using System.IO;
using System.Linq;
using System.Net.Http;

namespace Show_SimpleDreamer_API_Servers.Server
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().AddNewtonsoftJson();
            // Register the Swagger services
            services.AddSwaggerDocument();
            services.AddServerSideBlazor();
            services.AddFlexGridServerSide();
            services.AddResponseCompression(opts =>
            {
                opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
                    new[] { "application/octet-stream" });
            });
            services.AddSingleton<StaticRepositoryCollections>();

            services.TryAddScoped(typeof(ILazyDataSetLoader<>), typeof(NullLazyDataSetLoader<>));
            services.TryAddScoped(typeof(ILazyDataSetItemManipulator<>), typeof(NullLazyDataSetItemManipulator<>));
            services.TryAddScoped(typeof(ICreateItemHandle<,>), typeof(NullCreateItemHandler<,>));

            // Server Side Blazor doesn't register HttpClient by default
            if (!services.Any(x => x.ServiceType == typeof(HttpClient)))
            {
                // Setup HttpClient for server side in a client side compatible fashion
                services.AddScoped<HttpClient>(s =>
                {
                    // Creating the URI helper needs to wait until the JS Runtime is initialized, so defer it.
                    var uriHelper = s.GetRequiredService<IUriHelper>();
                    return new HttpClient
                    {
                        BaseAddress = new Uri(uriHelper.GetBaseUri())
                    };
                });
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseResponseCompression();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBlazorDebugging();
            }

            app.UseClientSideBlazorFiles<Client.Startup>();

            app.UseRouting();

            // Register the Swagger generator and the Swagger UI middlewares
            app.UseOpenApi();
            app.UseSwaggerUi3();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub<Client.App>("app");
                endpoints.MapDefaultControllerRoute();
                endpoints.MapFallbackToClientSideBlazor<Client.Startup>("index.html");
            });

        }
    }
}
