using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            CreateMap<FacturaVenta,FacturaVentaDto>().ReverseMap();
            CreateMap<MedicamentoVenta, MedicamentoVentaDto>().ReverseMap();
            CreateMap<Empleado, EmpleadoDto>().ReverseMap();

            CreateMap<Empleado, EmpleadoVentaDto>()
           .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
           .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.Nombre))
           .ForMember(dest => dest.Apellido, opt => opt.MapFrom(src => src.Apellido))
           .ForMember(dest => dest.CantidadVentas, opt => opt.Ignore());
           
            CreateMap<Cliente, ClienteGastoDto>()
          .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
          .ForMember(dest => dest.Cedula, opt => opt.MapFrom(src => src.Cedula))
          .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.Nombre))
          .ForMember(dest => dest.Apellido, opt => opt.MapFrom(src => src.Apellido))
          .ForMember(dest => dest.CantidadGastada, opt => opt.Ignore()); 

        

    }
    }
}