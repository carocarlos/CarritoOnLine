using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaPresentacionAdmin.Models
{
    public class Venta
    {
        public int IdVenta { get; set; }
        public int IdCliente { get; set; }
        public int TotalProducto { get; set; }
        public decimal MontoTotal { get; set; }
        public string IdDistrito { get; set; }
        public int Telefono { get; set; }
        public int Direccion { get; set; }
        public string IdTransaccion { get; set; }
        public string FechaVenta { get; set; }
    }
}
