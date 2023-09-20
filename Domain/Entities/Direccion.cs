using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities;

public class Direccion : BaseEntity
{
    public int IdCiudadFk { get; set; }
    public Ciudad Ciudad {get; set;}
    public string Calle {get; set;}
    public string Numero {get; set;}
    public ICollection<Persona> Personas {get; set;}
}
