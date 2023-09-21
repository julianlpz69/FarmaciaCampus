using API.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interface;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ClienteController : BaseApiController
    {
        private IUnitOfWork _unitOfWork;
        private readonly IMapper mapper;


        public ClienteController(IUnitOfWork UnitOfWork, IMapper Mapper)
        {
            _unitOfWork = UnitOfWork;
            mapper = Mapper;
        }

         [HttpGet]
         [ProducesResponseType(StatusCodes.Status200OK)]
         [ProducesResponseType(StatusCodes.Status400BadRequest)]
        
         public async Task<ActionResult<IEnumerable<ClienteDto>>> Get()
         {
            var clientes = await _unitOfWork.Clientes.GetAllAsync();
            return mapper.Map<List<ClienteDto>>(clientes);

         }


          [HttpPost]
          [ProducesResponseType(StatusCodes.Status201Created)]
          [ProducesResponseType(StatusCodes.Status400BadRequest)]
          public async Task<ActionResult<Cliente>> Post(ClienteDto clienteDto)
          {
            var Cliente = this.mapper.Map<Cliente>(clienteDto);
             _unitOfWork.Clientes.Add(Cliente);
            await _unitOfWork.SaveAsync();
         
            if (Cliente == null){
                return BadRequest();
            }
            clienteDto.Id = Cliente.Id;
            return CreatedAtAction(nameof(Post), new {id = clienteDto.Id}, Cliente); 
          }



            [HttpPut("{id}")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status404NotFound)]
            [ProducesResponseType(StatusCodes.Status400BadRequest)]
            
            public async Task<ActionResult<ClienteDto>> Put(int id, [FromBody]ClienteDto clienteDto){
                if(clienteDto == null)
                    return NotFound();
            
                var cliente = this.mapper.Map<Cliente>(clienteDto);
                _unitOfWork.Clientes.Update(cliente);
                await _unitOfWork.SaveAsync();
                return clienteDto;
            }



            [HttpDelete("{id}")]
            [ProducesResponseType(StatusCodes.Status204NoContent)]
            [ProducesResponseType(StatusCodes.Status404NotFound)]
            
            public async Task<IActionResult> Delete (int id){
            var cliente = await _unitOfWork.Clientes.GetById(id);
            if(cliente == null)
            return NotFound();
            
            _unitOfWork.Clientes.Remove(cliente);
            await _unitOfWork.SaveAsync();
            return NoContent();    }

    }
}
