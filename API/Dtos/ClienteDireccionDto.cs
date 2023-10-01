using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class ClienteDireccionDto
    {
        public int ClienteId { get; set; }
        public string ClienteNombre { get; set; }
        public string ClienteApellido { get; set; }
        public string ClienteCedula { get; set; }
        public string ClienteTelefono { get; set; }
        public int ClienteIdDireccionFk { get; set; }
        public int ClienteIdTipoDocumentoFk { get; set; }

        public int DireccionId { get; set; }
        public string DireccionTipoVia { get; set; }
        public string DireccionCalle { get; set; }
        public string DireccionCarrera { get; set; }
        public string DireccionNumero { get; set; }
        public int DireccionIdCiudadFk { get; set; }
        public string DireccionComplemento { get; set; }
    }
}