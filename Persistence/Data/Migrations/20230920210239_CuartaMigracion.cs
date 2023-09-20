using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Data.Migrations
{
    /// <inheritdoc />
    public partial class CuartaMigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_factura_base_metodo_pago_MetodoCompraId",
                table: "factura_base");

            migrationBuilder.DropForeignKey(
                name: "FK_factura_venta_metodo_pago_MetodoCompraId",
                table: "factura_venta");

            migrationBuilder.DropIndex(
                name: "IX_factura_venta_MetodoCompraId",
                table: "factura_venta");

            migrationBuilder.DropIndex(
                name: "IX_factura_base_MetodoCompraId",
                table: "factura_base");

            migrationBuilder.DropColumn(
                name: "MetodoCompraId",
                table: "factura_venta");

            migrationBuilder.DropColumn(
                name: "MetodoCompraId",
                table: "factura_base");

            migrationBuilder.RenameColumn(
                name: "IdMetodoCompra",
                table: "factura_base",
                newName: "IdMetodoPagoFK");

            migrationBuilder.CreateTable(
                name: "rol",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    rolName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rol", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    username = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    password = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "RefreshToken",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Token = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Expires = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Revoked = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshToken", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshToken_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "userRol",
                columns: table => new
                {
                    IdUser = table.Column<int>(type: "int", nullable: false),
                    IdRol = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userRol", x => new { x.IdUser, x.IdRol });
                    table.ForeignKey(
                        name: "FK_userRol_rol_IdRol",
                        column: x => x.IdRol,
                        principalTable: "rol",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_userRol_user_IdUser",
                        column: x => x.IdUser,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_factura_base_IdMetodoPagoFK",
                table: "factura_base",
                column: "IdMetodoPagoFK");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshToken_UserId",
                table: "RefreshToken",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_userRol_IdRol",
                table: "userRol",
                column: "IdRol");

            migrationBuilder.AddForeignKey(
                name: "FK_factura_base_metodo_pago_IdMetodoPagoFK",
                table: "factura_base",
                column: "IdMetodoPagoFK",
                principalTable: "metodo_pago",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_factura_base_metodo_pago_IdMetodoPagoFK",
                table: "factura_base");

            migrationBuilder.DropTable(
                name: "RefreshToken");

            migrationBuilder.DropTable(
                name: "userRol");

            migrationBuilder.DropTable(
                name: "rol");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropIndex(
                name: "IX_factura_base_IdMetodoPagoFK",
                table: "factura_base");

            migrationBuilder.RenameColumn(
                name: "IdMetodoPagoFK",
                table: "factura_base",
                newName: "IdMetodoCompra");

            migrationBuilder.AddColumn<int>(
                name: "MetodoCompraId",
                table: "factura_venta",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MetodoCompraId",
                table: "factura_base",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_factura_venta_MetodoCompraId",
                table: "factura_venta",
                column: "MetodoCompraId");

            migrationBuilder.CreateIndex(
                name: "IX_factura_base_MetodoCompraId",
                table: "factura_base",
                column: "MetodoCompraId");

            migrationBuilder.AddForeignKey(
                name: "FK_factura_base_metodo_pago_MetodoCompraId",
                table: "factura_base",
                column: "MetodoCompraId",
                principalTable: "metodo_pago",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_factura_venta_metodo_pago_MetodoCompraId",
                table: "factura_venta",
                column: "MetodoCompraId",
                principalTable: "metodo_pago",
                principalColumn: "Id");
        }
    }
}
