﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence.Data;

#nullable disable

namespace Persistence.Data.Migrations
{
    [DbContext(typeof(FarmaciaDBContext))]
    [Migration("20230920202415_TerceraMigracion")]
    partial class TerceraMigracion
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Domain.Entities.CargoEmpleado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("NombreCargo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("cargoEmpleado", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Ciudad", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("IdDepartamentoFk")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("IdDepartamentoFk");

                    b.ToTable("ciudad", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Cedula")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("IdDireccionFk")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Telefono")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("IdDireccionFk");

                    b.ToTable("cliente", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Departamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("IdPaisFk")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("IdPaisFk");

                    b.ToTable("departamento", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Direccion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Calle")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Carrera")
                        .HasColumnType("longtext");

                    b.Property<string>("Complemento")
                        .HasColumnType("longtext");

                    b.Property<int>("IdCiudadFk")
                        .HasColumnType("int");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("TipoVia")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("IdCiudadFk");

                    b.ToTable("direccion", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Empleado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Cedula")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("IdCargoEmpleadoFK")
                        .HasColumnType("int");

                    b.Property<int>("IdDireccionFk")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Telefono")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("IdCargoEmpleadoFK");

                    b.HasIndex("IdDireccionFk");

                    b.ToTable("Empleado", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.FacturaBase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CodigoCompra")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime>("FechaSalida")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("IdMetodoCompra")
                        .HasColumnType("int");

                    b.Property<int?>("MetodoCompraId")
                        .HasColumnType("int");

                    b.Property<int>("Total")
                        .HasColumnType("int");

                    b.Property<int>("TotalIva")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CodigoCompra")
                        .IsUnique();

                    b.HasIndex("MetodoCompraId");

                    b.ToTable("factura_base", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.FacturaCompra", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("IdFacturaBaseFk")
                        .HasColumnType("int");

                    b.Property<int>("IdProveedorFk")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdFacturaBaseFk");

                    b.HasIndex("IdProveedorFk");

                    b.ToTable("factura_compra", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.FacturaVenta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("IdClienteFK")
                        .HasColumnType("int");

                    b.Property<int>("IdEmpleadoFK")
                        .HasColumnType("int");

                    b.Property<int>("IdFacturaBaseFk")
                        .HasColumnType("int");

                    b.Property<int?>("MetodoCompraId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdClienteFK");

                    b.HasIndex("IdEmpleadoFK");

                    b.HasIndex("IdFacturaBaseFk");

                    b.HasIndex("MetodoCompraId");

                    b.ToTable("factura_venta", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Marca", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("NombreMarca")
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.HasKey("Id");

                    b.ToTable("marca", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Medicamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaExpiracion")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("IdMarcaFK")
                        .HasColumnType("int");

                    b.Property<int>("IdProveedorFK")
                        .HasColumnType("int");

                    b.Property<string>("NombreMedicamento")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<decimal>("PrecioMedicamento")
                        .HasColumnType("decimal(10,6)");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdMarcaFK");

                    b.HasIndex("IdProveedorFK");

                    b.ToTable("medicamento", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.MedicamentoCompra", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CantidadComprada")
                        .HasColumnType("int");

                    b.Property<int>("IdCompraFK")
                        .HasColumnType("int");

                    b.Property<int>("IdMedicamentoFK")
                        .HasColumnType("int");

                    b.Property<decimal>("PrecioCompra")
                        .HasColumnType("decimal(10,6)");

                    b.HasKey("Id");

                    b.HasIndex("IdCompraFK");

                    b.HasIndex("IdMedicamentoFK");

                    b.ToTable("medicamento_compra", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.MedicamentoVenta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CantidadVendida")
                        .HasColumnType("int");

                    b.Property<int>("IdFacturaFk")
                        .HasColumnType("int");

                    b.Property<int>("IdFacturaVentaFK")
                        .HasColumnType("int");

                    b.Property<int>("IdMedicamentoFK")
                        .HasColumnType("int");

                    b.Property<decimal>("Precio")
                        .HasColumnType("decimal(10,6)");

                    b.HasKey("Id");

                    b.HasIndex("IdFacturaVentaFK");

                    b.HasIndex("IdMedicamentoFK");

                    b.ToTable("medicamento_venta", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.MetodoCompra", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("metodo_pago", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Pais", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("pais", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Proveedor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ContactoProveedor")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<int>("IdDireccionFK")
                        .HasColumnType("int");

                    b.Property<string>("NombreProveedor")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("IdDireccionFK");

                    b.ToTable("proveedor", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Ciudad", b =>
                {
                    b.HasOne("Domain.Entities.Departamento", "Departamento")
                        .WithMany("Ciudades")
                        .HasForeignKey("IdDepartamentoFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Departamento");
                });

            modelBuilder.Entity("Domain.Entities.Cliente", b =>
                {
                    b.HasOne("Domain.Entities.Direccion", "Direccion")
                        .WithMany("Clientes")
                        .HasForeignKey("IdDireccionFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Direccion");
                });

            modelBuilder.Entity("Domain.Entities.Departamento", b =>
                {
                    b.HasOne("Domain.Entities.Pais", "Pais")
                        .WithMany("Departamentos")
                        .HasForeignKey("IdPaisFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pais");
                });

            modelBuilder.Entity("Domain.Entities.Direccion", b =>
                {
                    b.HasOne("Domain.Entities.Ciudad", "Ciudad")
                        .WithMany("Direcciones")
                        .HasForeignKey("IdCiudadFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ciudad");
                });

            modelBuilder.Entity("Domain.Entities.Empleado", b =>
                {
                    b.HasOne("Domain.Entities.CargoEmpleado", "CargoEmpleado")
                        .WithMany("Empleados")
                        .HasForeignKey("IdCargoEmpleadoFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Direccion", "Direccion")
                        .WithMany("Empleados")
                        .HasForeignKey("IdDireccionFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CargoEmpleado");

                    b.Navigation("Direccion");
                });

            modelBuilder.Entity("Domain.Entities.FacturaBase", b =>
                {
                    b.HasOne("Domain.Entities.MetodoCompra", "MetodoCompra")
                        .WithMany()
                        .HasForeignKey("MetodoCompraId");

                    b.Navigation("MetodoCompra");
                });

            modelBuilder.Entity("Domain.Entities.FacturaCompra", b =>
                {
                    b.HasOne("Domain.Entities.FacturaBase", "FacturaBase")
                        .WithMany("FacturaCompras")
                        .HasForeignKey("IdFacturaBaseFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Proveedor", "Proveedor")
                        .WithMany("FacturaCompras")
                        .HasForeignKey("IdProveedorFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FacturaBase");

                    b.Navigation("Proveedor");
                });

            modelBuilder.Entity("Domain.Entities.FacturaVenta", b =>
                {
                    b.HasOne("Domain.Entities.Cliente", "Cliente")
                        .WithMany("FacturaVentas")
                        .HasForeignKey("IdClienteFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Empleado", "Empleado")
                        .WithMany("FacturaVentas")
                        .HasForeignKey("IdEmpleadoFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.FacturaBase", "FacturaBase")
                        .WithMany("FacturaVentas")
                        .HasForeignKey("IdFacturaBaseFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.MetodoCompra", null)
                        .WithMany("Facturas")
                        .HasForeignKey("MetodoCompraId");

                    b.Navigation("Cliente");

                    b.Navigation("Empleado");

                    b.Navigation("FacturaBase");
                });

            modelBuilder.Entity("Domain.Entities.Medicamento", b =>
                {
                    b.HasOne("Domain.Entities.Marca", "Marca")
                        .WithMany("Medicamentos")
                        .HasForeignKey("IdMarcaFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Proveedor", "Proveedor")
                        .WithMany("Medicamentos")
                        .HasForeignKey("IdProveedorFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Marca");

                    b.Navigation("Proveedor");
                });

            modelBuilder.Entity("Domain.Entities.MedicamentoCompra", b =>
                {
                    b.HasOne("Domain.Entities.FacturaCompra", "Compra")
                        .WithMany("MedicamentoCompras")
                        .HasForeignKey("IdCompraFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Medicamento", "Medicamento")
                        .WithMany("MedicamentosCompras")
                        .HasForeignKey("IdMedicamentoFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Compra");

                    b.Navigation("Medicamento");
                });

            modelBuilder.Entity("Domain.Entities.MedicamentoVenta", b =>
                {
                    b.HasOne("Domain.Entities.FacturaVenta", "FacturaVenta")
                        .WithMany("MedicamentoVentas")
                        .HasForeignKey("IdFacturaVentaFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Medicamento", "Medicamento")
                        .WithMany("MedicamentoVentas")
                        .HasForeignKey("IdMedicamentoFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FacturaVenta");

                    b.Navigation("Medicamento");
                });

            modelBuilder.Entity("Domain.Entities.Proveedor", b =>
                {
                    b.HasOne("Domain.Entities.Direccion", "Direccion")
                        .WithMany("Proveedores")
                        .HasForeignKey("IdDireccionFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Direccion");
                });

            modelBuilder.Entity("Domain.Entities.CargoEmpleado", b =>
                {
                    b.Navigation("Empleados");
                });

            modelBuilder.Entity("Domain.Entities.Ciudad", b =>
                {
                    b.Navigation("Direcciones");
                });

            modelBuilder.Entity("Domain.Entities.Cliente", b =>
                {
                    b.Navigation("FacturaVentas");
                });

            modelBuilder.Entity("Domain.Entities.Departamento", b =>
                {
                    b.Navigation("Ciudades");
                });

            modelBuilder.Entity("Domain.Entities.Direccion", b =>
                {
                    b.Navigation("Clientes");

                    b.Navigation("Empleados");

                    b.Navigation("Proveedores");
                });

            modelBuilder.Entity("Domain.Entities.Empleado", b =>
                {
                    b.Navigation("FacturaVentas");
                });

            modelBuilder.Entity("Domain.Entities.FacturaBase", b =>
                {
                    b.Navigation("FacturaCompras");

                    b.Navigation("FacturaVentas");
                });

            modelBuilder.Entity("Domain.Entities.FacturaCompra", b =>
                {
                    b.Navigation("MedicamentoCompras");
                });

            modelBuilder.Entity("Domain.Entities.FacturaVenta", b =>
                {
                    b.Navigation("MedicamentoVentas");
                });

            modelBuilder.Entity("Domain.Entities.Marca", b =>
                {
                    b.Navigation("Medicamentos");
                });

            modelBuilder.Entity("Domain.Entities.Medicamento", b =>
                {
                    b.Navigation("MedicamentoVentas");

                    b.Navigation("MedicamentosCompras");
                });

            modelBuilder.Entity("Domain.Entities.MetodoCompra", b =>
                {
                    b.Navigation("Facturas");
                });

            modelBuilder.Entity("Domain.Entities.Pais", b =>
                {
                    b.Navigation("Departamentos");
                });

            modelBuilder.Entity("Domain.Entities.Proveedor", b =>
                {
                    b.Navigation("FacturaCompras");

                    b.Navigation("Medicamentos");
                });
#pragma warning restore 612, 618
        }
    }
}
