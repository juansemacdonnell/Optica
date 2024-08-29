using Microsoft.EntityFrameworkCore;
using OpricaSurinV2.Clases;
using OpricaSurinV2.Configuracion;
using OpticaSurinV2.Clases;
using OpticaSurinV2.Configuracion;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpricaSurinV2.Contexto
{
    public class ContextDB : DbContext
    {
        //public ContextDB(DbContextOptions<ContextDB> options) : base(options){}

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Receta> Recetas { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Cobro> Cobros { get; set; }
        public DbSet<Factura> Facturas { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = ConfigurationManager.AppSettings["BD"];
            // DESKTOP-A85G4VT\SQLEXPRESS
            optionsBuilder.UseSqlServer(connectionString);
        }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            ClienteEntityConfig.SetClienteEntityConfig(modelBuilder.Entity<Cliente>());
            RecetaEntityConfig.SetRecetaEntityConfig(modelBuilder.Entity<Receta>());
            PedidoEntityConfig.SetPedidoEntityConfig(modelBuilder.Entity<Pedido>());
            CobroEntityConfig.SetCobroEntityConfig(modelBuilder.Entity<Cobro>());
            FacturaEntityConfig.SetFacturaEntityConfig(modelBuilder.Entity<Factura>());
        }
        
    }
}
