using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaPresentacionAdmin.Models
{
    public class DetalleVenta
    {
        public int IdDetalleVenta { get; set; }
        public Venta OVenta { get; set; }
        public Producto Oproducto { get; set; }
        public int Cantidad { get; set; }
        public decimal Total { get; set; }

    }
}
