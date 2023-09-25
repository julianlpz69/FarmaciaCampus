using System.Linq.Expressions;
using Domain.Interface;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Application.Repository
{
    public class ClienteRepository : GenericRepository<Cliente>, ICliente
    {
        private readonly FarmaciaDBContext _context;
        public ClienteRepository(FarmaciaDBContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<Cliente>> GetAllAsync()
        {
            return await _context.Clientes.Include(c => c.FacturaVentas).ToListAsync();
        }
        public async Task<Cliente> PacienteQueGastoMasEn2023Async(Task<IEnumerable<Cliente>> pacientesConComprasEn2023Task)
        {
            var pacientesConComprasEn2023 = await pacientesConComprasEn2023Task;

            var pacienteQueGastoMas = pacientesConComprasEn2023
                .Select(c => new
                {
                    Cliente = c,
                    TotalGastado = c.FacturaVentas
                        .Where(f => f.FechaVenta.Year == 2023)
                        .Sum(f => f.ValorTotalMasIva)
                })
                .OrderByDescending(c => c.TotalGastado)
                .FirstOrDefault()?.Cliente;

            return pacienteQueGastoMas;
        }

        public async Task<double> GastosPorClienteAsync(int clienteId)
        {
            double totalGastos = await _context.FacturaVentas
                .Where(fv => fv.Cliente.Id == clienteId)
                .SumAsync(fv => fv.ValorTotalMasIva);

            return totalGastos;
        }

        public async Task<IEnumerable<Cliente>> pacientesConComprasEn2023()
        {
            var pacientes = await _context.Clientes
                .Include(c => c.FacturaVentas)
                .Where(c => c.FacturaVentas
                .Any(f => f.FechaVenta.Year == 2023))
                .ToListAsync();
            return pacientes;
        }
        public async Task<IEnumerable<Cliente>> ClientesSinCompras2023Async()
        {
            var clientes = await _context.Clientes
                .Where(e => !e.FacturaVentas
                    .Any(v => v.FechaVenta.Year == 2023))
                .ToListAsync();

            return clientes;
        }


    }
}