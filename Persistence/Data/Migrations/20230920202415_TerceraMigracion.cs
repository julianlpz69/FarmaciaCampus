using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Data.Migrations
{
    /// <inheritdoc />
    public partial class TerceraMigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_factura_venta_persona_IdFacturaBaseFk",
                table: "factura_venta");

            migrationBuilder.DropTable(
                name: "persona");

            migrationBuilder.DropTable(
                name: "cargo");

            migrationBuilder.DropTable(
                name: "tipo_persona");

            migrationBuilder.DropColumn(
                name: "DireccionProveedor",
                table: "proveedor");

            migrationBuilder.RenameColumn(
                name: "IdPacienteFk",
                table: "factura_venta",
                newName: "IdEmpleadoFK");

            migrationBuilder.AddColumn<int>(
                name: "IdDireccionFK",
                table: "proveedor",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdMarcaFK",
                table: "medicamento",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdClienteFK",
                table: "factura_venta",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Carrera",
                table: "direccion",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Complemento",
                table: "direccion",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "TipoVia",
                table: "direccion",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "cargoEmpleado",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NombreCargo = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cargoEmpleado", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "cliente",
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
                    IdDireccionFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cliente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_cliente_direccion_IdDireccionFk",
                        column: x => x.IdDireccionFk,
                        principalTable: "direccion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "marca",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NombreMarca = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_marca", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Empleado",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdCargoEmpleadoFK = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Apellido = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Cedula = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Telefono = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdDireccionFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleado", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Empleado_cargoEmpleado_IdCargoEmpleadoFK",
                        column: x => x.IdCargoEmpleadoFK,
                        principalTable: "cargoEmpleado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Empleado_direccion_IdDireccionFk",
                        column: x => x.IdDireccionFk,
                        principalTable: "direccion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_proveedor_IdDireccionFK",
                table: "proveedor",
                column: "IdDireccionFK");

            migrationBuilder.CreateIndex(
                name: "IX_medicamento_IdMarcaFK",
                table: "medicamento",
                column: "IdMarcaFK");

            migrationBuilder.CreateIndex(
                name: "IX_factura_venta_IdClienteFK",
                table: "factura_venta",
                column: "IdClienteFK");

            migrationBuilder.CreateIndex(
                name: "IX_factura_venta_IdEmpleadoFK",
                table: "factura_venta",
                column: "IdEmpleadoFK");

            migrationBuilder.CreateIndex(
                name: "IX_cliente_IdDireccionFk",
                table: "cliente",
                column: "IdDireccionFk");

            migrationBuilder.CreateIndex(
                name: "IX_Empleado_IdCargoEmpleadoFK",
                table: "Empleado",
                column: "IdCargoEmpleadoFK");

            migrationBuilder.CreateIndex(
                name: "IX_Empleado_IdDireccionFk",
                table: "Empleado",
                column: "IdDireccionFk");

            migrationBuilder.AddForeignKey(
                name: "FK_factura_venta_Empleado_IdEmpleadoFK",
                table: "factura_venta",
                column: "IdEmpleadoFK",
                principalTable: "Empleado",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_factura_venta_cliente_IdClienteFK",
                table: "factura_venta",
                column: "IdClienteFK",
                principalTable: "cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_medicamento_marca_IdMarcaFK",
                table: "medicamento",
                column: "IdMarcaFK",
                principalTable: "marca",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_proveedor_direccion_IdDireccionFK",
                table: "proveedor",
                column: "IdDireccionFK",
                principalTable: "direccion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_factura_venta_Empleado_IdEmpleadoFK",
                table: "factura_venta");

            migrationBuilder.DropForeignKey(
                name: "FK_factura_venta_cliente_IdClienteFK",
                table: "factura_venta");

            migrationBuilder.DropForeignKey(
                name: "FK_medicamento_marca_IdMarcaFK",
                table: "medicamento");

            migrationBuilder.DropForeignKey(
                name: "FK_proveedor_direccion_IdDireccionFK",
                table: "proveedor");

            migrationBuilder.DropTable(
                name: "cliente");

            migrationBuilder.DropTable(
                name: "Empleado");

            migrationBuilder.DropTable(
                name: "marca");

            migrationBuilder.DropTable(
                name: "cargoEmpleado");

            migrationBuilder.DropIndex(
                name: "IX_proveedor_IdDireccionFK",
                table: "proveedor");

            migrationBuilder.DropIndex(
                name: "IX_medicamento_IdMarcaFK",
                table: "medicamento");

            migrationBuilder.DropIndex(
                name: "IX_factura_venta_IdClienteFK",
                table: "factura_venta");

            migrationBuilder.DropIndex(
                name: "IX_factura_venta_IdEmpleadoFK",
                table: "factura_venta");

            migrationBuilder.DropColumn(
                name: "IdDireccionFK",
                table: "proveedor");

            migrationBuilder.DropColumn(
                name: "IdMarcaFK",
                table: "medicamento");

            migrationBuilder.DropColumn(
                name: "IdClienteFK",
                table: "factura_venta");

            migrationBuilder.DropColumn(
                name: "Carrera",
                table: "direccion");

            migrationBuilder.DropColumn(
                name: "Complemento",
                table: "direccion");

            migrationBuilder.DropColumn(
                name: "TipoVia",
                table: "direccion");

            migrationBuilder.RenameColumn(
                name: "IdEmpleadoFK",
                table: "factura_venta",
                newName: "IdPacienteFk");

            migrationBuilder.AddColumn<string>(
                name: "DireccionProveedor",
                table: "proveedor",
                type: "varchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "")
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
                name: "persona",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdCargoFk = table.Column<int>(type: "int", nullable: false),
                    IdDireccionFk = table.Column<int>(type: "int", nullable: false),
                    IdTipoPersonaFk = table.Column<int>(type: "int", nullable: false),
                    Apellido = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Cedula = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaContratacion = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Telefono = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
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

            migrationBuilder.AddForeignKey(
                name: "FK_factura_venta_persona_IdFacturaBaseFk",
                table: "factura_venta",
                column: "IdFacturaBaseFk",
                principalTable: "persona",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
