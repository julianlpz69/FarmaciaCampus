using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Data.Migrations
{
    /// <inheritdoc />
    public partial class NovenaMigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_receta_factura_venta_FacturaVentaId",
                table: "receta");

            migrationBuilder.DropIndex(
                name: "IX_receta_FacturaVentaId",
                table: "receta");

            migrationBuilder.DropColumn(
                name: "FacturaVentaId",
                table: "receta");

            migrationBuilder.UpdateData(
                table: "receta",
                keyColumn: "Remitente",
                keyValue: null,
                column: "Remitente",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Remitente",
                table: "receta",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "receta",
                keyColumn: "Descripcion",
                keyValue: null,
                column: "Descripcion",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "receta",
                type: "varchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<double>(
                name: "ValorTotalMasIva",
                table: "factura_venta",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateIndex(
                name: "IX_receta_IdFacturaVentaFK",
                table: "receta",
                column: "IdFacturaVentaFK");

            migrationBuilder.AddForeignKey(
                name: "FK_receta_factura_venta_IdFacturaVentaFK",
                table: "receta",
                column: "IdFacturaVentaFK",
                principalTable: "factura_venta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_receta_factura_venta_IdFacturaVentaFK",
                table: "receta");

            migrationBuilder.DropIndex(
                name: "IX_receta_IdFacturaVentaFK",
                table: "receta");

            migrationBuilder.DropColumn(
                name: "ValorTotalMasIva",
                table: "factura_venta");

            migrationBuilder.AlterColumn<string>(
                name: "Remitente",
                table: "receta",
                type: "varchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "receta",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(200)",
                oldMaxLength: 200)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "FacturaVentaId",
                table: "receta",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_receta_FacturaVentaId",
                table: "receta",
                column: "FacturaVentaId");

            migrationBuilder.AddForeignKey(
                name: "FK_receta_factura_venta_FacturaVentaId",
                table: "receta",
                column: "FacturaVentaId",
                principalTable: "factura_venta",
                principalColumn: "Id");
        }
    }
}
