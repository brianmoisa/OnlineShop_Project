using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnlineShop.Data;
using OnlineShop.Repository;
using Microsoft.AspNetCore.Authorization;
using OnlineShop.Models;
using Identity.IdentityPolicy;
using OnlineShop.PasswordValidation;
using NETCore.MailKit.Extensions;
using NETCore.MailKit.Infrastructure.Internal;
using OnlineShop.MailKit;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace OnlineShop
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

            services.AddTransient<IdentityErrorDescriber, CustomIdentityErrorDescriber>(); //clasa pentru override error message

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddDbContext<ApplicationDBContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
            );

            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 6;
                options.User.RequireUniqueEmail = true;
                options.SignIn.RequireConfirmedEmail = true;
            })
                .AddEntityFrameworkStores<ApplicationDBContext>().
                AddDefaultTokenProviders();


            services.AddMvc().AddRazorPagesOptions(options => options.AllowAreas = true);
            services.AddScoped<IHomeRepository, HomeRepository >();
            services.AddScoped<IProduseCategoriiRepository, ProduseCategoriiRepository>();
            services.AddScoped<IContRepository, ContRepository>();
            services.AddScoped<IMapper,Mapper>();
            services.AddTransient<IEmailSender, MailKitEmailSender>();
            //var mailKitOptions = Configuration.GetSection("Email").Get<MailKitOptions>();
            //services.AddMailKit(config => config.UseMailKit(mailKitOptions));


            services.Configure<MailKitEmailSenderOptions>(options =>
            {
                options.Host_Address = Configuration["ExternalProviders:MailKit:SMTP:Address"];
                options.Host_Port = Convert.ToInt32(Configuration["ExternalProviders:MailKit:SMTP:Port"]);
                options.Host_Username = Configuration["ExternalProviders:MailKit:SMTP:Account"];
                options.Host_Password = Configuration["ExternalProviders:MailKit:SMTP:Password"];
                options.Sender_EMail = Configuration["ExternalProviders:MailKit:SMTP:SenderEmail"];
                options.Sender_Name = Configuration["ExternalProviders:MailKit:SMTP:SenderName"];
            });
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
                app.UseExceptionHandler("/Error");
                app.UseHsts();
                app.UseStatusCodePagesWithReExecute("/Error/{0}");
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();
   


            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

             
            });
        }
    }
}
