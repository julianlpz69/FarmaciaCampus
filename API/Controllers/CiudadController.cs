using API.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Linq;

namespace API.Controllers;

public class CiudadController : BaseApiController
{
    private IUnitOfWork _unitOfWork;
    private readonly IMapper mapper;


    public CiudadController(IUnitOfWork UnitOfWork, IMapper Mapper)
    {
        _unitOfWork = UnitOfWork;
        mapper = Mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<CiudadDto>>> Get()
    {
        var Ciudad = await _unitOfWork.Ciudades.GetAllAsync();
        return mapper.Map<List<CiudadDto>>(Ciudad);

    }


    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Ciudad>> Post(CiudadDto CiudadDto)
    {
        var Ciudad = this.mapper.Map<Ciudad>(CiudadDto);
        _unitOfWork.Ciudades.Add(Ciudad);
        await _unitOfWork.SaveAsync();

        if (Ciudad == null)
        {
            return BadRequest();
        }
        CiudadDto.Id = Ciudad.Id;
        return CreatedAtAction(nameof(Post), new { id = CiudadDto.Id }, Ciudad);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CiudadDto>> Get(int id)
    {
        var Ciudad = await _unitOfWork.Ciudades.GetById(id);
        return mapper.Map<CiudadDto>(Ciudad);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<CiudadDto>> Put(int id, [FromBody] CiudadDto CiudadDto)
    {
        if (CiudadDto == null)
            return NotFound();

        var Ciudad = this.mapper.Map<Ciudad>(CiudadDto);
        _unitOfWork.Ciudades.Update(Ciudad);
        await _unitOfWork.SaveAsync();
        return CiudadDto;
    }



    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<IActionResult> Delete(int id)
    {
        var Ciudad = await _unitOfWork.Ciudades.GetById(id);
        if (Ciudad == null)
            return NotFound();

        _unitOfWork.Ciudades.Remove(Ciudad);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}