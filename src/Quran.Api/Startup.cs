using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Quran.Data;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Microsoft.OpenApi.Models;
using System.IO;

namespace Quran.Api
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

            services.AddSwaggerGen(c =>
            {
                //c.SwaggerDoc("v1", new OpenApiInfo { Title = "Quran API", Version = "v1" });
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Quran API",
                    Description = "Quran API Built on ASP.NET Core Web API <br>This is an open source project <br> You can use the data in it without modifying it <br> You cannot use it to create your own application regardless your project is free or not <br> This project used main data files from <a href='https://github.com/semarketir/quranjson'>here</a>",
                    
                });

                var filePath = Path.Combine(System.AppContext.BaseDirectory, "Quran.Api.xml");
                c.IncludeXmlComments(filePath);


            });

            services.AddAutoMapper(typeof(Startup));

            var connectionString = Configuration.GetConnectionString("Default");
            services.AddDbContext<QuranContext>(options =>
            {
                options
                .UseSqlServer(connectionString)
                //.UseInMemoryDatabase("quranContext")
                ;
            });
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //app.UsePathBase("/api");
            app.UseSwagger(r =>
            {
            });

            app.UseStaticFiles();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Quran API V1");
                c.RoutePrefix = "docs";
                c.InjectStylesheet("theme-feeling-blue.css");
            });
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<QuranContext>();




                app.UseRouting();

                app.UseAuthorization();

                app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                });
            }
        }
    }
}
