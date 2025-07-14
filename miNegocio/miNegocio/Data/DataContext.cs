using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using miNegocio.Modelos;

namespace miNegocio.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Producto> Productos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Detallespedido> Detallespedido { get; set; }
        public DbSet<Direccion> Direcciones { get; set; }
    }
}
