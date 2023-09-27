

using AutoMapper;
using Domain.Entities;
using Domain.Interface;
using Microsoft.AspNetCore.Mvc;
using API.Dtos;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<AllProveedorDto>>> GetAllProveedor(){
        var datos = await  _unitOfWork.Proveedores.GetAllAsync();
        return _mapper.Map<List<AllProveedorDto>>(datos);
    }
    [HttpGet("Nombre")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<ProveedorMedicamentoWithName>>> Get([FromQuery(Name = "m")]string name){
        var datos = await _unitOfWork.Proveedores.GetListWithName(name.ToLower());
        return _mapper.Map<List<ProveedorMedicamentoWithName>>(datos);
    }
    
    [HttpGet("TotalPerProv")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<ProveedorListVendidosDto>>> Get1(){
        var datos = await _unitOfWork.Proveedores.GetPerProvSinFactura();
        return _mapper.Map<List<ProveedorListVendidosDto>>(datos);
    }
    [HttpGet("TotalAnualPerProv")]
    [Authorize]
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
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<ProveedorMedWithLess50Dto>>> GetLess50Stock(){
        var datos = await _unitOfWork.Proveedores.GetOnlyWithMedLessThan50();
        return _mapper.Map<List<ProveedorMedWithLess50Dto>>(datos);
    }
    [HttpGet("provmorethan5")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<ProveedorWithMoreThan5med>>> GetProvMorethan5Med(){
        var datos = await _unitOfWork.Proveedores.GetProveedoresCon5MedicamentosVendidos();
        return _mapper.Map<List<ProveedorWithMoreThan5med>>(datos);
    }
    [HttpGet("ProvMasVendio")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<ProveedorMasVendioDto>>> GetMasVendido(){
        var datos = await _unitOfWork.Proveedores.GetProveedorsConMasMedicamentosVendidos();
        return _mapper.Map<List<ProveedorMasVendioDto>>(datos);
    }
    [HttpPost("GuardarProveedor")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PostProveedorDto>> PostProveedor([FromBody] Proveedor proveedor){
        _unitOfWork.Direcciones.Add(proveedor.Direccion);
        await _unitOfWork.SaveAsync();
        var entidad = _mapper.Map<PostProveedorDto>(proveedor);
        if(proveedor == null){
            return BadRequest();
        }
        _unitOfWork.Proveedores.Add(proveedor, await _unitOfWork.Direcciones.LastId());
        await _unitOfWork.SaveAsync();
        return entidad;
    }
    [HttpDelete("Eliminar/{id}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Proveedor>> EliminarProveedor(int id){
        var data = await _unitOfWork.Proveedores.GetById(id);
        if(data == null){
            return BadRequest();
        }
        _unitOfWork.Proveedores.Remove(data);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
    [HttpGet("Find/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<AllProveedorDto>> FindProvedor(int id){
        if(id < 1){
            return BadRequest();
        }
        var datos = await _unitOfWork.Proveedores.GetById(id);
        return _mapper.Map<AllProveedorDto>(datos);
    }
    [HttpPut("Update/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<AllProveedorDto>> UpdateProveedor([FromBody] Proveedor proveedor, int Id){
        var dato = await _unitOfWork.Proveedores.GetById(Id);
        if(dato == null){
            return BadRequest();
        }
        _unitOfWork.Proveedores.Update(dato, proveedor);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}
