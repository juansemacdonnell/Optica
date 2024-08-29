using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OpricaSurinV2.Clases;
using OpticaSurinV2.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpticaSurinV2.Configuracion
{
    public class CobroEntityConfig
    {
        public static void SetCobroEntityConfig(EntityTypeBuilder<Cobro> entityBuilder)
        {
            // Definición de la clave primaria
            entityBuilder.HasKey(x => x.IdCobro);

            // Relación con Pedidos
            entityBuilder.HasOne(c => c.pedido)
                .WithMany(p => p.cobros)
                .HasForeignKey(c => c.IdPedido)
                .IsRequired();

            // Relacion con facturas
            entityBuilder.HasOne(c => c.factura)
                .WithOne(f => f.cobro)
                .HasForeignKey<Cobro>(c => c.IdPedido)
                .IsRequired(false);

            // Mapeo de propiedades
            entityBuilder.Property(x => x.monto)
                .IsRequired()
                .HasColumnName("Monto");

            entityBuilder.Property(x => x.dineroTarjeta1)
                .IsRequired()
                .HasColumnName("DineroTarjeta1");

            entityBuilder.Property(x => x.tipoTarjeta1)
                .IsRequired(false)
                .HasColumnName("TipoTarjeta1");

            entityBuilder.Property(x => x.marcaTarjeta1)
                .IsRequired(false)
                .HasColumnName("MarcaTarjeta1");

            entityBuilder.Property(x => x.Ultimos4NumerosTarejta1)
                .IsRequired(false)
                .HasColumnName("Ultimos4NumerosTarejta1");

            entityBuilder.Property(x => x.dineroTarjeta2)
                .IsRequired()
                .HasColumnName("DineroTarjeta2");

            entityBuilder.Property(x => x.tipoTarjeta2)
                .IsRequired(false)
                .HasColumnName("TipoTarjeta2");

            entityBuilder.Property(x => x.marcaTarjeta2)
                .IsRequired(false)
                .HasColumnName("MarcaTarjeta2");

            entityBuilder.Property(x => x.Ultimos4NumerosTarejta2)
                .IsRequired(false)
                .HasColumnName("Ultimos4NumerosTarejta2");

            entityBuilder.Property(x => x.dineroTransferencia)
                .IsRequired()
                .HasColumnName("DineroTransferencia");

            entityBuilder.Property(x => x.dineroEfectivo)
                .IsRequired()
                .HasColumnName("DineroEfectivo");

            entityBuilder.Property(x => x.fechaCobro)
                .IsRequired()
                .HasColumnName("FechaCobro");

            entityBuilder.Property(x => x.aclaracionesDeCobro)
                .IsRequired(false)
                .HasColumnName("AclaracionesDeCobro");

            entityBuilder.Property(x => x.nombreObraSocial)
                .IsRequired(false)
                .HasColumnName("NombreObraSocial");

            entityBuilder.Property(x => x.dineroObraSocial)
                .IsRequired()
                .HasColumnName("DineroObraSocial");

        }
    }
}

