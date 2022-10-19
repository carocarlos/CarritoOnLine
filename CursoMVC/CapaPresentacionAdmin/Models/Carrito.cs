using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaPresentacionAdmin.Models
{
   public class Carrito
    {
        public int IdCarrito { get; set; }
        public Cliente Ocliente { get; set; }
        public Producto Oproducto { get; set; }
        public int Cantidad { get; set; }
    }
}
