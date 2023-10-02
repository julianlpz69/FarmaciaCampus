using API.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Linq;

namespace API.Controllers
{
    public class CompraController : BaseApiController
    {
        private IUnitOfWork _unitOfWork;
        private readonly IMapper mapper;


        public CompraController(IUnitOfWork UnitOfWork, IMapper Mapper)
        {
            _unitOfWork = UnitOfWork;
            mapper = Mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<IEnumerable<FacturaCompraDto>>> Get()
        {
            var FacturaCompra = await _unitOfWork.FacturaCompras.GetAllAsync();
            return mapper.Map<List<FacturaCompraDto>>(FacturaCompra);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<FacturaCompraDto>> Get(int id)
        {
            var FacturaCompra = await _unitOfWork.FacturaCompras.GetById(id);
            return mapper.Map<FacturaCompraDto>(FacturaCompra);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<FacturaCompraDto>> Post(PostCompraDto facturaCompraDto)
        {
            var facturaCompra = this.mapper.Map<FacturaCompra>(facturaCompraDto);
            _unitOfWork.FacturaCompras.Add(facturaCompra);

            foreach (var medicamentoCompraDto in facturaCompra.MedicamentosComprados)
            {
                var medicamentoId = medicamentoCompraDto.IdMedicamentoFK;
                var medicamento = await _unitOfWork.Medicamentos.GetById(medicamentoId) ?? throw new Exception($"El medicamento con ID {medicamentoId} no existe.");

                medicamento.Stock += medicamentoCompraDto.CantidadComprada;

                medicamentoCompraDto.Medicamento = medicamento;
            }

            await _unitOfWork.SaveAsync();

            var factura = mapper.Map<FacturaCompraDto>(facturaCompra);
            facturaCompraDto.Id = facturaCompra.Id;
            return CreatedAtAction(nameof(Post), new { id = facturaCompraDto.Id }, facturaCompra);
        }

        [HttpPost("con-medicamentos-nuevos")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<FacturaCompraDto>> PostConMedicamentosNuevos(PostCompraNuevoDto facturaCompraDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var facturaCompra = mapper.Map<FacturaCompra>(facturaCompraDto);

            _unitOfWork.FacturaCompras.Add(facturaCompra);
            await _unitOfWork.SaveAsync();

            foreach (var medicamentoDto in facturaCompraDto.MedicamentosComprados)
            {
                var medicamentoExistente = await _unitOfWork.Medicamentos.GetByNombreAsync(medicamentoDto.Medicamento.NombreMedicamento);

                if (medicamentoExistente != null)
                {
                    medicamentoExistente.Stock += medicamentoDto.CantidadComprada;
                }
                else
                {
                    var nuevoMedicamento = mapper.Map<Medicamento>(medicamentoDto.Medicamento);
                    nuevoMedicamento.Stock = medicamentoDto.CantidadComprada;
                    _unitOfWork.Medicamentos.Add(nuevoMedicamento);
                    await _unitOfWork.SaveAsync();

                    medicamentoExistente = nuevoMedicamento;
                }

                var medicamentoCompraExistente = facturaCompra.MedicamentosComprados.FirstOrDefault(mc => mc.IdMedicamentoFK == medicamentoExistente.Id);

                if (medicamentoCompraExistente != null)
                {
                    medicamentoCompraExistente.CantidadComprada += medicamentoDto.CantidadComprada;
                    medicamentoCompraExistente.PrecioCompra = medicamentoDto.PrecioCompra;
                }
                else
                {
                    var medicamentoCompra = new MedicamentoCompra
                    {
                        IdFacturaCompraFK = facturaCompra.Id,
                        IdMedicamentoFK = medicamentoExistente.Id,
                        CantidadComprada = medicamentoDto.CantidadComprada,
                        PrecioCompra = medicamentoDto.PrecioCompra
                    };

                    facturaCompra.MedicamentosComprados.Add(medicamentoCompra);
                }
            }

            await _unitOfWork.SaveAsync();

            var facturaCompraDtoResult = mapper.Map<FacturaCompraDto>(facturaCompra);

            return CreatedAtAction(nameof(PostConMedicamentosNuevos), new { id = facturaCompraDtoResult.Id }, facturaCompraDto);
            }



        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<FacturaCompraDto>> Put(int id, [FromBody] PostCompraDto facturaCompraDto)
        {
            if (facturaCompraDto == null)
            {
                return BadRequest();
            }

            var facturaCompra = await _unitOfWork.FacturaCompras.GetById(id);

            if (facturaCompra == null)
            {
                return NotFound();
            }

            facturaCompra.ValorTotal = facturaCompraDto.ValorTotal;
            facturaCompra.FechaCompra = facturaCompraDto.FechaCompra;
            facturaCompra.IdMetodoPagoFK = facturaCompraDto.IdMetodoPagoFk;
            facturaCompra.IdProveedorFk = facturaCompraDto.IdProveedorFK;

            foreach (var medicamentoCompraDto in facturaCompraDto.MedicamentosComprados)
            {
                var medicamentoCompra = facturaCompra.MedicamentosComprados.FirstOrDefault(mc => mc.Id == medicamentoCompraDto.Id);
                var medicamento = await _unitOfWork.Medicamentos.GetById(medicamentoCompra.IdMedicamentoFK);

                if (medicamentoCompra != null && medicamento != null)
                {
                    // Obtén la diferencia en la cantidad comprada antes de la actualización
                    var diferenciaCantidad = medicamentoCompraDto.CantidadComprada - medicamentoCompra.CantidadComprada;

                    medicamentoCompra.CantidadComprada = medicamentoCompraDto.CantidadComprada;
                    medicamentoCompra.PrecioCompra = medicamentoCompraDto.PrecioCompra;

                    // Actualiza el stock del medicamento
                    medicamento.Stock += diferenciaCantidad;
                }
                else
                {
                    var nuevoMedicamentoCompra = new MedicamentoCompra
                    {
                        IdFacturaCompraFK = facturaCompra.Id,
                        IdMedicamentoFK = medicamentoCompraDto.IdMedicamentoFk,
                        CantidadComprada = medicamentoCompraDto.CantidadComprada,
                        PrecioCompra = medicamentoCompraDto.PrecioCompra
                    };

                    var medicamentoCompraExistente = await _unitOfWork.MedicamentoCompras.GetById(nuevoMedicamentoCompra.Id);

                    if (medicamentoCompraExistente == null)
                    {
                        facturaCompra.MedicamentosComprados.Add(nuevoMedicamentoCompra);
                    }
                    else
                    {
                        medicamentoCompraExistente.CantidadComprada = nuevoMedicamentoCompra.CantidadComprada;
                        medicamentoCompraExistente.PrecioCompra = nuevoMedicamentoCompra.PrecioCompra;
                    }

                    // Actualiza el stock del medicamento
                    medicamento.Stock += nuevoMedicamentoCompra.CantidadComprada;
                }
            }

            await _unitOfWork.SaveAsync();

            var facturaCompraDtoResult = mapper.Map<FacturaCompraDto>(facturaCompra);

            return Ok(facturaCompraDtoResult);
        }





        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> Delete(int id)
        {
            var Pais = await _unitOfWork.FacturaCompras.GetById(id);
            if (Pais == null)
                return NotFound();

            _unitOfWork.FacturaCompras.Remove(Pais);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}