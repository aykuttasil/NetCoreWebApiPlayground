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
