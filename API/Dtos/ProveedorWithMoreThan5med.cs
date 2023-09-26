using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos;

public class ProveedorWithMoreThan5med
{
    public string NombreProveedor { get; set; }
    public string ContactoProveedor { get; set; }
    public ICollection<MedicamentoDto> MedicamentoDtos {get; set;}
}
