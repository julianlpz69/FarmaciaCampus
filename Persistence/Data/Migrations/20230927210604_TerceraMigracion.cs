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
                name: "FK_cliente_tipo_documento_TipoDocumentoId",
                table: "cliente");

            migrationBuilder.DropForeignKey(
                name: "FK_Empleado_tipo_documento_TipoDocumentoId",
                table: "Empleado");

            migrationBuilder.DropIndex(
                name: "IX_Empleado_TipoDocumentoId",
                table: "Empleado");

            migrationBuilder.DropIndex(
                name: "IX_cliente_TipoDocumentoId",
                table: "cliente");

            migrationBuilder.DropColumn(
                name: "TipoDocumentoId",
                table: "Empleado");

            migrationBuilder.DropColumn(
                name: "TipoDocumentoId",
                table: "cliente");

            migrationBuilder.CreateIndex(
                name: "IX_Empleado_IdTipoDocumentoFK",
                table: "Empleado",
                column: "IdTipoDocumentoFK");

            migrationBuilder.CreateIndex(
                name: "IX_cliente_IdTipoDocumentoFK",
                table: "cliente",
                column: "IdTipoDocumentoFK");

            migrationBuilder.AddForeignKey(
                name: "FK_cliente_tipo_documento_IdTipoDocumentoFK",
                table: "cliente",
                column: "IdTipoDocumentoFK",
                principalTable: "tipo_documento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Empleado_tipo_documento_IdTipoDocumentoFK",
                table: "Empleado",
                column: "IdTipoDocumentoFK",
                principalTable: "tipo_documento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cliente_tipo_documento_IdTipoDocumentoFK",
                table: "cliente");

            migrationBuilder.DropForeignKey(
                name: "FK_Empleado_tipo_documento_IdTipoDocumentoFK",
                table: "Empleado");

            migrationBuilder.DropIndex(
                name: "IX_Empleado_IdTipoDocumentoFK",
                table: "Empleado");

            migrationBuilder.DropIndex(
                name: "IX_cliente_IdTipoDocumentoFK",
                table: "cliente");

            migrationBuilder.AddColumn<int>(
                name: "TipoDocumentoId",
                table: "Empleado",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TipoDocumentoId",
                table: "cliente",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Empleado_TipoDocumentoId",
                table: "Empleado",
                column: "TipoDocumentoId");

            migrationBuilder.CreateIndex(
                name: "IX_cliente_TipoDocumentoId",
                table: "cliente",
                column: "TipoDocumentoId");

            migrationBuilder.AddForeignKey(
                name: "FK_cliente_tipo_documento_TipoDocumentoId",
                table: "cliente",
                column: "TipoDocumentoId",
                principalTable: "tipo_documento",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Empleado_tipo_documento_TipoDocumentoId",
                table: "Empleado",
                column: "TipoDocumentoId",
                principalTable: "tipo_documento",
                principalColumn: "Id");
        }
    }
}
