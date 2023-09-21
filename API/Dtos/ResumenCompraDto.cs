namespace API.Dtos;

public class ResumenCompraDto
{

    public DateTime FechaSalida { get; set; }
    public int IdClienteFK { get; set; }
    public int IdMedicamentoFk { get; set; }
    //   "fechaVenta": ISODate("2023-01-10"),
    //         "paciente": {
    //             "nombre": "Juan",
    //             "direccion": "Calle 123"
    //         },
    //         "empleado": {
    //             "nombre": "Pedro",
    //             "cargo": "Vendedor"
    //         },
    //         "medicamentosVendidos": [{
    //             "nombreMedicamento": "Paracetamol",
    //             "cantidadVendida": 2, "precio": 20
    //         }]
}
