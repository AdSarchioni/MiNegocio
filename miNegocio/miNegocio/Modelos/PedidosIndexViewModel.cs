namespace miNegocio.Modelos
{
    public class PedidosIndexViewModel
    {
        public List<Pedido> Pedidos { get; set; }
        public string EstadoSeleccionado { get; set; }
        public int? UsuarioIdSeleccionado { get; set; }
        public List<dynamic> Usuarios { get; set; } // Lista dinámica para opciones de usuario
    }
}
