using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionAgroite_V1_CSI.Models
{
    public class ViewModel
    {
        public Pedido pedido { get; set; }
        public Producto producto { get; set; }

        public List<DetallePedido> detallepedido { get; set; }

        public List<Transportador> transportador { get; set; }
        public List<Categoria> categoria { get; set; }
        public List<UnidadVolumen> unidadVolumen { get; set; }
        public List<Frecuencia> frecuencia { get; set; }
        public List<Asociacion> asociacion { get; set; }

    }
}