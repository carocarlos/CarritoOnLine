using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaPresentacionAdmin.Models
{
    public class Producto
    {
        public int Idproducto { get; set; }
        public string Descripcion { get; set; }
        public Marca OMarca { get; set; }
        public Categoria OCategoria { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public string RutaImagen { get; set; }
        public string NombreImagen { get; set; }
        public bool Activo { get; set; }
    }
}
