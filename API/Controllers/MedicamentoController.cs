using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class MedicamentoController : BaseApiController
    {
    private IUnitOfWork _unitOfWork;
        private readonly IMapper mapper;


        public MedicamentoController(IUnitOfWork UnitOfWork, IMapper Mapper)
        {
            _unitOfWork = UnitOfWork;
            mapper = Mapper;
        }
        
     
         [HttpGet]
         [ProducesResponseType(StatusCodes.Status200OK)]
         [ProducesResponseType(StatusCodes.Status400BadRequest)]
         public async Task<ActionResult<IEnumerable<MedicamentoGetDto>>> Get()
         {
            var Medicamentos = await _unitOfWork.Medicamentos.GetAllAsync();
            return mapper.Map<List<MedicamentoGetDto>>(Medicamentos);

         }


         [HttpGet("GetStock50")]
         [ProducesResponseType(StatusCodes.Status200OK)]
         [ProducesResponseType(StatusCodes.Status400BadRequest)]
        
         public async Task<ActionResult<IEnumerable<MedicamentoGetDto>>> GetStock50()
         {
            var Medicamentos = await _unitOfWork.Medicamentos.GetStock_50();
            return mapper.Map<List<MedicamentoGetDto>>(Medicamentos);

         }



         [HttpGet("GetExpiAntes2024")]
         [ProducesResponseType(StatusCodes.Status200OK)]
         [ProducesResponseType(StatusCodes.Status400BadRequest)]
        
         public async Task<ActionResult<IEnumerable<MedicamentoGetDto>>> GetExpiAntes2024()
         {
            var Medicamentos = await _unitOfWork.Medicamentos.GetExpiracionAntes2024();
            return mapper.Map<List<MedicamentoGetDto>>(Medicamentos);

         }



         [HttpGet("GetExpi2024")]
         [ProducesResponseType(StatusCodes.Status200OK)]
         [ProducesResponseType(StatusCodes.Status400BadRequest)]
        
         public async Task<ActionResult<IEnumerable<MedicamentoGetDto>>> GetExpi2024()
         {
            var Medicamentos = await _unitOfWork.Medicamentos.GetExpiracion2024();
            return mapper.Map<List<MedicamentoGetDto>>(Medicamentos);

         }


         [HttpGet("GetMayor50Menor100")]
         [ProducesResponseType(StatusCodes.Status200OK)]
         [ProducesResponseType(StatusCodes.Status400BadRequest)]
        
         public async Task<ActionResult<IEnumerable<MedicamentoGetDto>>> GetMayor50Menor100()
         {
            var Medicamentos = await _unitOfWork.Medicamentos.ValorMas50StockMenor100();
            return mapper.Map<List<MedicamentoGetDto>>(Medicamentos);

         }


         [HttpGet("GetValorMayor")]
         [ProducesResponseType(StatusCodes.Status200OK)]
         [ProducesResponseType(StatusCodes.Status400BadRequest)]
        
         public async Task<ActionResult<IEnumerable<MedicamentoGetDto>>> GetValorMayor()
         {
            var Medicamentos = await _unitOfWork.Medicamentos.MasCaro();
            return mapper.Map<List<MedicamentoGetDto>>(Medicamentos);

         }


        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<MedicamentoDto>> Get(int id)
        {
            var medicamento = await _unitOfWork.Medicamentos.GetById(id);
            return mapper.Map<MedicamentoDto>(medicamento);
        }


          [HttpPost]
          [ProducesResponseType(StatusCodes.Status201Created)]
          [ProducesResponseType(StatusCodes.Status400BadRequest)]
          public async Task<ActionResult<Medicamento>> Post(MedicamentoDto MedicamentoDto)
          {
            var medicamento = this.mapper.Map<Medicamento>(MedicamentoDto);
             _unitOfWork.Medicamentos.Add(medicamento);
            await _unitOfWork.SaveAsync();
         
            if (medicamento == null){
                return BadRequest();
            }
            MedicamentoDto.Id = medicamento.Id;
            return CreatedAtAction(nameof(Post), new {id = MedicamentoDto.Id}, medicamento); 
          }



            [HttpPut("{id}")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status404NotFound)]
            [ProducesResponseType(StatusCodes.Status400BadRequest)]
            
            public async Task<ActionResult<MedicamentoDto>> Put(int id, [FromBody]MedicamentoDto MedicamentoDto){
                if(MedicamentoDto == null)
                    return NotFound();
            
                var medicamento = this.mapper.Map<Medicamento>(MedicamentoDto);
                _unitOfWork.Medicamentos.Update(medicamento);
                await _unitOfWork.SaveAsync();
                return MedicamentoDto;
            }



            [HttpDelete("{id}")]
            [ProducesResponseType(StatusCodes.Status204NoContent)]
            [ProducesResponseType(StatusCodes.Status404NotFound)]
            
            public async Task<IActionResult> Delete (int id){
            var medicamento = await _unitOfWork.Medicamentos.GetById(id);
            if(medicamento == null)
            return NotFound();
            
            _unitOfWork.Medicamentos.Remove(medicamento);
            await _unitOfWork.SaveAsync();
            return NoContent();    }

    }
}