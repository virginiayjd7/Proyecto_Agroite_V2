using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionAgroite_V1_CSI.Models
{
    public class ModelCompra
    {
        public Compra compra { get; set; }
        public List<Asociacion> asociacion { get; set; }
        public List<Transportador> transportador { get; set; }
        public List<Vehiculos> vehiculos { get; set; }
        public List<Compra> oCompras { get; set; }
        public List<Usuario> oUsuario { get; set; }
        public List<Producto> oProducto { get; set; }
        public List<DetalleCompra> oDetallecompra { get; set; }
    }
}