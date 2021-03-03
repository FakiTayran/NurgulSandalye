using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NurgulSandalye.WebUI.Areas.Identity.Data;
using NurgulSandalye.WebUI.Data;

[assembly: HostingStartup(typeof(NurgulSandalye.WebUI.Areas.Identity.IdentityHostingStartup))]
namespace NurgulSandalye.WebUI.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<NurgulSandalyeIdentityContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("NurgulSandalyeIdentityContextConnection")));

                services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
                    .AddEntityFrameworkStores<NurgulSandalyeIdentityContext>();
            });
        }
    }
}