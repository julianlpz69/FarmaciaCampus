using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Data.Migrations
{
    /// <inheritdoc />
    public partial class mig1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "cargo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cargo", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "metodo_pago",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_metodo_pago", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "pais",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pais", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "proveedor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NombreProveedor = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ContactoProveedor = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DireccionProveedor = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_proveedor", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tipo_persona",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipo_persona", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "factura_base",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Total = table.Column<int>(type: "int", nullable: false),
                    TotalIva = table.Column<int>(type: "int", nullable: false),
                    CodigoCompra = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaSalida = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IdMetodoCompra = table.Column<int>(type: "int", nullable: false),
                    MetodoCompraId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_factura_base", x => x.Id);
                    table.ForeignKey(
                        name: "FK_factura_base_metodo_pago_MetodoCompraId",
                        column: x => x.MetodoCompraId,
                        principalTable: "metodo_pago",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "departamento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdPaisFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_departamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_departamento_pais_IdPaisFk",
                        column: x => x.IdPaisFk,
                        principalTable: "pais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "medicamento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NombreMedicamento = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PrecioMedicamento = table.Column<decimal>(type: "decimal(10,6)", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    FechaExpiracion = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IdProveedorFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_medicamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_medicamento_proveedor_IdProveedorFK",
                        column: x => x.IdProveedorFK,
                        principalTable: "proveedor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "factura_compra",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdFacturaBaseFk = table.Column<int>(type: "int", nullable: false),
                    IdProveedorFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_factura_compra", x => x.Id);
                    table.ForeignKey(
                        name: "FK_factura_compra_factura_base_IdFacturaBaseFk",
                        column: x => x.IdFacturaBaseFk,
                        principalTable: "factura_base",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_factura_compra_proveedor_IdProveedorFk",
                        column: x => x.IdProveedorFk,
                        principalTable: "proveedor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ciudad",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdDepartamentoFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ciudad", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ciudad_departamento_IdDepartamentoFk",
                        column: x => x.IdDepartamentoFk,
                        principalTable: "departamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "medicamento_compra",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdCompraFK = table.Column<int>(type: "int", nullable: false),
                    IdMedicamentoFK = table.Column<int>(type: "int", nullable: false),
                    CantidadComprada = table.Column<int>(type: "int", nullable: false),
                    PrecioCompra = table.Column<decimal>(type: "decimal(10,6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_medicamento_compra", x => x.Id);
                    table.ForeignKey(
                        name: "FK_medicamento_compra_factura_compra_IdCompraFK",
                        column: x => x.IdCompraFK,
                        principalTable: "factura_compra",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_medicamento_compra_medicamento_IdMedicamentoFK",
                        column: x => x.IdMedicamentoFK,
                        principalTable: "medicamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "direccion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdCiudadFk = table.Column<int>(type: "int", nullable: false),
                    Calle = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Numero = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_direccion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_direccion_ciudad_IdCiudadFk",
                        column: x => x.IdCiudadFk,
                        principalTable: "ciudad",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "persona",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Apellido = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Cedula = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Telefono = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaContratacion = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IdDireccionFk = table.Column<int>(type: "int", nullable: false),
                    IdTipoPersonaFk = table.Column<int>(type: "int", nullable: false),
                    IdCargoFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_persona", x => x.Id);
                    table.ForeignKey(
                        name: "FK_persona_cargo_IdCargoFk",
                        column: x => x.IdCargoFk,
                        principalTable: "cargo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_persona_direccion_IdDireccionFk",
                        column: x => x.IdDireccionFk,
                        principalTable: "direccion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_persona_tipo_persona_IdTipoPersonaFk",
                        column: x => x.IdTipoPersonaFk,
                        principalTable: "tipo_persona",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "factura_venta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdFacturaBaseFk = table.Column<int>(type: "int", nullable: false),
                    IdPacienteFk = table.Column<int>(type: "int", nullable: false),
                    MetodoCompraId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_factura_venta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_factura_venta_factura_base_IdFacturaBaseFk",
                        column: x => x.IdFacturaBaseFk,
                        principalTable: "factura_base",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_factura_venta_metodo_pago_MetodoCompraId",
                        column: x => x.MetodoCompraId,
                        principalTable: "metodo_pago",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_factura_venta_persona_IdFacturaBaseFk",
                        column: x => x.IdFacturaBaseFk,
                        principalTable: "persona",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "medicamento_venta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdFacturaVentaFK = table.Column<int>(type: "int", nullable: false),
                    IdMedicamentoFK = table.Column<int>(type: "int", nullable: false),
                    CantidadVendida = table.Column<int>(type: "int", nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(10,6)", nullable: false),
                    IdFacturaFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_medicamento_venta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_medicamento_venta_factura_venta_IdFacturaVentaFK",
                        column: x => x.IdFacturaVentaFK,
                        principalTable: "factura_venta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_medicamento_venta_medicamento_IdMedicamentoFK",
                        column: x => x.IdMedicamentoFK,
                        principalTable: "medicamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_ciudad_IdDepartamentoFk",
                table: "ciudad",
                column: "IdDepartamentoFk");

            migrationBuilder.CreateIndex(
                name: "IX_departamento_IdPaisFk",
                table: "departamento",
                column: "IdPaisFk");

            migrationBuilder.CreateIndex(
                name: "IX_direccion_IdCiudadFk",
                table: "direccion",
                column: "IdCiudadFk");

            migrationBuilder.CreateIndex(
                name: "IX_factura_base_CodigoCompra",
                table: "factura_base",
                column: "CodigoCompra",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_factura_base_MetodoCompraId",
                table: "factura_base",
                column: "MetodoCompraId");

            migrationBuilder.CreateIndex(
                name: "IX_factura_compra_IdFacturaBaseFk",
                table: "factura_compra",
                column: "IdFacturaBaseFk");

            migrationBuilder.CreateIndex(
                name: "IX_factura_compra_IdProveedorFk",
                table: "factura_compra",
                column: "IdProveedorFk");

            migrationBuilder.CreateIndex(
                name: "IX_factura_venta_IdFacturaBaseFk",
                table: "factura_venta",
                column: "IdFacturaBaseFk");

            migrationBuilder.CreateIndex(
                name: "IX_factura_venta_MetodoCompraId",
                table: "factura_venta",
                column: "MetodoCompraId");

            migrationBuilder.CreateIndex(
                name: "IX_medicamento_IdProveedorFK",
                table: "medicamento",
                column: "IdProveedorFK");

            migrationBuilder.CreateIndex(
                name: "IX_medicamento_compra_IdCompraFK",
                table: "medicamento_compra",
                column: "IdCompraFK");

            migrationBuilder.CreateIndex(
                name: "IX_medicamento_compra_IdMedicamentoFK",
                table: "medicamento_compra",
                column: "IdMedicamentoFK");

            migrationBuilder.CreateIndex(
                name: "IX_medicamento_venta_IdFacturaVentaFK",
                table: "medicamento_venta",
                column: "IdFacturaVentaFK");

            migrationBuilder.CreateIndex(
                name: "IX_medicamento_venta_IdMedicamentoFK",
                table: "medicamento_venta",
                column: "IdMedicamentoFK");

            migrationBuilder.CreateIndex(
                name: "IX_persona_Cedula",
                table: "persona",
                column: "Cedula",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_persona_IdCargoFk",
                table: "persona",
                column: "IdCargoFk");

            migrationBuilder.CreateIndex(
                name: "IX_persona_IdDireccionFk",
                table: "persona",
                column: "IdDireccionFk");

            migrationBuilder.CreateIndex(
                name: "IX_persona_IdTipoPersonaFk",
                table: "persona",
                column: "IdTipoPersonaFk");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "medicamento_compra");

            migrationBuilder.DropTable(
                name: "medicamento_venta");

            migrationBuilder.DropTable(
                name: "factura_compra");

            migrationBuilder.DropTable(
                name: "factura_venta");

            migrationBuilder.DropTable(
                name: "medicamento");

            migrationBuilder.DropTable(
                name: "factura_base");

            migrationBuilder.DropTable(
                name: "persona");

            migrationBuilder.DropTable(
                name: "proveedor");

            migrationBuilder.DropTable(
                name: "metodo_pago");

            migrationBuilder.DropTable(
                name: "cargo");

            migrationBuilder.DropTable(
                name: "direccion");

            migrationBuilder.DropTable(
                name: "tipo_persona");

            migrationBuilder.DropTable(
                name: "ciudad");

            migrationBuilder.DropTable(
                name: "departamento");

            migrationBuilder.DropTable(
                name: "pais");
        }
    }
}
