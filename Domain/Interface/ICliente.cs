using Domain.Entities;
namespace Domain.Interface;

public interface ICliente : IGenericRepository<Cliente>
{
    public Task<Cliente> PacienteQueGastoMasEn2023Async(Task<IEnumerable<Cliente>> pacientesConComprasEn2023Task);
    public Task<double> GastosPorClienteAsync(int clienteId);
    public Task<IEnumerable<Cliente>> pacientesConComprasEn2023();
    public Task<IEnumerable<Cliente>> ClientesSinCompras2023Async();
}