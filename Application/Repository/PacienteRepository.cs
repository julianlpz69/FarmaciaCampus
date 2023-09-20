

using Domain.Entities;
using Domain.Interface;
using Persistence.Data;

namespace Application.Repository;

public class PacienteRepository : GenericRepository<Persona>, IPaciente
{
    public PacienteRepository(FarmaciaDBContext context) : base(context)
    {
    }
}

