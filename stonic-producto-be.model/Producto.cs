namespace stonic_producto_be.model
{
    public class Producto : Base
    {
        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public string? Codigo { get; set; }
        public int IdProductora { get; set; }
        public decimal Contenido { get; set; }
        public int IdMedida { get; set; }
        public string UrlImagen { get; set; }
        public int IdEstado { get; set; }
        public bool flagRevendible { get; set; }
    }
}