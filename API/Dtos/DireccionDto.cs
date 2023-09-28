using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos;
public class DireccionDto{
    public int Id { get; set;}
    public string TipoVia {get;set;}
    public string Calle {get;set;}
    public string Carrera {get;set;}
    public string Numero {get;set;}
    public int IdCiudadFk { get; set; }

}