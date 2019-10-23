using Datos.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class RotiseriaDesktopContext : DbContext
    {
        public RotiseriaDesktopContext() : base("RotiseriaDesktopContext")
        {
            Database.SetInitializer<RotiseriaDesktopContext>(
              new MigrateDatabaseToLatestVersion<RotiseriaDesktopContext, Configuration>());
        }



        public DbSet<Venta> Ventas { get; set; }
        public DbSet<DetalleVenta> DetalleVentas { get; set; }
        public DbSet<Compra> Compras { get; set; }
        public DbSet<DetalleCompra> DetalleCompras { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<TipoUsuario> TipoUsuarios { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }
    }
}
