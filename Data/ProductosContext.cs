using Microsoft.EntityFrameworkCore;
using MVCApp.Models;

namespace MVCApp
{
    public class ProductosContext: DbContext
    {
        public ProductosContext(DbContextOptions<ProductosContext> options)
        :base(options)
        {

        }
        public DbSet<Producto> Productos {get; set;}
        public DbSet<Usuario> Usuarios {get; set;}
    }
}