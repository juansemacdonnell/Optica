using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OpticaSurinV2.Migrations
{
    /// <inheritdoc />
    public partial class averrr : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    IdCliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dni = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ObraSocial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.IdCliente);
                });

            migrationBuilder.CreateTable(
                name: "Facturas",
                columns: table => new
                {
                    IdFactura = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Items = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalItems = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facturas", x => x.IdFactura);
                });

            migrationBuilder.CreateTable(
                name: "Recetas",
                columns: table => new
                {
                    IdReceta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OjoDerechoEsfericoLejos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CilindroDerechoLejos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GradosDerechoLejos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DNPDLejos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OjoIzquierdoEsfericoLejos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CilindroIzquierdoLejos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GradosIzquierdoLejos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DNPILejos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OjoDerechoEsfericoCerca = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CilindroDerechoCerca = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GradosDerechoCerca = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DNPDCerca = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OjoIzquierdoEsfericoCerca = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CilindroIzquierdoCerca = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GradosIzquierdoCerca = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DNPICerca = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Observaciones = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Doctor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaReceta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdCliente = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recetas", x => x.IdReceta);
                    table.ForeignKey(
                        name: "FK_Recetas_Clientes_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "Clientes",
                        principalColumn: "IdCliente",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    IdPedido = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Total = table.Column<float>(type: "real", nullable: false),
                    Sena = table.Column<float>(type: "real", nullable: false),
                    saldo = table.Column<float>(type: "real", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fechaPrometido = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Observaciones = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdReceta = table.Column<int>(type: "int", nullable: false),
                    IdCliente = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.IdPedido);
                    table.ForeignKey(
                        name: "FK_Pedidos_Clientes_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "Clientes",
                        principalColumn: "IdCliente",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pedidos_Recetas_IdReceta",
                        column: x => x.IdReceta,
                        principalTable: "Recetas",
                        principalColumn: "IdReceta");
                });

            migrationBuilder.CreateTable(
                name: "Cobros",
                columns: table => new
                {
                    IdCobro = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Monto = table.Column<float>(type: "real", nullable: false),
                    DineroTarjeta1 = table.Column<float>(type: "real", nullable: false),
                    TipoTarjeta1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MarcaTarjeta1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ultimos4NumerosTarejta1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DineroTarjeta2 = table.Column<float>(type: "real", nullable: false),
                    TipoTarjeta2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MarcaTarjeta2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ultimos4NumerosTarejta2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DineroTransferencia = table.Column<float>(type: "real", nullable: false),
                    DineroEfectivo = table.Column<float>(type: "real", nullable: false),
                    FechaCobro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdFactura = table.Column<int>(type: "int", nullable: false),
                    IdPedido = table.Column<int>(type: "int", nullable: false),
                    AclaracionesDeCobro = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cobros", x => x.IdCobro);
                    table.ForeignKey(
                        name: "FK_Cobros_Facturas_IdFactura",
                        column: x => x.IdFactura,
                        principalTable: "Facturas",
                        principalColumn: "IdFactura");
                    table.ForeignKey(
                        name: "FK_Cobros_Pedidos_IdPedido",
                        column: x => x.IdPedido,
                        principalTable: "Pedidos",
                        principalColumn: "IdPedido",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cobros_IdFactura",
                table: "Cobros",
                column: "IdFactura",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cobros_IdPedido",
                table: "Cobros",
                column: "IdPedido");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_IdCliente",
                table: "Pedidos",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_IdReceta",
                table: "Pedidos",
                column: "IdReceta");

            migrationBuilder.CreateIndex(
                name: "IX_Recetas_IdCliente",
                table: "Recetas",
                column: "IdCliente");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cobros");

            migrationBuilder.DropTable(
                name: "Facturas");

            migrationBuilder.DropTable(
                name: "Pedidos");

            migrationBuilder.DropTable(
                name: "Recetas");

            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}
