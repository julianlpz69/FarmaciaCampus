using API.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Linq;

namespace API.Controllers;

public class DepartamentoController : BaseApiController
{
    private IUnitOfWork _unitOfWork;
    private readonly IMapper mapper;


    public DepartamentoController(IUnitOfWork UnitOfWork, IMapper Mapper)
    {
        _unitOfWork = UnitOfWork;
        mapper = Mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<DepartamentoXIdDto>>> Get()
    {
        var Departamento = await _unitOfWork.Departamentos.GetAllAsync();
        return mapper.Map<List<DepartamentoXIdDto>>(Departamento);

    }


    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Departamento>> Post(DepartamentoDto DepartamentoDto)
    {
        var Departamento = this.mapper.Map<Departamento>(DepartamentoDto);
        _unitOfWork.Departamentos.Add(Departamento);
        await _unitOfWork.SaveAsync();

        if (Departamento == null)
        {
            return BadRequest();
        }
        DepartamentoDto.Id = Departamento.Id;
        return CreatedAtAction(nameof(Post), new { id = DepartamentoDto.Id }, Departamento);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<DepartamentoXIdDto>> Get(int id)
    {
        var Departamento = await _unitOfWork.Departamentos.GetById(id);
        return mapper.Map<DepartamentoXIdDto>(Departamento);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<DepartamentoDto>> Put(int id, [FromBody] DepartamentoDto DepartamentoDto)
    {
        if (DepartamentoDto == null)
            return NotFound();

        var Departamento = this.mapper.Map<Departamento>(DepartamentoDto);
        _unitOfWork.Departamentos.Update(Departamento);
        await _unitOfWork.SaveAsync();
        return DepartamentoDto;
    }



    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<IActionResult> Delete(int id)
    {
        var Departamento = await _unitOfWork.Departamentos.GetById(id);
        if (Departamento == null)
            return NotFound();

        _unitOfWork.Departamentos.Remove(Departamento);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}