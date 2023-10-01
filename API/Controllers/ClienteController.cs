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
        public async Task<ActionResult<ClienteDireccionDto>> Post(ClienteDireccionDto ClienteDireccionDto)
        {
            var direccion = new Direccion
            {
                TipoVia = ClienteDireccionDto.DireccionTipoVia,
                Calle = ClienteDireccionDto.DireccionCalle,
                Carrera = ClienteDireccionDto.DireccionCarrera,
                Numero = ClienteDireccionDto.DireccionNumero,
                IdCiudadFk = ClienteDireccionDto.DireccionIdCiudadFk,
                Complemento = ClienteDireccionDto.DireccionComplemento
            };

            _unitOfWork.Direcciones.Add(direccion);
            await _unitOfWork.SaveAsync();

            var Cliente = new Cliente
            {
                Nombre = ClienteDireccionDto.ClienteNombre,
                Apellido = ClienteDireccionDto.ClienteApellido,
                Cedula = ClienteDireccionDto.ClienteCedula,
                Telefono = ClienteDireccionDto.ClienteTelefono,
                IdDireccionFk = direccion.Id,
                IdTipoDocumentoFK = ClienteDireccionDto.ClienteIdTipoDocumentoFk,
            };

            _unitOfWork.Clientes.Add(Cliente);
            await _unitOfWork.SaveAsync();

            ClienteDireccionDto.DireccionId = direccion.Id;
            ClienteDireccionDto.ClienteId = Cliente.Id;

            return CreatedAtAction(nameof(Post), new { id = ClienteDireccionDto.ClienteId }, ClienteDireccionDto);
        }



        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ClienteCrearDto>> Put(int id, [FromBody] ClienteCrearDto ClienteDto)
        {
            if (ClienteDto == null || id != ClienteDto.Id)
            {
                return BadRequest();
            }

            var ClienteExistente = await _unitOfWork.Clientes.GetById(id);
            if (ClienteExistente == null)
            {
                return NotFound();
            }

            ClienteExistente.Nombre = ClienteDto.Nombre;
            ClienteExistente.Apellido = ClienteDto.Apellido;
            ClienteExistente.Cedula = ClienteDto.Cedula;
            ClienteExistente.Telefono = ClienteDto.Telefono;
            ClienteExistente.IdTipoDocumentoFK = ClienteDto.IdTipoDocumentoFK;

            if (ClienteDto.Direccion != null)
            {
                if (ClienteExistente.IdDireccionFk != 0)
                {
                    var direccionExistente = await _unitOfWork.Direcciones.GetById(ClienteExistente.IdDireccionFk);
                    if (direccionExistente != null)
                    {
                        direccionExistente.TipoVia = ClienteDto.Direccion.TipoVia;
                        direccionExistente.Calle = ClienteDto.Direccion.Calle;
                        direccionExistente.Carrera = ClienteDto.Direccion.Carrera;
                        direccionExistente.Numero = ClienteDto.Direccion.Numero;
                        direccionExistente.IdCiudadFk = ClienteDto.Direccion.IdCiudadFk;
                    }
                }
                else
                {
                    var nuevaDireccion = new Direccion
                    {
                        TipoVia = ClienteDto.Direccion.TipoVia,
                        Calle = ClienteDto.Direccion.Calle,
                        Carrera = ClienteDto.Direccion.Carrera,
                        Numero = ClienteDto.Direccion.Numero,
                        IdCiudadFk = ClienteDto.Direccion.IdCiudadFk
                    };
                    _unitOfWork.Direcciones.Add(nuevaDireccion);
                    ClienteExistente.IdDireccionFk = nuevaDireccion.Id;
                }
            }

            await _unitOfWork.SaveAsync();

            var ClienteActualizadoDto = mapper.Map<ClienteCrearDto>(ClienteExistente);

            return Ok(ClienteActualizadoDto);
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

        [HttpGet("Gastos/2023/Mayor")]
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
