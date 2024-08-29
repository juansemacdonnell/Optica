using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OpticaSurinV2.Migrations
{
    /// <inheritdoc />
    public partial class obrasciales : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "DineroObraSocial",
                table: "Cobros",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "NombreObraSocial",
                table: "Cobros",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DineroObraSocial",
                table: "Cobros");

            migrationBuilder.DropColumn(
                name: "NombreObraSocial",
                table: "Cobros");
        }
    }
}
