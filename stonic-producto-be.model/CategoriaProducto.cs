using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stonic_producto_be.model
{
    public class CategoriaProducto
    {
        public int IdCategoriaProducto { get; set; }
        public string Nombre { get; set; }
        public int idPadre { get; set; }
    }
}
