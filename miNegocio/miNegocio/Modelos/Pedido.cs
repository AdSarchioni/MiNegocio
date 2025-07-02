using System.ComponentModel.DataAnnotations;

namespace miNegocio.Modelos
{
    public class Pedido
    {
        [Key]
        public int pedidoId { get; set; }
        public int usuarioId { get; set; }
        public int direccionId { get; set; }
        public Usuario Usuario { get; set; } // Propiedad de navegación
        public DateTime fechaPedido { get; set; }
        public double total { get; set; }
        public int estado { get; set; }
        public Direccion Direccion { get; set; } // Propiedad de navegación
                                                 // Propiedad de navegación
        public ICollection<Detallespedido> Detallespedido { get; set; } // Nombre correcto
    }
}
