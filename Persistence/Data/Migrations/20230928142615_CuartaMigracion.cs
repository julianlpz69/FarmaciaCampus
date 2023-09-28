using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Data.Migrations
{
    /// <inheritdoc />
    public partial class CuartaMigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "direccion",
                columns: new[] { "Id", "Calle", "Carrera", "Complemento", "IdCiudadFk", "Numero", "TipoVia" },
                values: new object[,]
                {
                    { 1, "70", "15", "sopas", 1, "12", "via" },
                    { 2, "71", "15", "sopas", 2, "12", "via" },
                    { 3, "72", "15", "sopas", 3, "12", "via" }
                });

            migrationBuilder.InsertData(
                table: "marca",
                columns: new[] { "Id", "NombreMarca" },
                values: new object[,]
                {
                    { 1, "Sesderma" },
                    { 2, "Bayer" },
                    { 3, "Pfizer " }
                });

            migrationBuilder.InsertData(
                table: "proveedor",
                columns: new[] { "Id", "ContactoProveedor", "IdDireccionFK", "NITProveedor", "NombreProveedor" },
                values: new object[,]
                {
                    { 1, "31231", 1, "12324", "Sesderma" },
                    { 2, "31231", 2, "12324", "Bayer" },
                    { 3, "31231", 3, "12324", "Pfizer " }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "marca",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "marca",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "marca",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "proveedor",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "proveedor",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "proveedor",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "direccion",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "direccion",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "direccion",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
