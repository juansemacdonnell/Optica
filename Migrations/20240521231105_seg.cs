using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OpticaSurinV2.Migrations
{
    /// <inheritdoc />
    public partial class seg : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "IdReceta",
                table: "Pedidos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "IdReceta",
                table: "Pedidos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
