using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos;

    public class ProveedorMasVendioDto
    {
        public string NombreProveedor {get; set;}
        public string ContactoProveedor {get; set;}
        public int CantidadVendida {get; set;}
    }
