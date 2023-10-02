using API.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Linq;

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
            var addFactura = await _unitOfWork.FacturaVentas.CrearFacturaVentaAsync(FacturaVenta);

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
        public async Task<object> TotalVentas()
        {
            var TotalVentas = await _unitOfWork.FacturaVentas.TotalVentas();
            return new{mensaje = TotalVentas};
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

        [HttpGet("TotalVentasPorMes/{numeroMes}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<MesVentaDto>> TotalVentasPorMesEn2023(int numeroMes)
        {
            var totalVentas = await _unitOfWork.FacturaVentas.TotalVentasPorMesEn2023Async(numeroMes);

            var mesVentaDto = new MesVentaDto
            {
                Mes = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(numeroMes),
                TotalMedicamentosVendidos = totalVentas
            };

            return mesVentaDto;
        }
        [HttpGet("vendidos-cada-mes")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<MedicamentoDto>>> vendidosCadaMesEn2023()
        {
            var medicamentos = await _unitOfWork.FacturaVentas.MedicamentosVendidosCadaMesEn2023Async();

            return mapper.Map<List<MedicamentoDto>>(medicamentos);
            
        }

        [HttpGet("Total/primer-trimestre")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<int> VentasPrimerTrimestre()
        {
            var TotalVentas = await _unitOfWork.FacturaVentas.VentasPrimerTrimestre2023Async();
            return TotalVentas;
        }

        [HttpGet("Medicamento/no-vendidos")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<MedicamentoDto>>> medicamentosNoVendidos()
        {
            var medicamentos = await _unitOfWork.FacturaVentas.MedicamentosNoVendidosAsync();
            return mapper.Map<List<MedicamentoDto>>(medicamentos);
        }

        [HttpGet("Promedio-Ventas")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<double>> PromedioVentas()
        {
            var promedio = await _unitOfWork.FacturaVentas.PromedioMedicamentosCompradosPorVentaAsync();
            return promedio;
        }
        [HttpGet("Recetas-generadas/2023")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IEnumerable<RecetaDto>> recetasGeneradas2023()
        {
            var recetas = await _unitOfWork.FacturaVentas.RecetasEmitidas2023Async();
            return mapper.Map<IEnumerable<RecetaDto>>(recetas);   
        }
    }
}
