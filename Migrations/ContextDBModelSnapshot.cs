﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OpricaSurinV2.Contexto;

#nullable disable

namespace OpticaSurinV2.Migrations
{
    [DbContext(typeof(ContextDB))]
    partial class ContextDBModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("OpricaSurinV2.Clases.Cliente", b =>
                {
                    b.Property<int>("IdCliente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCliente"));

                    b.Property<string>("direccion")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Direccion");

                    b.Property<string>("dni")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Dni");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Nombre");

                    b.Property<string>("obraSocial")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("ObraSocial");

                    b.Property<string>("telefono")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Telefono");

                    b.HasKey("IdCliente");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("OpricaSurinV2.Clases.Pedido", b =>
                {
                    b.Property<int>("IdPedido")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPedido"));

                    b.Property<int>("IdCliente")
                        .HasColumnType("int");

                    b.Property<int?>("IdReceta")
                        .HasColumnType("int");

                    b.Property<string>("detallePedido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("DetallePedido");

                    b.Property<DateTime>("fechaPrometido")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("fechaRecibido")
                        .HasColumnType("datetime2")
                        .HasColumnName("Fecha");

                    b.Property<string>("observaciones")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Observaciones");

                    b.Property<float>("saldo")
                        .HasColumnType("real");

                    b.Property<float>("sena")
                        .HasColumnType("real")
                        .HasColumnName("Sena");

                    b.Property<string>("tipo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Tipo");

                    b.Property<float>("total")
                        .HasColumnType("real")
                        .HasColumnName("Total");

                    b.HasKey("IdPedido");

                    b.HasIndex("IdCliente");

                    b.HasIndex("IdReceta");

                    b.ToTable("Pedidos");
                });

            modelBuilder.Entity("OpricaSurinV2.Clases.Receta", b =>
                {
                    b.Property<int>("IdReceta")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdReceta"));

                    b.Property<int>("IdCliente")
                        .HasColumnType("int");

                    b.Property<string>("cilindroDerechoCerca")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("CilindroDerechoCerca");

                    b.Property<string>("cilindroDerechoLejos")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("CilindroDerechoLejos");

                    b.Property<string>("cilindroIzquierdoCerca")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("CilindroIzquierdoCerca");

                    b.Property<string>("cilindroIzquierdoLejos")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("CilindroIzquierdoLejos");

                    b.Property<string>("dNPDCerca")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("DNPDCerca");

                    b.Property<string>("dNPDLejos")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("DNPDLejos");

                    b.Property<string>("dNPICerca")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("DNPICerca");

                    b.Property<string>("dNPILejos")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("DNPILejos");

                    b.Property<string>("doctor")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Doctor");

                    b.Property<DateTime>("fechaReceta")
                        .HasColumnType("datetime2")
                        .HasColumnName("FechaReceta");

                    b.Property<string>("gradosDerechoCerca")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("GradosDerechoCerca");

                    b.Property<string>("gradosDerechoLejos")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("GradosDerechoLejos");

                    b.Property<string>("gradosIzquierdoCerca")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("GradosIzquierdoCerca");

                    b.Property<string>("gradosIzquierdoLejos")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("GradosIzquierdoLejos");

                    b.Property<string>("observaciones")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Observaciones");

                    b.Property<string>("ojoDerechoEsfericoCerca")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("OjoDerechoEsfericoCerca");

                    b.Property<string>("ojoDerechoEsfericoLejos")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("OjoDerechoEsfericoLejos");

                    b.Property<string>("ojoIzquierdoEsfericoCerca")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("OjoIzquierdoEsfericoCerca");

                    b.Property<string>("ojoIzquierdoEsfericoLejos")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("OjoIzquierdoEsfericoLejos");

                    b.Property<string>("tipo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Tipo");

                    b.HasKey("IdReceta");

                    b.HasIndex("IdCliente");

                    b.ToTable("Recetas");
                });

            modelBuilder.Entity("OpticaSurinV2.Clases.Cobro", b =>
                {
                    b.Property<int>("IdCobro")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCobro"));

                    b.Property<int>("IdFactura")
                        .HasColumnType("int");

                    b.Property<int>("IdPedido")
                        .HasColumnType("int");

                    b.Property<string>("Ultimos4NumerosTarejta1")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Ultimos4NumerosTarejta1");

                    b.Property<string>("Ultimos4NumerosTarejta2")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Ultimos4NumerosTarejta2");

                    b.Property<string>("aclaracionesDeCobro")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("AclaracionesDeCobro");

                    b.Property<float>("dineroEfectivo")
                        .HasColumnType("real")
                        .HasColumnName("DineroEfectivo");

                    b.Property<float>("dineroObraSocial")
                        .HasColumnType("real")
                        .HasColumnName("DineroObraSocial");

                    b.Property<float>("dineroTarjeta1")
                        .HasColumnType("real")
                        .HasColumnName("DineroTarjeta1");

                    b.Property<float>("dineroTarjeta2")
                        .HasColumnType("real")
                        .HasColumnName("DineroTarjeta2");

                    b.Property<float>("dineroTransferencia")
                        .HasColumnType("real")
                        .HasColumnName("DineroTransferencia");

                    b.Property<DateTime>("fechaCobro")
                        .HasColumnType("datetime2")
                        .HasColumnName("FechaCobro");

                    b.Property<string>("marcaTarjeta1")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("MarcaTarjeta1");

                    b.Property<string>("marcaTarjeta2")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("MarcaTarjeta2");

                    b.Property<float>("monto")
                        .HasColumnType("real")
                        .HasColumnName("Monto");

                    b.Property<string>("nombreObraSocial")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("NombreObraSocial");

                    b.Property<string>("tipoTarjeta1")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("TipoTarjeta1");

                    b.Property<string>("tipoTarjeta2")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("TipoTarjeta2");

                    b.HasKey("IdCobro");

                    b.HasIndex("IdFactura")
                        .IsUnique();

                    b.HasIndex("IdPedido");

                    b.ToTable("Cobros");
                });

            modelBuilder.Entity("OpticaSurinV2.Clases.Factura", b =>
                {
                    b.Property<int>("IdFactura")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdFactura"));

                    b.Property<string>("items")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Items");

                    b.Property<string>("totalItems")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("TotalItems");

                    b.HasKey("IdFactura");

                    b.ToTable("Facturas");
                });

            modelBuilder.Entity("OpricaSurinV2.Clases.Pedido", b =>
                {
                    b.HasOne("OpricaSurinV2.Clases.Cliente", "cliente")
                        .WithMany("pedidos")
                        .HasForeignKey("IdCliente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OpricaSurinV2.Clases.Receta", "receta")
                        .WithMany("pedidos")
                        .HasForeignKey("IdReceta")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("cliente");

                    b.Navigation("receta");
                });

            modelBuilder.Entity("OpricaSurinV2.Clases.Receta", b =>
                {
                    b.HasOne("OpricaSurinV2.Clases.Cliente", "cliente")
                        .WithMany("recetas")
                        .HasForeignKey("IdCliente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("cliente");
                });

            modelBuilder.Entity("OpticaSurinV2.Clases.Cobro", b =>
                {
                    b.HasOne("OpticaSurinV2.Clases.Factura", "factura")
                        .WithOne("cobro")
                        .HasForeignKey("OpticaSurinV2.Clases.Cobro", "IdFactura");

                    b.HasOne("OpricaSurinV2.Clases.Pedido", "pedido")
                        .WithMany("cobros")
                        .HasForeignKey("IdPedido")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("factura");

                    b.Navigation("pedido");
                });

            modelBuilder.Entity("OpricaSurinV2.Clases.Cliente", b =>
                {
                    b.Navigation("pedidos");

                    b.Navigation("recetas");
                });

            modelBuilder.Entity("OpricaSurinV2.Clases.Pedido", b =>
                {
                    b.Navigation("cobros");
                });

            modelBuilder.Entity("OpricaSurinV2.Clases.Receta", b =>
                {
                    b.Navigation("pedidos");
                });

            modelBuilder.Entity("OpticaSurinV2.Clases.Factura", b =>
                {
                    b.Navigation("cobro")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
