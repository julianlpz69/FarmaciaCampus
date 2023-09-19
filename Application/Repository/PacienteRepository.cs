
using Domain.Entities;
using Domain.Interface;
using Persistence.Data;

namespace Application.Repository;

public class PacienteRepository : GenericRepository<Paciente>, IPaciente
{
    private readonly FarmaciaDBContext _context;
    public PacienteRepository(FarmaciaDBContext context) : base(context)
    {
        _context = context;
    }

}
