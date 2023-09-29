using API.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class EmpleadoController : BaseApiController
    {
        private IUnitOfWork _unitOfWork;
        private readonly IMapper mapper;


        public EmpleadoController(IUnitOfWork UnitOfWork, IMapper Mapper)
        {
            _unitOfWork = UnitOfWork;
            mapper = Mapper;
        }

        [HttpGet]
        [Authorize(Roles ="Administrador")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<IEnumerable<EmpleadoDto>>> Get()
        {
            var Empleados = await _unitOfWork.Empleados.GetAllAsync();
            return mapper.Map<List<EmpleadoDto>>(Empleados);

        }


        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<EmpleadoDto>> Get(int id)
        {
            var Empleado = await _unitOfWork.Empleados.GetById(id);
            return mapper.Map<EmpleadoDto>(Empleado);
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<EmpleadoDireccionDto>> Post(EmpleadoDireccionDto empleadoDireccionDto)
        {
            var direccion = new Direccion
            {
                TipoVia = empleadoDireccionDto.DireccionTipoVia,
                Calle = empleadoDireccionDto.DireccionCalle,
                Carrera = empleadoDireccionDto.DireccionCarrera,
                Numero = empleadoDireccionDto.DireccionNumero,
                IdCiudadFk = empleadoDireccionDto.DireccionIdCiudadFk,
                Complemento = empleadoDireccionDto.DireccionComplemento
            };

            _unitOfWork.Direcciones.Add(direccion);
            await _unitOfWork.SaveAsync();

            var empleado = new Empleado
            {
                Nombre = empleadoDireccionDto.EmpleadoNombre,
                Apellido = empleadoDireccionDto.EmpleadoApellido,
                Cedula = empleadoDireccionDto.EmpleadoCedula,
                Telefono = empleadoDireccionDto.EmpleadoTelefono,
                IdDireccionFk = direccion.Id, 
                IdCargoEmpleadoFK = empleadoDireccionDto.EmpleadoIdCargoEmpleadoFk,
                IdTipoDocumentoFK = empleadoDireccionDto.EmpleadoIdTipoDocumentoFk,
            };

            _unitOfWork.Empleados.Add(empleado);
            await _unitOfWork.SaveAsync();

            empleadoDireccionDto.DireccionId = direccion.Id;
            empleadoDireccionDto.EmpleadoId = empleado.Id;

            return CreatedAtAction(nameof(Post), new { id = empleadoDireccionDto.EmpleadoId }, empleadoDireccionDto);
        }


        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<EmpleadoCrearDto>> Put(int id, [FromBody] EmpleadoCrearDto empleadoDto)
        {
            if (empleadoDto == null || id != empleadoDto.Id)
            {
                return BadRequest();
            }

            var empleadoExistente = await _unitOfWork.Empleados.GetById(id);
            if (empleadoExistente == null)
            {
                return NotFound();
            }

            empleadoExistente.Nombre = empleadoDto.Nombre;
            empleadoExistente.Apellido = empleadoDto.Apellido;
            empleadoExistente.Cedula = empleadoDto.Cedula;
            empleadoExistente.Telefono = empleadoDto.Telefono;
            empleadoExistente.IdCargoEmpleadoFK = empleadoDto.IdCargoEmpleadoFK;
            empleadoExistente.IdTipoDocumentoFK = empleadoDto.IdTipoDocumentoFK;

            if (empleadoDto.Direccion != null)
            {
                if (empleadoExistente.IdDireccionFk != 0)
                {
                    var direccionExistente = await _unitOfWork.Direcciones.GetById(empleadoExistente.IdDireccionFk);
                    if (direccionExistente != null)
                    {
                        direccionExistente.TipoVia = empleadoDto.Direccion.TipoVia;
                        direccionExistente.Calle = empleadoDto.Direccion.Calle;
                        direccionExistente.Carrera = empleadoDto.Direccion.Carrera;
                        direccionExistente.Numero = empleadoDto.Direccion.Numero;
                        direccionExistente.IdCiudadFk = empleadoDto.Direccion.IdCiudadFk;
                    }
                }
                else
                {
                    var nuevaDireccion = new Direccion
                    {
                        TipoVia = empleadoDto.Direccion.TipoVia,
                        Calle = empleadoDto.Direccion.Calle,
                        Carrera = empleadoDto.Direccion.Carrera,
                        Numero = empleadoDto.Direccion.Numero,
                        IdCiudadFk = empleadoDto.Direccion.IdCiudadFk
                    };
                    _unitOfWork.Direcciones.Add(nuevaDireccion);
                    empleadoExistente.IdDireccionFk = nuevaDireccion.Id;
                }
            }

            await _unitOfWork.SaveAsync();

            var empleadoActualizadoDto = mapper.Map<EmpleadoCrearDto>(empleadoExistente);

            return Ok(empleadoActualizadoDto);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> Delete(int id)
        {
            var Empleado = await _unitOfWork.Empleados.GetById(id);
            if (Empleado == null)
                return NotFound();

            _unitOfWork.Empleados.Remove(Empleado);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }

        [HttpGet("ventas-por-empleado/{id}")]
        public async Task<ActionResult<EmpleadoVentaDto>> ObtenerVentasPorEmpleadoEn2023(int id)
        {
            var empleado = await _unitOfWork.Empleados.GetById(id);
            if (empleado == null)
            {
                ModelState.AddModelError("Id", "El empleado especificado no existe.");
                return BadRequest(ModelState);
            }

            int cantidadVentas = await _unitOfWork.FacturaVentas.VentasEmpleado2023Async(id);

            var empleadoDto = mapper.Map<EmpleadoVentaDto>(empleado);
            empleadoDto.CantidadVentas = cantidadVentas;

            return empleadoDto;
        }



        [HttpGet("Ventas/mas-de-5")]
        public async Task<IEnumerable<EmpleadoVentaDto>> empleadosmas5ventas()
        {
            var empleados = await _unitOfWork.Empleados.EmpleadosMas5Ventas();
            var emp = new List<EmpleadoVentaDto>();
            foreach (var empleado in empleados)
            {
                int cantidadVentas = await _unitOfWork.FacturaVentas.VentasEmpleado2023Async(empleado.Id);
                var empleadoDto = mapper.Map<EmpleadoVentaDto>(empleado);
                empleadoDto.CantidadVentas = cantidadVentas;
                emp.Add(empleadoDto);
            }

            return emp;
        }
        [HttpGet("Ventas/2023/menos-de-5")]
        public async Task<IEnumerable<EmpleadoVentaDto>> empleadosmenos5ventas()
        {
            var empleados = await _unitOfWork.Empleados.EmpleadosMenos5Ventas();
            var emp = new List<EmpleadoVentaDto>();
            foreach (var empleado in empleados)
            {
                int cantidadVentas = await _unitOfWork.FacturaVentas.VentasEmpleado2023Async(empleado.Id);
                var empleadoDto = mapper.Map<EmpleadoVentaDto>(empleado);
                empleadoDto.CantidadVentas = cantidadVentas;
                emp.Add(empleadoDto);
            }
            return emp;
        }
        [HttpGet("Ventas/2023/Ninguna")]
        public async Task<IEnumerable<EmpleadoDto>> empleados0Ventas()
        {
            var empleados = await _unitOfWork.Empleados.EmpleadosSinVentasAsync();
            
            return mapper.Map<List<EmpleadoDto>>(empleados);
        }
        [HttpGet("Ventas/2023/Abril/Ninguna")]
        public async Task<IEnumerable<EmpleadoDto>> empleados0VentasAbril()
        {
            var empleados = await _unitOfWork.Empleados.EmpleadosSinVentasAbril2023Async();

            return mapper.Map<List<EmpleadoDto>>(empleados);
        }

        [HttpGet("Ventas/2023/Mas-medicamentos-distintos")]
        public async Task<ActionResult<EmpleadoMedicamentosDistintosDto>> empleadoMasMeddistintos()
        {
            var empleado = await _unitOfWork.Empleados.EmpleadoConMasMedicamentosDistintosVendidosEn2023Async();
            if (empleado == null)
            {
                ModelState.AddModelError("EmpleadoId", "No se encontró un empleado con medicamentos vendidos en 2023.");
                return BadRequest(ModelState);
            }

            int cantidadMedicamentosDistintos = await _unitOfWork.Empleados.cantidadMedicamentosDistintosVendidos2023Async();
            if (cantidadMedicamentosDistintos <= 0)
            {
                ModelState.AddModelError("CantidadMedicamentosDistintos", "No se vendieron medicamentos distintos en 2023.");
                return BadRequest(ModelState);
            }

            var empleadoDto = mapper.Map<EmpleadoMedicamentosDistintosDto>(empleado);
            empleadoDto.CantidadMedicamentosDistintosVendidos = cantidadMedicamentosDistintos;
            return empleadoDto;
        }

    }
}