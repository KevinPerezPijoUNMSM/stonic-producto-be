using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stonic_producto_be.model
{
    public class Libro
    {
        public long IdLibro { get; set; }
        public DateTime? FechaPublicacion { get; set; } 
        public int? Edicion { get; set; }  
        public bool FlagAutorAnonimo { get; set; } 

    }
}
