﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebAppCore.Models;

namespace WebAppCore
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration; 
        }

        public IConfiguration Configuration { get; }
               
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDatabaseContext();

            services.AddMvc();

            services.AddRouting(options =>
            {
                options.LowercaseUrls = true;
            });
        }
                
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");                
            });
        }
    }
}
