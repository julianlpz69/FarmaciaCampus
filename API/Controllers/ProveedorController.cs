

using AutoMapper;
using Domain.Entities;
using Domain.Interface;
using Microsoft.AspNetCore.Mvc;
using API.Dtos;
namespace API.Controllers;

public class ProveedorController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private IMapper _mapper;
    public ProveedorController(IUnitOfWork unitOfWork, IMapper mapper){
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<AllProveedorDto>>> GetAllProveedor(){
        var datos = await  _unitOfWork.Proveedores.GetAllAsync();
        return _mapper.Map<List<AllProveedorDto>>(datos);
    }
    [HttpGet("Nombre")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<ProveedorMedicamentoWithName>>> Get([FromQuery(Name = "m")]string name){
        var datos = await _unitOfWork.Proveedores.GetListWithName(name.ToLower());
        return _mapper.Map<List<ProveedorMedicamentoWithName>>(datos);
    }
    
    [HttpGet("TotalPerProv")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<ProveedorListVendidosDto>>> Get1(){
        var datos = await _unitOfWork.Proveedores.GetPerProvSinFactura();
        return _mapper.Map<List<ProveedorListVendidosDto>>(datos);
    }
    [HttpGet("TotalAnualPerProv")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<ProveedorVentasAnualesDto>>> Get(){
        var datos = await _unitOfWork.Proveedores.GetMedFrom2023();
        var dto = datos.Select( e => {
            DateTime fechaInicio = new DateTime(2023, 1, 1);
            DateTime fechaFin = new DateTime(2023, 12, 31);
             double suma = e.FacturaCompras
             .Where(registro => registro.FechaCompra >= fechaInicio && registro.FechaCompra <= fechaFin)
             .Sum(e => e.ValorTotal);
            ProveedorVentasAnualesDto vendidos = new (){
                NombreProveedor = e.NombreProveedor,
                totalAnual = suma
            };
            return vendidos;
        }).ToList();
        return Ok(dto);
    }
    [HttpGet("provlessthan50med")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<ProveedorMedWithLess50Dto>>> GetLess50Stock(){
        var datos = await _unitOfWork.Proveedores.GetOnlyWithMedLessThan50();
        return _mapper.Map<List<ProveedorMedWithLess50Dto>>(datos);
    }
    [HttpGet("provmorethan5")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<ProveedorWithMoreThan5med>>> GetProvMorethan5Med(){
        var datos = await _unitOfWork.Proveedores.GetProveedoresCon5MedicamentosVendidos();
        return _mapper.Map<List<ProveedorWithMoreThan5med>>(datos);
    }
    
}
