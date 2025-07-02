using System.ComponentModel.DataAnnotations;

namespace miNegocio.Modelos
{
    public class Direccion
    {
        [Key]
        public int direccionId { get; set; }
        public string calleDireccion { get; set; }
        public string ciudad { get; set; }
        public string provincia { get; set; }
        public string codigoPostal { get; set; }
        public int usuarioId { get; set; }
        public int estado { get; set; }
        // Propiedad de navegación
    }
}
