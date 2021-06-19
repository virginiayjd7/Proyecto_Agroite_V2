using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionAgroite_V1_CSI.Models
{
    public class VModelVenta
    {
        public List<Pedido> pedido { get; set; }
        public List<Producto> producto { get; set; }
        public List<Venta> Venta { get; set; }
        public List<DetallePedido> detallepedido { get; set; }
        public List<Transportador> transportador { get; set; }
    }
}