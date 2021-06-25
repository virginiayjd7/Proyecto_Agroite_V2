using FrontEndAgroIte_V1_CSI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FrontEndAgroIte_V1_CSI.Controllers
{
    public class PedidoController : Controller
    {
        Carrito obj = new Carrito();
        Vehiculos ve = new Vehiculos();
        // GET: Pedido
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult DetallePedido()
        {
            var lissta = obj.lista();
            return View(lissta);
        }
        public ActionResult RealizarPedido()
        {
            var lissta = obj.lista();
            return View(lissta);
        }
        public ActionResult ListaTrasnporador()
        {
            var lissta = ve.listarVehiculos();
            return Json(lissta,JsonRequestBehavior.AllowGet);
        }

        public ActionResult Pagar(Pagar model)
        {           
            Security security = new Security();
            security.public_key = "pk_test_88ec032fea5c8f35";
            security.secret_key = "sk_test_5da42cae12edf60d";

            Dictionary<string, object> metadata = new Dictionary<string, object>
                {
                    {"order_id", "1"}
                };

            Dictionary<string, object> charge = new Dictionary<string, object>
                {
                    {"amount", model.precio*100},
                    {"capture", true},
                    {"currency_code", "PEN"},
                    {"description", "Venta de prueba"},
                    {"email", model.correo},
                    {"installments", 0},
                    {"metadata", metadata},
                    {"source_id",model.token}
                };

           // ca.Limpiar();
            string charge_created = new Charge(security).Create(charge);
            return Json(charge_created, JsonRequestBehavior.AllowGet);
        }

    }
}