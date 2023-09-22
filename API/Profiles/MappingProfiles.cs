using API.Dtos;
using AutoMapper;
using Domain.Entities;

namespace API.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles(){
            CreateMap<Cliente,ClienteDto>().ReverseMap();

            CreateMap<Medicamento,MedicamentoDto>().ReverseMap();

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
        }
    }
}