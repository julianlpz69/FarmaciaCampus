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


        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ClienteDto>> Get(int id)
        {
            var Cliente = await _unitOfWork.Clientes.GetById(id);
            return mapper.Map<ClienteDto>(Cliente);
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Cliente>> Post(ClienteDto clienteDto)
        {
            var Cliente = this.mapper.Map<Cliente>(clienteDto);
            _unitOfWork.Clientes.Add(Cliente);
            await _unitOfWork.SaveAsync();

            if (Cliente == null)
            {
                return BadRequest();
            }
            clienteDto.Id = Cliente.Id;
            return CreatedAtAction(nameof(Post), new { id = clienteDto.Id }, Cliente);
        }



        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<ClienteDto>> Put(int id, [FromBody] ClienteDto clienteDto)
        {
            if (clienteDto == null)
                return NotFound();

            var cliente = this.mapper.Map<Cliente>(clienteDto);
            _unitOfWork.Clientes.Update(cliente);
            await _unitOfWork.SaveAsync();
            return clienteDto;
        }



        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> Delete(int id)
        {
            var cliente = await _unitOfWork.Clientes.GetById(id);
            if (cliente == null)
                return NotFound();

            _unitOfWork.Clientes.Remove(cliente);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }

        [HttpGet("Gastos/Mayor")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ClienteGastoDto>> ClienteMayoresGastos()
        {
            var clientesConCompras = _unitOfWork.Clientes.pacientesConComprasEn2023();
            var cliente = await _unitOfWork.Clientes.PacienteQueGastoMasEn2023Async(clientesConCompras);
            var gastosCliente = await _unitOfWork.Clientes.GastosPorClienteAsync(cliente.Id);
            var clienteMap = mapper.Map<ClienteGastoDto>(cliente);
            clienteMap.CantidadGastada = gastosCliente;
            return clienteMap;
        }

        [HttpGet("Gastos/2023")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<ClienteGastoDto>>> GastosPorClienteEn2023()
        {
            var pacientesConCompras = await _unitOfWork.Clientes.pacientesConComprasEn2023();
            var gastosPorClienteEn2023 = new List<ClienteGastoDto>();

            foreach (var paciente in pacientesConCompras)
            {
                var gastos = await _unitOfWork.Clientes.GastosPorClienteAsync(paciente.Id);
                var pacienteGastoDto = mapper.Map<ClienteGastoDto>(paciente);
                pacienteGastoDto.CantidadGastada = gastos;

                gastosPorClienteEn2023.Add(pacienteGastoDto);
            }
            return Ok(gastosPorClienteEn2023);
        }
        [HttpGet("compras/2023/Ninguna")]
        public async Task<IEnumerable<ClienteDto>> Clientes0Compras()
        {
            var Clientes = await _unitOfWork.Clientes.ClientesSinCompras2023Async();

            return mapper.Map<List<ClienteDto>>(Clientes);
        }
    }
    }
