using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PhoneBook.Core.Contracts.People;
using PhoneBook.Core.Contracts.Phones;
using PhoneBook.Core.Contracts.Tags;
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
            services.AddDbContext<PhoneBookContext>(c => c.UseSqlServer(Configuration.GetConnectionString("PhoneBook")));
            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<IPersonTagRepository, PersonTagRepository>();
            services.AddScoped<IPhoneRepository, PhoneRepository>();
            services.AddScoped<ITagRepository, TagRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            //app.UseMvcWithDefaultRoute();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=index}/{id?}");
            });

        }
    }
}
