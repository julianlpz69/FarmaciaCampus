using API.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Linq;

namespace API.Controllers;

public class PaisController : BaseApiController
{
    private IUnitOfWork _unitOfWork;
    private readonly IMapper mapper;


    public PaisController(IUnitOfWork UnitOfWork, IMapper Mapper)
    {
        _unitOfWork = UnitOfWork;
        mapper = Mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<PaisXIdDto>>> Get()
    {
        var Pais = await _unitOfWork.Paises.GetAllAsync();
        return mapper.Map<List<PaisXIdDto>>(Pais);

    }


    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pais>> Post(PaisDto PaisDto)
    {
        var Pais = this.mapper.Map<Pais>(PaisDto);
        _unitOfWork.Paises.Add(Pais);
        await _unitOfWork.SaveAsync();

        if (Pais == null)
        {
            return BadRequest();
        }
        PaisDto.Id = Pais.Id;
        return CreatedAtAction(nameof(Post), new { id = PaisDto.Id }, Pais);
    }
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PaisXIdDto>> Get(int id)
    {
        var Pais = await _unitOfWork.Paises.GetById(id);
        return mapper.Map<PaisXIdDto>(Pais);
    }



    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<PaisDto>> Put(int id, [FromBody] PaisDto PaisDto)
    {
        if (PaisDto == null)
            return NotFound();

        var Pais = this.mapper.Map<Pais>(PaisDto);
        _unitOfWork.Paises.Update(Pais);
        await _unitOfWork.SaveAsync();
        return PaisDto;
    }



    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<IActionResult> Delete(int id)
    {
        var Pais = await _unitOfWork.Paises.GetById(id);
        if (Pais == null)
            return NotFound();

        _unitOfWork.Paises.Remove(Pais);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}