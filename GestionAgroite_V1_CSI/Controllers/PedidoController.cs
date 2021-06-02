using GestionAgroite_V1_CSI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestionAgroite_V1_CSI.Controllers
{
    public class PedidoController : Controller
    {
        Pedido pedido = new Pedido();
        DetallePedido detalle = new DetallePedido();
        // GET: Pedido
        public ActionResult Index()
        {
            var query = pedido.Listar();
            return View(query);
        }


        public ActionResult DetallePedido(Pedido obj)
        {
            int idpedido = obj.IdPedido;
            var query = detalle.Listar(idpedido);
            return Json(query, JsonRequestBehavior.AllowGet);
        }



    }
}