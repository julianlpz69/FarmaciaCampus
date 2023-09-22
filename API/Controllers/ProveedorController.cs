

using AutoMapper;
using Domain.Entities;
using Domain.Interface;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using API.Dtos;
using Microsoft.EntityFrameworkCore;
namespace API.Controllers;

public class ProveedorController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private IMapper _mapper;
    public ProveedorController(IUnitOfWork unitOfWork){
        _unitOfWork = unitOfWork;
    }

    [HttpGet("{name}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Proveedor>>> Get(string name){
        var datos = await _unitOfWork.Proveedores.GetListWithName(name);
        var dtos = datos.Select(e => {
            return new MedicamentoWithName{
                NombreProveedor = e.NombreProveedor,
                Vendidos = e.Medicamentos.Select(e => {
                    return new Vendidos {
                        NombreProducto = e.NombreMedicamento
                    };
                })
            };
        });
        return Ok(dtos);
    }
    
    [HttpGet("TotalPerProv")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<ProveedorListVendidosDto>>> Get1(){
        var datos = await _unitOfWork.Proveedores.GetPerProvSinFactura();
        var dto = datos.ToList().Select( e => {
            ProveedorListVendidosDto vendidos = new ProveedorListVendidosDto{
                NombreProveedor = e.NombreProveedor,
                listaProds = e.Medicamentos.Select(d => {
                    int cant = e.Medicamentos.Count;
                    return new ListaProd {
                        NombreMedicamento = d.NombreMedicamento,
                        Cantidad = cant
                    };
                })
            };
            return vendidos;
        }).ToList();
        return Ok(dto);
    }
    [HttpGet("TotalAnualPerProv")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<ProveedorVentasAnualesDto>>> Get(){
        var datos = await _unitOfWork.Proveedores.GetPerProvConFactura();
        var dto = datos.Select( e => {
            double suma = e.FacturaCompras.Sum(e => e.ValorTotal);
            ProveedorVentasAnualesDto vendidos = new (){
                NombreProveedor = e.NombreProveedor,
                totalAnual = suma
            };
            return vendidos;
        }).ToList();
        return Ok(dto);
    }
}
