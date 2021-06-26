using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FrontEndAgroIte_V1_CSI.Models
{
    public class ModelCompra
    {
        public  List<Carrito> carrito { get; set; }
        public int Carro { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Total { get; set; }
    }
}