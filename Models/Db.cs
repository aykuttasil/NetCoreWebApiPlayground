using Microsoft.EntityFrameworkCore;

namespace NetCoreWebApiPlayground.Models
{
    public class Db : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public Db(DbContextOptions<Db> options) : base(options)
        {
        }
    }
}