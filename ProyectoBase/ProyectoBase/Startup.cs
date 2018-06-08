using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProyectoBase.Models;

namespace ProyectoBase
{
    public class Startup
    {
        public IConfiguration aeConfiguration { get; }

        public Startup(IConfiguration aePaConfiguration)
        {
            aeConfiguration = aePaConfiguration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(aeConfiguration.GetConnectionString("AEBase")));
            
            /*
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseInMemoryDatabase("DbApp"));
            */
            services.AddMvc()
             .AddRazorPagesOptions(options =>
              {
                  options.RootDirectory = "/Pages/Menu";
                  options.Conventions.AuthorizeFolder("/Menu");
              });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();

            app.UseMvc();
            //app.UseMvc(routes =>
            //{
            //    routes.MapRoute(
            //        name: "default",
            //        //template: "{controller=Pages}/{controller=Menu}/{action=Index}/{id?}");
            //        template: "Pages/Menu/Index");
            //});
        }
    }
}
