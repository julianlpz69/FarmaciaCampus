using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Data.Migrations
{
    /// <inheritdoc />
    public partial class SegundaMigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
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
                name: "tipo_documento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NombreTipoDocumento = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipo_documento", x => x.Id);
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
                name: "UserRol",
                columns: table => new
                {
                    IdUser = table.Column<int>(type: "int", nullable: false),
                    IdRol = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRol", x => new { x.IdUser, x.IdRol });
                    table.ForeignKey(
                        name: "FK_UserRol_rol_IdRol",
                        column: x => x.IdRol,
                        principalTable: "rol",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRol_user_IdUser",
                        column: x => x.IdUser,
                        principalTable: "user",
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
                name: "direccion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdCiudadFk = table.Column<int>(type: "int", nullable: false),
                    TipoVia = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Calle = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Carrera = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Numero = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Complemento = table.Column<string>(type: "longtext", nullable: true)
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
                    IdTipoDocumentoFK = table.Column<int>(type: "int", nullable: false),
                    TipoDocumentoId = table.Column<int>(type: "int", nullable: true),
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
                    table.ForeignKey(
                        name: "FK_cliente_tipo_documento_TipoDocumentoId",
                        column: x => x.TipoDocumentoId,
                        principalTable: "tipo_documento",
                        principalColumn: "Id");
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
                    IdTipoDocumentoFK = table.Column<int>(type: "int", nullable: false),
                    TipoDocumentoId = table.Column<int>(type: "int", nullable: true),
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
                    table.ForeignKey(
                        name: "FK_Empleado_tipo_documento_TipoDocumentoId",
                        column: x => x.TipoDocumentoId,
                        principalTable: "tipo_documento",
                        principalColumn: "Id");
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
                    NITProveedor = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ContactoProveedor = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdDireccionFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_proveedor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_proveedor_direccion_IdDireccionFK",
                        column: x => x.IdDireccionFK,
                        principalTable: "direccion",
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
                    IdEmpleadoFK = table.Column<int>(type: "int", nullable: false),
                    IdClienteFK = table.Column<int>(type: "int", nullable: false),
                    ValorTotal = table.Column<double>(type: "double", nullable: false),
                    ValorTotalMasIva = table.Column<double>(type: "double", nullable: false),
                    FechaVenta = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IdMetodoPagoFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_factura_venta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_factura_venta_Empleado_IdEmpleadoFK",
                        column: x => x.IdEmpleadoFK,
                        principalTable: "Empleado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_factura_venta_cliente_IdClienteFK",
                        column: x => x.IdClienteFK,
                        principalTable: "cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_factura_venta_metodo_pago_IdMetodoPagoFK",
                        column: x => x.IdMetodoPagoFK,
                        principalTable: "metodo_pago",
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
                    ValorTotal = table.Column<double>(type: "double", nullable: false),
                    FechaCompra = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IdMetodoPagoFK = table.Column<int>(type: "int", nullable: false),
                    IdProveedorFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_factura_compra", x => x.Id);
                    table.ForeignKey(
                        name: "FK_factura_compra_metodo_pago_IdMetodoPagoFK",
                        column: x => x.IdMetodoPagoFK,
                        principalTable: "metodo_pago",
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
                name: "medicamento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NombreMedicamento = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PrecioMedicamento = table.Column<decimal>(type: "decimal(10,6)", nullable: false),
                    RequiereReceta = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    FechaExpiracion = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IdProveedorFK = table.Column<int>(type: "int", nullable: false),
                    IdMarcaFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_medicamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_medicamento_marca_IdMarcaFK",
                        column: x => x.IdMarcaFK,
                        principalTable: "marca",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_medicamento_proveedor_IdProveedorFK",
                        column: x => x.IdProveedorFK,
                        principalTable: "proveedor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "receta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdFacturaVentaFK = table.Column<int>(type: "int", nullable: false),
                    Remitente = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Descripcion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_receta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_receta_factura_venta_IdFacturaVentaFK",
                        column: x => x.IdFacturaVentaFK,
                        principalTable: "factura_venta",
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
                    IdFacturaCompraFK = table.Column<int>(type: "int", nullable: false),
                    IdMedicamentoFK = table.Column<int>(type: "int", nullable: false),
                    CantidadComprada = table.Column<int>(type: "int", nullable: false),
                    PrecioCompra = table.Column<decimal>(type: "decimal(10,6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_medicamento_compra", x => x.Id);
                    table.ForeignKey(
                        name: "FK_medicamento_compra_factura_compra_IdFacturaCompraFK",
                        column: x => x.IdFacturaCompraFK,
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
                name: "medicamento_venta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdFacturaVentaFK = table.Column<int>(type: "int", nullable: false),
                    IdMedicamentoFK = table.Column<int>(type: "int", nullable: false),
                    CantidadVendida = table.Column<int>(type: "int", nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(10,6)", nullable: false)
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

            migrationBuilder.InsertData(
                table: "cargoEmpleado",
                columns: new[] { "Id", "NombreCargo" },
                values: new object[,]
                {
                    { 1, "Gerente" },
                    { 2, "Enfermero" },
                    { 3, "Cajero" },
                    { 4, "Auxiliar" }
                });

            migrationBuilder.InsertData(
                table: "pais",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 1, "Argentina" },
                    { 2, "Brasil" },
                    { 3, "México" },
                    { 4, "España" },
                    { 5, "Estados Unidos" }
                });

            migrationBuilder.InsertData(
                table: "rol",
                columns: new[] { "Id", "rolName" },
                values: new object[,]
                {
                    { 1, "Empleado" },
                    { 2, "Administrador" }
                });

            migrationBuilder.InsertData(
                table: "tipo_documento",
                columns: new[] { "Id", "NombreTipoDocumento" },
                values: new object[,]
                {
                    { 1, "Cedula Ciudadania" },
                    { 2, "Tarjeta Identidad" },
                    { 3, "Pasaporte" },
                    { 4, "Cedula Extranjeria" },
                    { 5, "PPT" }
                });

            migrationBuilder.InsertData(
                table: "user",
                columns: new[] { "Id", "email", "username", "password" },
                values: new object[] { 1, "julianjoselpz2019@gmail.com", "Julian", "AQAAAAIAAYagAAAAEKy7eDL9kR5DnZeJjwgco1cVJjlU0ExskyNJoN8vHBvzMrhlYNKQ1F+ff2M/FTiE7A==" });

            migrationBuilder.InsertData(
                table: "UserRol",
                columns: new[] { "IdRol", "IdUser" },
                values: new object[] { 2, 1 });

            migrationBuilder.InsertData(
                table: "departamento",
                columns: new[] { "Id", "IdPaisFk", "Nombre" },
                values: new object[,]
                {
                    { 1, 1, "Buenos Aires" },
                    { 2, 1, "Córdoba" },
                    { 3, 2, "Río de Janeiro" },
                    { 4, 2, "São Paulo" },
                    { 5, 3, "Departamento de México" },
                    { 6, 3, "Monterrey" },
                    { 7, 4, "Madrid" },
                    { 8, 4, "Barcelona" },
                    { 9, 5, "Nueva York" },
                    { 10, 5, "Chicago" }
                });

            migrationBuilder.InsertData(
                table: "ciudad",
                columns: new[] { "Id", "IdDepartamentoFk", "Nombre" },
                values: new object[,]
                {
                    { 1, 1, "Buenos Aires 1" },
                    { 2, 1, "Buenos Aires 2" },
                    { 3, 2, "Córdoba 1" },
                    { 4, 2, "Córdoba 2" },
                    { 5, 3, "Río de Janeiro 1" },
                    { 6, 3, "Río de Janeiro 2" },
                    { 7, 4, "São Paulo 1" },
                    { 8, 4, "São Paulo 2" },
                    { 9, 5, "Estado de México 1" },
                    { 10, 5, "Estado de México 2" },
                    { 11, 6, "Jalisco 1" },
                    { 12, 6, "Jalisco 2" },
                    { 13, 7, "Madrid 1" },
                    { 14, 7, "Madrid 2" },
                    { 15, 8, "Barcelona 1" },
                    { 16, 8, "Barcelona 2" },
                    { 17, 9, "Nueva York 1" },
                    { 18, 9, "Nueva York 2" },
                    { 19, 10, "Chicago 1" },
                    { 20, 10, "Chicago 2" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ciudad_IdDepartamentoFk",
                table: "ciudad",
                column: "IdDepartamentoFk");

            migrationBuilder.CreateIndex(
                name: "IX_cliente_IdDireccionFk",
                table: "cliente",
                column: "IdDireccionFk");

            migrationBuilder.CreateIndex(
                name: "IX_cliente_TipoDocumentoId",
                table: "cliente",
                column: "TipoDocumentoId");

            migrationBuilder.CreateIndex(
                name: "IX_departamento_IdPaisFk",
                table: "departamento",
                column: "IdPaisFk");

            migrationBuilder.CreateIndex(
                name: "IX_direccion_IdCiudadFk",
                table: "direccion",
                column: "IdCiudadFk");

            migrationBuilder.CreateIndex(
                name: "IX_Empleado_IdCargoEmpleadoFK",
                table: "Empleado",
                column: "IdCargoEmpleadoFK");

            migrationBuilder.CreateIndex(
                name: "IX_Empleado_IdDireccionFk",
                table: "Empleado",
                column: "IdDireccionFk");

            migrationBuilder.CreateIndex(
                name: "IX_Empleado_TipoDocumentoId",
                table: "Empleado",
                column: "TipoDocumentoId");

            migrationBuilder.CreateIndex(
                name: "IX_factura_compra_IdMetodoPagoFK",
                table: "factura_compra",
                column: "IdMetodoPagoFK");

            migrationBuilder.CreateIndex(
                name: "IX_factura_compra_IdProveedorFk",
                table: "factura_compra",
                column: "IdProveedorFk");

            migrationBuilder.CreateIndex(
                name: "IX_factura_venta_IdClienteFK",
                table: "factura_venta",
                column: "IdClienteFK");

            migrationBuilder.CreateIndex(
                name: "IX_factura_venta_IdEmpleadoFK",
                table: "factura_venta",
                column: "IdEmpleadoFK");

            migrationBuilder.CreateIndex(
                name: "IX_factura_venta_IdMetodoPagoFK",
                table: "factura_venta",
                column: "IdMetodoPagoFK");

            migrationBuilder.CreateIndex(
                name: "IX_medicamento_IdMarcaFK",
                table: "medicamento",
                column: "IdMarcaFK");

            migrationBuilder.CreateIndex(
                name: "IX_medicamento_IdProveedorFK",
                table: "medicamento",
                column: "IdProveedorFK");

            migrationBuilder.CreateIndex(
                name: "IX_medicamento_compra_IdFacturaCompraFK",
                table: "medicamento_compra",
                column: "IdFacturaCompraFK");

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
                name: "IX_proveedor_IdDireccionFK",
                table: "proveedor",
                column: "IdDireccionFK");

            migrationBuilder.CreateIndex(
                name: "IX_receta_IdFacturaVentaFK",
                table: "receta",
                column: "IdFacturaVentaFK");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshToken_UserId",
                table: "RefreshToken",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRol_IdRol",
                table: "UserRol",
                column: "IdRol");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "medicamento_compra");

            migrationBuilder.DropTable(
                name: "medicamento_venta");

            migrationBuilder.DropTable(
                name: "receta");

            migrationBuilder.DropTable(
                name: "RefreshToken");

            migrationBuilder.DropTable(
                name: "UserRol");

            migrationBuilder.DropTable(
                name: "factura_compra");

            migrationBuilder.DropTable(
                name: "medicamento");

            migrationBuilder.DropTable(
                name: "factura_venta");

            migrationBuilder.DropTable(
                name: "rol");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "marca");

            migrationBuilder.DropTable(
                name: "proveedor");

            migrationBuilder.DropTable(
                name: "Empleado");

            migrationBuilder.DropTable(
                name: "cliente");

            migrationBuilder.DropTable(
                name: "metodo_pago");

            migrationBuilder.DropTable(
                name: "cargoEmpleado");

            migrationBuilder.DropTable(
                name: "direccion");

            migrationBuilder.DropTable(
                name: "tipo_documento");

            migrationBuilder.DropTable(
                name: "ciudad");

            migrationBuilder.DropTable(
                name: "departamento");

            migrationBuilder.DropTable(
                name: "pais");
        }
    }
}
