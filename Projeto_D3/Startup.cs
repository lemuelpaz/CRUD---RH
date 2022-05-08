using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Projeto_D3.Interface;
using Projeto_D3.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_D3
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IHomeService, HomeService>();
            services.AddTransient<ICandService, CandService>();
            services.AddMvc().AddRazorPagesOptions(options =>
            {
                options.Conventions.AddPageRoute("/Home/Index", "");
                options.Conventions.AddPageRoute("/Home/Create", "");
                options.Conventions.AddPageRoute("/Home/Create", "");
                options.Conventions.AddPageRoute("/Home/Lista", "");
                options.Conventions.AddPageRoute("/Candidato/Privacy", "");
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
