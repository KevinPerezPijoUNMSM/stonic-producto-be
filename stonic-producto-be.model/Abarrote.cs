using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stonic_producto_be.model
{
    public class Abarrote
    {
        public long IdAbarrote { get; set; }  
        public decimal Contenido { get; set; }  
        public long ContenidoUnidad { get; set; } 
        public long? ContenidoMedida { get; set; }
    }
}
