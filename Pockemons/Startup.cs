using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Pokemons.Infrastructure.Persistence.Contexts;
using Pokemons.Infrastructure.Persistence;
<<<<<<< HEAD
using Microsoft.AspNetCore.Http;
using WebApp.Pockemons.Middlewares;
=======
>>>>>>> 5b9ee33994f341d7a6339b8ef121b513d12da1d9

namespace Pockemons
{
    public class Startup
    {
        public IConfiguration _configuration { get; }

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

       
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
<<<<<<< HEAD
            services.AddSession();
=======
>>>>>>> 5b9ee33994f341d7a6339b8ef121b513d12da1d9
            services.AddPersistenceInfrastructure(_configuration);
            services.AddApplicationLayer(_configuration);

            services.AddControllersWithViews();
<<<<<<< HEAD
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<ValidateUserSession, ValidateUserSession>();
=======
>>>>>>> 5b9ee33994f341d7a6339b8ef121b513d12da1d9
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
<<<<<<< HEAD

            app.UseSession();
=======
>>>>>>> 5b9ee33994f341d7a6339b8ef121b513d12da1d9
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
<<<<<<< HEAD
                    pattern: "{controller=User}/{action=Index}/{id?}");
=======
                    pattern: "{controller=Home}/{action=Index}/{id?}");
>>>>>>> 5b9ee33994f341d7a6339b8ef121b513d12da1d9
            });
        }
    }
}
