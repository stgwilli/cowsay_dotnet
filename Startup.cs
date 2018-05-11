using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace cowsay_dotnet
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRouting();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });

            var defaultRoute = new RouteHandler(context => { 
                return context.Response.WriteAsync("Hello...");
            });

            var routeBuilder = new RouteBuilder(app, defaultRoute);

            routeBuilder.MapGet("cowsay/{message}", context => { 
                var message = (string)context.GetRouteValue("message");
                var dead = context.Request.Query["dead"] == "1";
                var output = new Cowsay().Speak(message, dead);
                return context.Response.WriteAsync(string.Format(@"
                <!DOCTYPE html>
                    <html>
                        <head>
                            <title>Cowsay></title>
                        </head>
                        <body>
                            <pre>{0}</pre>
                        </body>
                    </html>", output));
            });

            app.UseRouter(routeBuilder.Build());
        }
    }
}
