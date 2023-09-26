namespace API.Dtos
{
    public class RecetaDto
    {
        public int Id { get; set;}
        public int IdFacturaVentaFK { get; set; }
        public string Remitente { get; set; }
        public string Descripcion { get; set; }
    }
}