namespace API.Dtos
{
    public class ClienteGastoDto
    {
        public int Id { get; set; }
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public double CantidadGastada { get; set; }
    }
}