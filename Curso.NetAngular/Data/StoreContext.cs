using Microsoft.EntityFrameworkCore;
using Curso.NetAngular.Entities;

namespace Curso.NetAngular.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options) 
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

    }
}
