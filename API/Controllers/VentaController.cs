using API.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interface;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class VentaController : BaseApiController
    {
        private IUnitOfWork _unitOfWork;
        private readonly IMapper mapper;


        public VentaController(IUnitOfWork UnitOfWork, IMapper Mapper)
        {
            _unitOfWork = UnitOfWork;
            mapper = Mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<IEnumerable<FacturaVentaDto>>> Get()
        {
            var FacturaVenta = await _unitOfWork.FacturaVentas.GetAllAsync();
            return mapper.Map<List<FacturaVentaDto>>(FacturaVenta);

        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<FacturaVenta>> Post(FacturaVentaDto FacturaVentaDto)
        {
            var FacturaVenta = this.mapper.Map<FacturaVenta>(FacturaVentaDto);
            _unitOfWork.FacturaVentas.Add(FacturaVenta);
            await _unitOfWork.SaveAsync();

            if (FacturaVenta == null)
            {
                return BadRequest();
            }
            FacturaVentaDto.Id = FacturaVenta.Id;
            return CreatedAtAction(nameof(Post), new { id = FacturaVentaDto.Id }, FacturaVenta);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<FacturaVentaDto>> Get(int id)
        {
            var FacturaVenta = await _unitOfWork.FacturaVentas.GetById(id);
            return mapper.Map<FacturaVentaDto>(FacturaVenta);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<FacturaVentaDto>> Put(int id, [FromBody] FacturaVentaDto FacturaVentaDto)
        {
            if (FacturaVentaDto == null)
                return NotFound();

            var FacturaVenta = this.mapper.Map<FacturaVenta>(FacturaVentaDto);
            _unitOfWork.FacturaVentas.Update(FacturaVenta);
            await _unitOfWork.SaveAsync();
            return FacturaVentaDto;
        }



        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> Delete(int id)
        {
            var FacturaVenta = await _unitOfWork.FacturaVentas.GetById(id);
            if (FacturaVenta == null)
                return NotFound();

            _unitOfWork.FacturaVentas.Remove(FacturaVenta);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }

        [HttpGet("paracetamol")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<string> CantidadParacetamol()
        {
            var cantidadMedicamentos = await _unitOfWork.MedicamentoVentas.CantidadVentasParacetamol();
            return cantidadMedicamentos;
        }

        [HttpGet("Total")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<string> TotalVentas()
        {
            var TotalVentas = await _unitOfWork.FacturaVentas.TotalVentas();
            return TotalVentas;
        }

        [HttpGet("Clientes/Paracetamol")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IEnumerable<ClienteDto>> ClientesParacetamolAsync ()
        {
            var Clientes = await _unitOfWork.MedicamentoVentas.GetPacientesParacetamolAsync();
             return mapper.Map<List<ClienteDto>>(Clientes);
        }

        [HttpGet("Total/Marzo")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<int> VentasMarzo()
        {
            var TotalVentas = await _unitOfWork.FacturaVentas.VentasMarzoAsync();
            return TotalVentas;
        }
        [HttpGet("menos-vendido")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<MedicamentoDto> MenosVendido()
        {
            var Medicamento = await _unitOfWork.FacturaVentas.MedicamentoMenosVendidoAsync();
            return mapper.Map<MedicamentoDto>(Medicamento);
        }

        [HttpGet("ventas-por-empleado/{id}")]
        public async Task<ActionResult<EmpleadoVentaDto>> ObtenerVentasPorEmpleadoEn2023(int id)
        {
            int cantidadVentas = await _unitOfWork.FacturaVentas.VentasEmpleado2023Async(id);

            // Realiza la conversión al DTO aquí
            var empleado = await _unitOfWork.Empleados.GetById(id);
            var empleadoDto = mapper.Map<EmpleadoVentaDto>(empleado);
            empleadoDto.CantidadVentas = cantidadVentas;

            return empleadoDto;
        }
    }
}
