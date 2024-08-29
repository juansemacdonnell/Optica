using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OpricaSurinV2.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace OpricaSurinV2.Configuracion
{
    public class ClienteEntityConfig
    {
        public static void SetClienteEntityConfig(EntityTypeBuilder<Cliente> entityBuilder)
        {
            entityBuilder.HasKey(x => x.IdCliente);

            // Relación con Pedidos
            entityBuilder.HasMany(c => c.pedidos)
                .WithOne(p => p.cliente)
                .HasForeignKey(p => p.IdCliente)
                .IsRequired(false);

            // Relación con Recetas
            entityBuilder.HasMany(c => c.recetas)
                .WithOne(r => r.cliente)
                .HasForeignKey(r => r.IdCliente)
                .IsRequired();

            // Mapeo de propiedades
            entityBuilder.Property(x => x.nombre)
                .IsRequired()
                .HasColumnName("Nombre");
            entityBuilder.Property(x => x.telefono)
                .IsRequired(false)
                .HasColumnName("Telefono");
            entityBuilder.Property(x => x.dni)
                .IsRequired(false)
                .HasColumnName("Dni");
            entityBuilder.Property(x => x.obraSocial)
                .IsRequired(false)
                .HasColumnName("ObraSocial");
            entityBuilder.Property(x => x.direccion)
                .IsRequired(false)
                .HasColumnName("Direccion");

        }
    } 
}
