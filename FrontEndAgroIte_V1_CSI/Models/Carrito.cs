using FrontEndAgroIte_V1_CSI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FrontEndAgroIte_V1_CSI.Models
{
    public class Carrito
    {
        public int id_cliente { get; set; }
        public int id_empresa { get; set; }
        public int id_producto { get; set; }
        public string nombre_producto { get; set; }
        public string urlfoto { get; set; }
        public int cantidad { get; set; }
        public decimal precio { get; set; }
        public decimal subtotal { get; set; }


        public void AgrrgarCrrito(Carrito o)
        {
            //HomeController.lstCarrito.Add(o);
        }
    }
}