using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace API.Dtos
{
    public class PostCompraDto
    {
            public int Id { get; set; }
            public double ValorTotal { get; set; }
            public DateTime FechaCompra { get; set; }
            public int IdMetodoPagoFk { get; set; }
            public List<MedicamentoCompraPostDto> MedicamentosComprados { get; set; }
            public int IdProveedorFK { get; set; }

    }
}