namespace API.Dtos
{
    public class EmpleadoDireccionDto
    {
        public int EmpleadoId { get; set; }
        public string EmpleadoNombre { get; set; }
        public string EmpleadoApellido { get; set; }
        public string EmpleadoCedula { get; set; }
        public string EmpleadoTelefono { get; set; }
        public int EmpleadoIdDireccionFk { get; set; }
        public int EmpleadoIdCargoEmpleadoFk { get; set; }
        public int EmpleadoIdTipoDocumentoFk { get; set; }

        public int DireccionId { get; set; }
        public string DireccionTipoVia { get; set; }
        public string DireccionCalle { get; set; }
        public string DireccionCarrera { get; set; }
        public string DireccionNumero { get; set; }
        public int DireccionIdCiudadFk { get; set; }
        public string DireccionComplemento { get; set; }

    }
}
