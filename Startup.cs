using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NetCoreWebApiPlayground.Models;
using Swashbuckle.AspNetCore.Swagger;

namespace NetCoreWebApiPlayground
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
            // Swagger kullanımı için ekliyoruz
            services.AddSwaggerGen(c =>
                   {
                       c.SwaggerDoc("v1", new Info
                       {
                           Title = "Web API Playground",
                           Version = "v1",
                           Description = ".Net Core Web Api Structure",
                           Contact = new Contact
                           {
                               Name = "Aykut Asil",
                               Email = "aykuttasil@gmail.com",
                               Url = "http://www.aykutasil.com"
                           },
                           License = new License
                           {
                               Name = "Under GNU",
                               Url = "http://www.aykutasil.com"
                           }
                       });
                   });

            // Uygulamanın oluşturmuş olduğumuz DbContext dosyasını tanımasını sağlıyoruz
            // Ve oluşturulacak DatabaseName ini belirtiyoruz.
            services.AddDbContext<Db>(opt => opt.UseInMemoryDatabase("PlaygroundDb"));
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseMvc();

            // Swagger kullanımı için ekliyoruz 
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApi Playground API v1.0");
            });
        }
    }
}
