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
            CreateMap<FacturaVenta,FacturaVentaDto>().ReverseMap();
            CreateMap<MedicamentoVenta, MedicamentoVentaDto>().ReverseMap();
            CreateMap<Empleado, EmpleadoDto>().ReverseMap();

            CreateMap<Empleado, EmpleadoVentaDto>()
           .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
           .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.Nombre))
           .ForMember(dest => dest.Apellido, opt => opt.MapFrom(src => src.Apellido))
           .ForMember(dest => dest.CantidadVentas, opt => opt.Ignore());
            CreateMap<Direccion, DireccionDto>().ReverseMap();
            // Guardar Proveedor 
            CreateMap<Proveedor, PostProveedorDto>().ReverseMap();
            // Lista de Proveedores

            CreateMap<Proveedor, AllProveedorDto>()
            
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
            // proveedore que han vendido almenos 5 medicamentos diferentes el año 2023 
            CreateMap<Proveedor, ProveedorWithMoreThan5med>()
            .ForMember(dest => dest.MedicamentoDtos, opt => opt.MapFrom(e =>e.Medicamentos.Where(e => e.MedicamentosCompras.Count > 0)));
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

         CreateMap<Proveedor, ProveedorMasVendioDto>()
         .ForMember(e => e.CantidadVendida, opt => opt.MapFrom(e => e.Medicamentos.Select(x => x.MedicamentosCompras.Select(y => y.CantidadComprada).Sum()).Sum()))
         .ReverseMap();
        }
           
        

        

    }
    }
