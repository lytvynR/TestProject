using System;
using System.Diagnostics;
using System.IO;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PM.Web.Constants;
using PM.Web.Di;

namespace PM.Web
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public IContainer Container { get; private set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            return GetServiceProvider(services);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IApplicationLifetime applicationLifetime)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvcWithDefaultRoute();

            app.Use(async (context, next) =>
            {
                await next();

                if (context.Response.StatusCode == 404 && !Path.HasExtension(context.Request.Path.Value) &&
                    !context.Request.Path.Value.Trim('/').StartsWith(ApiConstants.ApiPrefix))
                {
                    context.Request.Path = "/index.html";
                    context.Response.StatusCode = 200;
                    await next();
                }
            });

            app.UseDefaultFiles();
            app.UseStaticFiles();
            applicationLifetime.ApplicationStopped.Register(() => Container.Dispose());
        }

        private AutofacServiceProvider GetServiceProvider(IServiceCollection services)
        {
            ContainerProvider containerProvider = new ContainerProvider(Configuration);

            return new AutofacServiceProvider(containerProvider.GetContainer(services));
        }
    }
}
