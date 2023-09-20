using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interface;
using Persistence.Data;

namespace Application.Repository
{
    public class RolRepository : GenericRepository<Rol>, IRol
    {
    private readonly FarmaciaDBContext _context;

    public RolRepository(FarmaciaDBContext context) : base(context)
    {
        _context = context;
    }
    }
}