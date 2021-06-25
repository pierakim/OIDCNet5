using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Server.IdentityProvider.Configuration;

namespace Server.IdentityProvider
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddIdentityServer()
                .AddInMemoryIdentityResources(ConfigureServerIdentityProvider.IdentityResources)
                .AddInMemoryApiResources(ConfigureServerIdentityProvider.ApiResources)
                .AddInMemoryApiScopes(ConfigureServerIdentityProvider.ApiScopes)
                .AddInMemoryClients(ConfigureServerIdentityProvider.Clients)
                .AddTestUsers(ConfigureServerIdentityProvider.TestUsers)
                .AddDeveloperSigningCredential();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseRouting();

            app.UseIdentityServer();
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
