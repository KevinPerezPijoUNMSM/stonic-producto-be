namespace stonic_producto_be.model
{
    public class Producto : Base
    {
        public long IdProducto { get; set; }
        public string? Nombre { get; set; }
        public string? Codigo { get; set; }
        public long IdProductora { get; set; }
        public string? UrlImagen { get; set; }
        public bool FlagRevendible { get; set; }

        public List<ProductoCategoriaProducto> ProductoCategoriaProducto { get; set; }

        public List<PaqueteUnidad>? PaqueteUnidad { get; set; }

        public Abarrote? Abarrote { get; set; }

    }
}