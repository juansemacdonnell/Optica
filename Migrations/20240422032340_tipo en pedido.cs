using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OpticaSurinV2.Migrations
{
    /// <inheritdoc />
    public partial class tipoenpedido : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Tipo",
                table: "Pedidos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tipo",
                table: "Pedidos");
        }
    }
}
