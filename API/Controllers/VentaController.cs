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

        public async Task<ActionResult<IEnumerable<MedicamentoVentaDto>>> Get()
        {
            var medicamentoVenta = await _unitOfWork.MedicamentoVentas.GetAllAsync();
            return mapper.Map<List<MedicamentoVentaDto>>(medicamentoVenta);

        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<MedicamentoVenta>> Post(MedicamentoVentaDto MedicamentoVentaDto)
        {
            var MedicamentoVenta = this.mapper.Map<MedicamentoVenta>(MedicamentoVentaDto);
            _unitOfWork.MedicamentoVentas.Add(MedicamentoVenta);
            await _unitOfWork.SaveAsync();

            if (MedicamentoVenta == null)
            {
                return BadRequest();
            }
            MedicamentoVentaDto.Id = MedicamentoVenta.Id;
            return CreatedAtAction(nameof(Post), new { id = MedicamentoVentaDto.Id }, MedicamentoVenta);
        }



        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<MedicamentoVentaDto>> Put(int id, [FromBody] MedicamentoVentaDto MedicamentoVentaDto)
        {
            if (MedicamentoVentaDto == null)
                return NotFound();

            var MedicamentoVenta = this.mapper.Map<MedicamentoVenta>(MedicamentoVentaDto);
            _unitOfWork.MedicamentoVentas.Update(MedicamentoVenta);
            await _unitOfWork.SaveAsync();
            return MedicamentoVentaDto;
        }



        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> Delete(int id)
        {
            var MedicamentoVenta = await _unitOfWork.MedicamentoVentas.GetById(id);
            if (MedicamentoVenta == null)
                return NotFound();

            _unitOfWork.MedicamentoVentas.Remove(MedicamentoVenta);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }

    }
}
