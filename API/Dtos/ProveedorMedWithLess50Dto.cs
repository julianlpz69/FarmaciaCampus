using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos;

public class ProveedorMedWithLess50Dto
{
    public string NombreProveedor {get; set;}
    public string ContactoProveedor {get; set;}
    public IEnumerable< MedicamentoDto > Medicamento {get; set;}
}
