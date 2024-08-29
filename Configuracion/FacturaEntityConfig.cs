using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OpticaSurinV2.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpticaSurinV2.Configuracion
{
    public class FacturaEntityConfig
    {
        public static void SetFacturaEntityConfig(EntityTypeBuilder<Factura> entityBuilder)
        {
            entityBuilder.HasKey(x => x.IdFactura);

            entityBuilder.Property(x => x.items)
            .IsRequired(false)
            .HasColumnName("Items")
            .HasConversion(
                v => string.Join(',', v),
                v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList()
            )
            .Metadata.SetValueComparer(new ValueComparer<List<string>>(
                (c1, c2) => c1.SequenceEqual(c2),
                c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                c => c.ToList()));

            entityBuilder.Property(x => x.totalItems)
                .IsRequired(false)
                .HasColumnName("TotalItems")
                .HasConversion(
                    v => string.Join(',', v),
                    v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(float.Parse).ToList()
                )
                .Metadata.SetValueComparer(new ValueComparer<List<float>>(
                    (c1, c2) => c1.SequenceEqual(c2),
                    c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                    c => c.ToList()));

            entityBuilder.HasOne(f => f.cobro)
                .WithOne(c => c.factura)
                .HasForeignKey<Cobro>(c => c.IdFactura)
                .IsRequired(false);

            // Otras configuraciones de propiedades si las hay
        }
    }
}
