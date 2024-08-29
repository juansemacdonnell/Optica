using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OpricaSurinV2.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;

namespace OpricaSurinV2.Configuracion
{
    public class RecetaEntityConfig 
    {
        public static void SetRecetaEntityConfig(EntityTypeBuilder<Receta> entityBuilder)
        {
            entityBuilder.HasKey(x => x.IdReceta);

            // Relación con Cliente
            entityBuilder.HasOne(r => r.cliente)
                .WithMany(c => c.recetas)
                .HasForeignKey(r => r.IdCliente)
                .IsRequired();

            // Relación con Pedidos
            entityBuilder.HasMany(r => r.pedidos)
                .WithOne(p => p.receta)
                .HasForeignKey(p => p.IdReceta)
                .IsRequired(false);

            // Mapeo de propiedades
            entityBuilder.Property(x => x.tipo)
                .IsRequired()
                .HasColumnName("Tipo");

            // Todo Ojo derecho Lejos
            entityBuilder.Property(x => x.ojoDerechoEsfericoLejos)
                .HasColumnName("OjoDerechoEsfericoLejos").IsRequired(false);
            entityBuilder.Property(x => x.cilindroDerechoLejos)
                .HasColumnName("CilindroDerechoLejos").IsRequired(false);
            entityBuilder.Property(x => x.gradosDerechoLejos)
                .HasColumnName("GradosDerechoLejos").IsRequired(false);
            entityBuilder.Property(x => x.dNPDLejos)
                .HasColumnName("DNPDLejos").IsRequired(false);

            // Todo Ojo izquierdo Lejos
            entityBuilder.Property(x => x.ojoIzquierdoEsfericoLejos)
                .HasColumnName("OjoIzquierdoEsfericoLejos").IsRequired(false);
            entityBuilder.Property(x => x.cilindroIzquierdoLejos)
                 .HasColumnName("CilindroIzquierdoLejos").IsRequired(false);
            entityBuilder.Property(x => x.gradosIzquierdoLejos)
                .HasColumnName("GradosIzquierdoLejos").IsRequired(false);
            entityBuilder.Property(x => x.dNPILejos)
                .HasColumnName("DNPILejos").IsRequired(false);

            // Todo Ojo derecho cerca
            entityBuilder.Property(x => x.ojoDerechoEsfericoCerca)
                .HasColumnName("OjoDerechoEsfericoCerca").IsRequired(false);
            entityBuilder.Property(x => x.cilindroDerechoCerca)
                .HasColumnName("CilindroDerechoCerca").IsRequired(false);
            entityBuilder.Property(x => x.gradosDerechoCerca)
                .HasColumnName("GradosDerechoCerca").IsRequired(false);
            entityBuilder.Property(x => x.dNPDCerca)
                .HasColumnName("DNPDCerca").IsRequired(false);

            // Todo Ojo izquierdo Cerca
            entityBuilder.Property(x => x.ojoIzquierdoEsfericoCerca)
                .HasColumnName("OjoIzquierdoEsfericoCerca").IsRequired(false);
            entityBuilder.Property(x => x.cilindroIzquierdoCerca)
                 .HasColumnName("CilindroIzquierdoCerca").IsRequired(false);
            entityBuilder.Property(x => x.gradosIzquierdoCerca)
                .HasColumnName("GradosIzquierdoCerca").IsRequired(false);
            entityBuilder.Property(x => x.dNPICerca)
                .HasColumnName("DNPICerca").IsRequired(false);

            // Continúa con el mapeo de las demás propiedades...
            entityBuilder.Property(x => x.doctor)
                .IsRequired(false)
                .HasColumnName("Doctor");
            entityBuilder.Property(x => x.fechaReceta)
                .IsRequired()
                .HasColumnName("FechaReceta");
            entityBuilder.Property(x => x.observaciones)
                .IsRequired(false)
                .HasColumnName("Observaciones");

           /* entityBuilder.HasData(
                new Receta
                {
                    IdCliente = 1,
                    IdReceta = 1,
                    ojoDerechoEsfericoLejos = "2.5",
                    cilindroDerechoLejos = "-1.25",
                    gradosDerechoLejos = "90",
                    dNPDLejos = "65.5",
                    ojoIzquierdoEsfericoLejos = "3",
                    cilindroIzquierdoLejos = "+0.75",
                    gradosIzquierdoLejos = "180",
                    dNPILejos = "64.2",
                    ojoDerechoEsfericoCerca = "1.75",
                    cilindroDerechoCerca = "-0.5",
                    gradosDerechoCerca = "90",
                    dNPDCerca = "33.7",
                    ojoIzquierdoEsfericoCerca = "2",
                    cilindroIzquierdoCerca = "+0.25",
                    gradosIzquierdoCerca = "180",
                    dNPICerca = "32.8",
                    observaciones = "Ninguna",
                    doctor = "Dr. López",
                    fechaReceta = DateTime.Now,
                    tipo = "Ambas"
                },
                new Receta
                {
                    IdCliente = 2,
                    IdReceta = 2,
                    ojoDerechoEsfericoLejos = "1.75",
                    cilindroDerechoLejos = "-0.75",
                    gradosDerechoLejos = "45",
                    dNPDLejos = "66.1",
                    ojoIzquierdoEsfericoLejos = "2.25",
                    cilindroIzquierdoLejos = "-1.00",
                    gradosIzquierdoLejos = "135",
                    dNPILejos = "65.7",
                    ojoDerechoEsfericoCerca = "1.25",
                    cilindroDerechoCerca = "-0.25",
                    gradosDerechoCerca = "45",
                    dNPDCerca = "34.2",
                    ojoIzquierdoEsfericoCerca = "1.75",
                    cilindroIzquierdoCerca = "-0.50",
                    gradosIzquierdoCerca = "135",
                    dNPICerca = "33.8",
                    observaciones = "Leve astigmatismo en ojo derecho.",
                    doctor = "Dra. García",
                    fechaReceta = DateTime.Now.AddDays(-7), // Ejemplo de fecha hace una semana
                    tipo = "Ambas"

                },
                 new Receta
                 {
                     IdCliente = 3,
                     IdReceta = 3,
                     ojoDerechoEsfericoLejos = "2",
                     cilindroDerechoLejos = "-0.50",
                     gradosDerechoLejos = "90",
                     dNPDLejos = "65.0",
                     ojoIzquierdoEsfericoLejos = "2.5",
                     cilindroIzquierdoLejos = "-0.75",
                     gradosIzquierdoLejos = "180",
                     dNPILejos = "64.5",
                     ojoDerechoEsfericoCerca = "1.5",
                     cilindroDerechoCerca = "-0.25",
                     gradosDerechoCerca = "90",
                     dNPDCerca = "33.5",
                     ojoIzquierdoEsfericoCerca = "2",
                     cilindroIzquierdoCerca = "-0.50",
                     gradosIzquierdoCerca = "180",
                     dNPICerca = "32.9",
                     observaciones = "Ninguna",
                     doctor = "Dr. Martínez",
                     fechaReceta = DateTime.Now.AddDays(-14), // Ejemplo de fecha hace dos semanas
                     tipo = "Ambas"

                 },
                 new Receta
                 {
                     IdCliente = 3,
                     IdReceta = 4,
                     ojoDerechoEsfericoLejos = "1.25",
                     cilindroDerechoLejos = "-0.25",
                     gradosDerechoLejos = "45",
                     dNPDLejos = "66.3",
                     ojoIzquierdoEsfericoLejos = "1.75",
                     cilindroIzquierdoLejos = "-0.50",
                     gradosIzquierdoLejos = "135",
                     dNPILejos = "65.9",
                     ojoDerechoEsfericoCerca = "1.0",
                     cilindroDerechoCerca = "0",
                     gradosDerechoCerca = "45",
                     dNPDCerca = "34.0",
                     ojoIzquierdoEsfericoCerca = "1.5",
                     cilindroIzquierdoCerca = "-0.25",
                     gradosIzquierdoCerca = "135",
                     dNPICerca = "33.6",
                     observaciones = "Leve corrección necesaria en ojo izquierdo.",
                     doctor = "Dr. Rodríguez",
                     fechaReceta = DateTime.Now.AddDays(-21), // Ejemplo de fecha hace tres semanas
                     tipo = "Ambas"
                 }
                ); */
        }
    }
}
