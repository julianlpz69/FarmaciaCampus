using API.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Linq;

namespace API.Controllers
{
    public class DireccionController : BaseApiController
    {
        private IUnitOfWork _unitOfWork;
        private readonly IMapper mapper;


        public DireccionController(IUnitOfWork UnitOfWork, IMapper Mapper)
        {
            _unitOfWork = UnitOfWork;
            mapper = Mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<IEnumerable<DireccionDto>>> Get()
        {
            var FacturaVenta = await _unitOfWork.FacturaVentas.GetAllAsync();
            return mapper.Map<List<DireccionDto>>(FacturaVenta);

        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Direccion>> Post(DireccionDto DireccionDto)
        {
            var Direccion = this.mapper.Map<Direccion>(DireccionDto);
            _unitOfWork.Direcciones.Add(Direccion);
            await _unitOfWork.SaveAsync();

            if (Direccion == null)
            {
                return BadRequest();
            }
            DireccionDto.Id = Direccion.Id;
            return CreatedAtAction(nameof(Post), new { id = DireccionDto.Id }, Direccion);
        }


        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<DireccionDto>> Get(int id)
        {
            var FacturaVenta = await _unitOfWork.FacturaVentas.GetById(id);
            return mapper.Map<DireccionDto>(FacturaVenta);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<DireccionDto>> Put(int id, [FromBody] DireccionDto DireccionDto)
        {
            if (DireccionDto == null)
                return NotFound();

            var FacturaVenta = this.mapper.Map<FacturaVenta>(DireccionDto);
            _unitOfWork.FacturaVentas.Update(FacturaVenta);
            await _unitOfWork.SaveAsync();
            return DireccionDto;
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
    }
}