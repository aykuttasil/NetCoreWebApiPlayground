# .NetCore WebApi Playground

- Entity Framework kurmak için

```dotnet
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