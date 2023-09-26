using API.Dtos;
using AutoMapper;
using Domain.Entities;

namespace API.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles(){
            CreateMap<Empleado, EmpleadoMedicamentosDistintosDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.Nombre))
            .ForMember(dest => dest.Apellido, opt => opt.MapFrom(src => src.Apellido))
            .ForMember(dest => dest.Cedula, opt => opt.MapFrom(src => src.Cedula))
            .ForMember(dest => dest.CantidadMedicamentosDistintosVendidos, opt => opt.Ignore());

            CreateMap<Cliente,ClienteDto>().ReverseMap();
            CreateMap<Medicamento,MedicamentoDto>().ReverseMap();
            // CreateMap<FacturaVenta,FacturaVentaDto>().ReverseMap();
            CreateMap<FacturaVenta, FacturaVentaDto>()
           .ForMember(dest => dest.Recetas, opt => opt.Ignore());
            CreateMap<MedicamentoVenta, MedicamentoVentaDto>().ReverseMap();
            CreateMap<Empleado, EmpleadoDto>().ReverseMap();
            CreateMap<Receta, RecetaDto>().ReverseMap();

            CreateMap<Empleado, EmpleadoVentaDto>()
           .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
           .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.Nombre))
           .ForMember(dest => dest.Apellido, opt => opt.MapFrom(src => src.Apellido))
           .ForMember(dest => dest.CantidadVentas, opt => opt.Ignore());
            CreateMap<Direccion, DireccionDto>().ReverseMap();

            // Lista de Proveedores

            CreateMap<Proveedor, AllProveedorDto>()
            .ForMember(dest => dest.NombreProveedor, opt => opt.MapFrom(src => src.NombreProveedor))
            .ForMember(dest => dest.ContactoProveedor, opt => opt.MapFrom(src => src.ContactoProveedor))
            .ForMember(dest => dest.Direccion, opt => opt.MapFrom(src => src.Direccion))
            .ForPath(dest => dest.Direccion.Numero, opt => opt.MapFrom(e => e.Direccion.Numero))
            .ForPath(dest => dest.Direccion.Carrera, opt => opt.MapFrom(e => e.Direccion.Carrera))
            .ForPath(dest => dest.Direccion.Calle, opt => opt.MapFrom(e => e.Direccion.Calle))
            .ReverseMap();

            // Medicamentos Vendidos por proveedor

            CreateMap<Proveedor, ProveedorListVendidosDto>()
            .ForMember(dest => dest.NombreProveedor, opt => opt.MapFrom(e => e.NombreProveedor))
            .ForPath(dest => dest.listaProds, opt => opt.MapFrom(e => e.Medicamentos.Select(e => new ListaProd
                {
                    NombreMedicamento = e.NombreMedicamento,
                    Cantidad = e.MedicamentosCompras.Count
                }
            )));

            // Medicamentos buscados por nombre del proveedor

            CreateMap<Proveedor, ProveedorMedicamentoWithName>()
            .ForMember(dest => dest.NombreProveedor, opt => opt.MapFrom(e => e.NombreProveedor))
            .ForMember(dest => dest.Vendidos, opt => opt.MapFrom(e => e.Medicamentos
            .Select(e  => new VendidosDto { 
                NombreProducto = e.NombreMedicamento 
                })))
            .ReverseMap();

            // Proveedores con medicamentos con menos de 50 elementos en stock
            CreateMap<Proveedor, ProveedorMedWithLess50Dto>()
            .ForMember(dest => dest.Medicamento, opt => opt.MapFrom(e => e.Medicamentos.Select(e => new MedicamentoDto{
                Id = e.Id,
                NombreMedicamento = e.NombreMedicamento,
                PrecioMedicamento = e.PrecioMedicamento,
                RequiereReceta = e.RequiereReceta,
                Stock = e.Stock,
                FechaExpiracion = e.FechaExpiracion,
                IdProveedorFK = e.IdProveedorFK,
                IdMarcaFK = e.IdMarcaFK
            })))
            .ReverseMap();
            CreateMap<Cliente, ClienteGastoDto>()
         .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
         .ForMember(dest => dest.Cedula, opt => opt.MapFrom(src => src.Cedula))
         .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.Nombre))
         .ForMember(dest => dest.Apellido, opt => opt.MapFrom(src => src.Apellido))
         .ForMember(dest => dest.CantidadGastada, opt => opt.Ignore());
        }
           
        

        

    }
    }
