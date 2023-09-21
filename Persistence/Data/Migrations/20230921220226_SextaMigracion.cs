using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Data.Migrations
{
    /// <inheritdoc />
    public partial class SextaMigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_factura_compra_factura_base_IdFacturaBaseFk",
                table: "factura_compra");

            migrationBuilder.DropForeignKey(
                name: "FK_factura_venta_factura_base_IdFacturaBaseFk",
                table: "factura_venta");

            migrationBuilder.DropForeignKey(
                name: "FK_medicamento_compra_factura_compra_IdCompraFK",
                table: "medicamento_compra");

            migrationBuilder.DropTable(
                name: "factura_base");

            migrationBuilder.DropColumn(
                name: "IdFacturaFk",
                table: "medicamento_venta");

            migrationBuilder.RenameColumn(
                name: "IdCompraFK",
                table: "medicamento_compra",
                newName: "IdFacturaCompraFK");

            migrationBuilder.RenameIndex(
                name: "IX_medicamento_compra_IdCompraFK",
                table: "medicamento_compra",
                newName: "IX_medicamento_compra_IdFacturaCompraFK");

            migrationBuilder.RenameColumn(
                name: "IdFacturaBaseFk",
                table: "factura_venta",
                newName: "IdMetodoPagoFK");

            migrationBuilder.RenameIndex(
                name: "IX_factura_venta_IdFacturaBaseFk",
                table: "factura_venta",
                newName: "IX_factura_venta_IdMetodoPagoFK");

            migrationBuilder.RenameColumn(
                name: "IdFacturaBaseFk",
                table: "factura_compra",
                newName: "IdMetodoPagoFK");

            migrationBuilder.RenameIndex(
                name: "IX_factura_compra_IdFacturaBaseFk",
                table: "factura_compra",
                newName: "IX_factura_compra_IdMetodoPagoFK");

            migrationBuilder.AddColumn<bool>(
                name: "RequiereReceta",
                table: "medicamento",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaVenta",
                table: "factura_venta",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<double>(
                name: "ValorTotal",
                table: "factura_venta",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaCompra",
                table: "factura_compra",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<double>(
                name: "ValorTotal",
                table: "factura_compra",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateTable(
                name: "receta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Remitente = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Descripcion = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdFacturaVentaFK = table.Column<int>(type: "int", nullable: false),
                    FacturaVentaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_receta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_receta_factura_venta_FacturaVentaId",
                        column: x => x.FacturaVentaId,
                        principalTable: "factura_venta",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_receta_FacturaVentaId",
                table: "receta",
                column: "FacturaVentaId");

            migrationBuilder.AddForeignKey(
                name: "FK_factura_compra_metodo_pago_IdMetodoPagoFK",
                table: "factura_compra",
                column: "IdMetodoPagoFK",
                principalTable: "metodo_pago",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_factura_venta_metodo_pago_IdMetodoPagoFK",
                table: "factura_venta",
                column: "IdMetodoPagoFK",
                principalTable: "metodo_pago",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_medicamento_compra_factura_compra_IdFacturaCompraFK",
                table: "medicamento_compra",
                column: "IdFacturaCompraFK",
                principalTable: "factura_compra",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_factura_compra_metodo_pago_IdMetodoPagoFK",
                table: "factura_compra");

            migrationBuilder.DropForeignKey(
                name: "FK_factura_venta_metodo_pago_IdMetodoPagoFK",
                table: "factura_venta");

            migrationBuilder.DropForeignKey(
                name: "FK_medicamento_compra_factura_compra_IdFacturaCompraFK",
                table: "medicamento_compra");

            migrationBuilder.DropTable(
                name: "receta");

            migrationBuilder.DropColumn(
                name: "RequiereReceta",
                table: "medicamento");

            migrationBuilder.DropColumn(
                name: "FechaVenta",
                table: "factura_venta");

            migrationBuilder.DropColumn(
                name: "ValorTotal",
                table: "factura_venta");

            migrationBuilder.DropColumn(
                name: "FechaCompra",
                table: "factura_compra");

            migrationBuilder.DropColumn(
                name: "ValorTotal",
                table: "factura_compra");

            migrationBuilder.RenameColumn(
                name: "IdFacturaCompraFK",
                table: "medicamento_compra",
                newName: "IdCompraFK");

            migrationBuilder.RenameIndex(
                name: "IX_medicamento_compra_IdFacturaCompraFK",
                table: "medicamento_compra",
                newName: "IX_medicamento_compra_IdCompraFK");

            migrationBuilder.RenameColumn(
                name: "IdMetodoPagoFK",
                table: "factura_venta",
                newName: "IdFacturaBaseFk");

            migrationBuilder.RenameIndex(
                name: "IX_factura_venta_IdMetodoPagoFK",
                table: "factura_venta",
                newName: "IX_factura_venta_IdFacturaBaseFk");

            migrationBuilder.RenameColumn(
                name: "IdMetodoPagoFK",
                table: "factura_compra",
                newName: "IdFacturaBaseFk");

            migrationBuilder.RenameIndex(
                name: "IX_factura_compra_IdMetodoPagoFK",
                table: "factura_compra",
                newName: "IX_factura_compra_IdFacturaBaseFk");

            migrationBuilder.AddColumn<int>(
                name: "IdFacturaFk",
                table: "medicamento_venta",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "factura_base",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdMetodoPagoFK = table.Column<int>(type: "int", nullable: false),
                    CodigoCompra = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaSalida = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Total = table.Column<int>(type: "int", nullable: false),
                    TotalIva = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_factura_base", x => x.Id);
                    table.ForeignKey(
                        name: "FK_factura_base_metodo_pago_IdMetodoPagoFK",
                        column: x => x.IdMetodoPagoFK,
                        principalTable: "metodo_pago",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_factura_base_CodigoCompra",
                table: "factura_base",
                column: "CodigoCompra",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_factura_base_IdMetodoPagoFK",
                table: "factura_base",
                column: "IdMetodoPagoFK");

            migrationBuilder.AddForeignKey(
                name: "FK_factura_compra_factura_base_IdFacturaBaseFk",
                table: "factura_compra",
                column: "IdFacturaBaseFk",
                principalTable: "factura_base",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_factura_venta_factura_base_IdFacturaBaseFk",
                table: "factura_venta",
                column: "IdFacturaBaseFk",
                principalTable: "factura_base",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_medicamento_compra_factura_compra_IdCompraFK",
                table: "medicamento_compra",
                column: "IdCompraFK",
                principalTable: "factura_compra",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
