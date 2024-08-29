using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OpricaSurinV2.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace OpricaSurinV2.Configuracion
{
    public class PedidoEntityConfig 
    {
        public static void SetPedidoEntityConfig(EntityTypeBuilder<Pedido> entityBuilder)
        {
            entityBuilder.HasKey(x => x.IdPedido);

            // Relación con Cliente
            entityBuilder.HasOne(p => p.cliente)
                .WithMany(c => c.pedidos)
                .HasForeignKey(p => p.IdCliente)
                .IsRequired();

            // Relación con Receta
            entityBuilder.HasOne(p => p.receta)
                .WithMany(r => r.pedidos) // Aquí especifica si Receta tiene una relación inversa con Pedido
                .HasForeignKey(p => p.IdReceta)
                .IsRequired(false) // Si la relación con receta es requerida, cambia a true
            .OnDelete(DeleteBehavior.NoAction); // Especifica el comportamiento de eliminación

            // Relación con Cobros
            entityBuilder.HasMany(p => p.cobros)
                .WithOne(c => c.pedido)
                .HasForeignKey(c => c.IdPedido)
                .IsRequired(false);

            // Mapeo de propiedades
            entityBuilder.Property(x => x.total)
                .IsRequired()
                .HasColumnName("Total");

            entityBuilder.Property(x => x.sena)
                .IsRequired()
                .HasColumnName("Sena");

            entityBuilder.Property(x => x.observaciones)
              .IsRequired()
              .HasColumnName("Observaciones");

            entityBuilder.Property(x => x.detallePedido)
             .IsRequired()
             .HasColumnName("DetallePedido");

            entityBuilder.Property(x => x.fechaRecibido)
                .IsRequired()
                .HasColumnName("Fecha");

            entityBuilder.Property(x => x.tipo)
                .IsRequired()
                .HasColumnName("Tipo");

            /*entityBuilder.Property(x => x.dineroEfectivo)
                .IsRequired()
                .HasColumnName("Efectivo");
            entityBuilder.Property(x => x.dineroTarjeta)
                .IsRequired()
                .HasColumnName("Tarjeta");
            entityBuilder.Property(x => x.dineroTransferencia)
                .IsRequired()
                .HasColumnName("Transferencia"); */

        }
    }
}
