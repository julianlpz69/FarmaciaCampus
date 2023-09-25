namespace API.Dtos;

    public class MedicamentoVentaDto
    {
        public int Id { get; set; }
        public int IdFacturaVentaFk { get; set; }
        public int IdMedicamentoFk { get; set; }
        public int CantidadVendida { get; set; }
        public double Precio { get; set; }
    }
