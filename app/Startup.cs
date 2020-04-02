using System;
using app.Extensions;
using app.EntityManager;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
namespace app
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
            // sessions and cache
            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromHours(1);
                options.Cookie.HttpOnly = true;

                options.Cookie.IsEssential = true;
            });
            services.AddHttpContextAccessor();

            // Controllers
            services.AddControllersWithViews();

            // database services
            services.AddDbContext<DbContext>();

            // html utilities
            services.AddSingleton<IManifest, Manifest>();
            services.AddScoped<IReact, React>();
            // services.AddScoped<ISessionStore,SessionStore>();

            // Services
            // services.AddTransient<IAccountService, AccountService>();
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
            app.UseSession();
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
// ReactDOM.hydrate(React.createElement(Components.RootComponent, {"initialComments":[{"author":{"name":"Daniel Lo Nigro","githubUsername":"Daniel15"},"text":"First!!!!111!"},{"author":{"name":"Paul O\u0027Shannessy","githubUsername":"zpao"},"text":"React is awesome!"},{"author":{"name":"Christoph Pojer","githubUsername":"cpojer"},"text":"Awesome!"}],"page":1}), document.getElementById("react_0HLTTIMK7BELB"));
