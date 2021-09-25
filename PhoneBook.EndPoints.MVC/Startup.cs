using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PhoneBook.Core.Contracts.People;
using PhoneBook.Core.Contracts.Phones;
using PhoneBook.Core.Contracts.Tags;
using PhoneBook.EndPoints.MVC.Models.AAA;
using PhoneBook.Infrastructures.DataAccess.Common;
using PhoneBook.Infrastructures.DataAccess.People;
using PhoneBook.Infrastructures.DataAccess.Phones;
using PhoneBook.Infrastructures.DataAccess.Tags;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.EndPoints.MVC
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddDbContext<PhoneBookContext>(c => c.UseSqlServer(Configuration.GetConnectionString("Phonebook")));

            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<IPersonTagRepository, PersonTagRepository>();
            services.AddScoped<IPhoneRepository, PhoneRepository>();
            services.AddScoped<ITagRepository, TagRepository>();

            services.AddDbContext<UserDbContext>(c => c.UseSqlServer(Configuration.GetConnectionString("aaa")));
            services.AddIdentity<AppUser, IdentityRole>(
                c =>
            {
                c.User.RequireUniqueEmail = true;                
                //c.Password.RequireDigit = false//customize password
            }
            ).AddEntityFrameworkStores<UserDbContext>();
            //services.AddScoped<IPasswordValidator<AppUser>, MyPasswordValidator>();
            services.AddScoped<IPasswordValidator<AppUser>, MyPasswordValidator2>();
            services.AddScoped<IUserValidator<AppUser>, MyUserValidator>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=index}/{id?}");
            });
        }
    }
}
