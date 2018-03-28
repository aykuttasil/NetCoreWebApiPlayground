# .NetCore WebApi Playground

- Entity Framework kurmak için

```bash
dotnet add package Microsoft.EntityFrameworkCore.InMemory
```

---

```dotnet
        public void ConfigureServices(IServiceCollection services)
        {
            // Uygulamanın oluşturmuş olduğumuz DbContext dosyasını tanımasını sağlıyoruz
            // Ve oluşturulacak DatabaseName ini belirtiyoruz.
            services.AddDbContext<Db>(opt => opt.UseInMemoryDatabase("PlaygroundDb"));
            services.AddMvc();
        }
```

---

- Static asset lerin kullanımı için

```dotnet
public void Configure(IApplicationBuilder app, IHostingEnvironment env)
{
    if (env.IsDevelopment())
    {
        app.UseDeveloperExceptionPage();
    }
 
    // Statik assetlerin kullanımı için ekliyoruz
    app.UseStaticFiles();
    app.UseMvc();
}
```

> http://localhost:5560/index.html

---

- Swagger eklemek için

```bash
dotnet add Fabrika.csproj package Swashbuckle.AspNetCore
```

---

```dotnet
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
        }
```

```dotnet
public void Configure(IApplicationBuilder app,HostingEnvironment env)
        {
            // Swagger kullanımı için ekliyoruz 
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApi Playground API v1.0");
            });
        }
```

> http://localhost:5560/swagger/

---

> Sources
- http://www.buraksenyurt.com/post/net-core-2-0-ile-basit-bir-web-api-gelistirmek