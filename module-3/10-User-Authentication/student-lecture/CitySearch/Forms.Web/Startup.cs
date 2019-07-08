using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Forms.Web.DAO;
using Forms.Web.Providers.Auth;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Forms.Web
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => false;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            // Setup Session
            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                // Sets session expiration to 20 minuates
                options.IdleTimeout = TimeSpan.FromMinutes(20);
                options.Cookie.HttpOnly = true;
            });


            // Dependency Injection
            // For Authentication
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IAuthProvider, SessionAuthProvider>();
            string idConnectionString = Configuration.GetConnectionString("Identity");
            services.AddTransient<IUserDAO>(m => new UserSqlDAO(idConnectionString));



            // Globally add auto-validation for all controllers and post methods
            services.AddMvc(options => options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute()))
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            // Setup dependency injection - pass a city dao into the city controller
            string connectionString = Configuration.GetConnectionString("Default");
            services.AddTransient<ICityDAO, CitySqlDAO>(d => new CitySqlDAO(connectionString));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseSession();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
