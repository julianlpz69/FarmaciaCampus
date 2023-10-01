using System.Net;
using API.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interface;
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
        public async Task<ActionResult<Empleado>> Post(EmpleadoDto EmpleadoDto)
        {
            var Empleado = this.mapper.Map<Empleado>(EmpleadoDto);
            _unitOfWork.Empleados.Add(Empleado);
            await _unitOfWork.SaveAsync();

            if (Empleado == null)
            {
                return BadRequest();
            }
            EmpleadoDto.Id = Empleado.Id;
            return CreatedAtAction(nameof(Post), new { id = EmpleadoDto.Id }, Empleado);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<EmpleadoDto>> Put(int id, [FromBody] EmpleadoDto EmpleadoDto)
        {
            if (EmpleadoDto == null)
                return NotFound();

            var Empleado = this.mapper.Map<Empleado>(EmpleadoDto);
            _unitOfWork.Empleados.Update(Empleado);
            await _unitOfWork.SaveAsync();
            return EmpleadoDto;
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
            int cantidadVentas = await _unitOfWork.FacturaVentas.VentasEmpleado2023Async(id);

            var empleado = await _unitOfWork.Empleados.GetById(id);
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

            return mapper.Map<EmpleadoMedicamentosDistintosDto>(empleado);
        }
    }
}