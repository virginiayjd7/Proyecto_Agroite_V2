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
        Carrito objcar = new Carrito();
        Vehiculos ve = new Vehiculos();

        public static string idtrasportador1;
        public static string preciocarro1;

        public static string DatosLocation;

        // GET: Pedido
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult DetallePedido()
        {
            var lissta = objcar.lista();
            return View(lissta);
        }

        public ActionResult ListaTrasnporador()
        {
            var lissta = ve.listarVehiculos2();
            return Json(lissta,JsonRequestBehavior.AllowGet);
        }

        public ActionResult Pagar(Pagar model)
        {
            Security security = new Security();
            security.public_key = "pk_test_88ec032fea5c8f35";
            security.secret_key = "sk_test_5da42cae12edf60d";
            var sub = HomeController.carrito.Sum(x => x.subtotal);
            var carro = int.Parse(preciocarro1);
            var TotaCompra = carro + sub;
            Dictionary<string, object> metadata = new Dictionary<string, object>
                {
                    {"order_id", "1"}
                };

            Dictionary<string, object> charge = new Dictionary<string, object>
                {
                    {"amount", TotaCompra*100},
                    {"capture", true},
                    {"currency_code", "PEN"},
                    {"description", "Venta de prueba"},
                    {"email", model.correo},
                    {"installments", 0},
                    {"metadata", metadata},
                    {"source_id",model.token}
                };

            string charge_created = new Charge(security).Create(charge);

            Pedido obj = new Pedido();

            obj.IdUsuario = Convert.ToInt32(Session["idusuario"]);
            obj.Fecha = DateTime.Now.ToLongDateString();
            obj.Estado = 1;
            obj.Total = TotaCompra;
            obj.IGV = 10;
            obj.Punto_Entrega = DatosLocation;
            obj.IdTransportador = int.Parse(idtrasportador1);            // observacion

            int idpedido = obj.RegistarPedido();
            Carrito car = new Carrito();
            foreach (var item in objcar.lista())
            {
                DetallePedido detalle = new DetallePedido();
                detalle.IdPedido = idpedido;
                detalle.IdProducto = item.id_producto;
                detalle.Cantidad = item.cantidad;
                detalle.Subtotal = item.subtotal;
                detalle.RegistarDetallePedido();
            }
            objcar.Limpiar();
            return Json(charge_created, JsonRequestBehavior.AllowGet);
        }

        public ActionResult FinalizarCompra(string preciocarro, string idtrasportador)
        {
            idtrasportador1 = idtrasportador;
            preciocarro1 = preciocarro;

            ModelCompra model = new ModelCompra();
            model.carrito= objcar.lista();
            model.Subtotal = HomeController.carrito.Sum(x => x.subtotal);
            model.Carro = int.Parse(preciocarro);
            model.Total = model.Subtotal + model.Carro;

           // var lissta = objcar.lista();
            return View(model);
        }

        public ActionResult Datos()
        {                
            var sum = HomeController.carrito.Sum(x => x.cantidad);
            var Total = HomeController.carrito.Sum(x => x.subtotal);
            var lista = objcar.lista();
            var data = new {datos=lista, cantidad = sum, total = Total,carro= preciocarro1 };
            return Json(data, JsonRequestBehavior.AllowGet);            
        }

        public ActionResult CheckOut(string datos)
        {
            DatosLocation = datos;
            var subutotal =HomeController.carrito.Sum(x => x.subtotal);
            var total =int.Parse(preciocarro1) + subutotal;
            ViewBag.TotalComra = total;
            return View();
        }

    }
}