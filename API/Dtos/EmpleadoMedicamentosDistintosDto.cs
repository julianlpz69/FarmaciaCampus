namespace API.Dtos
{
    public class EmpleadoMedicamentosDistintosDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Cedula { get; set; }
        public int CantidadMedicamentosDistintosVendidos { get; set; }
    }
}