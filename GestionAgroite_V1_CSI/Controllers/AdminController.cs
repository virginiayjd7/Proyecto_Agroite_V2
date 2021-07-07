using GestionAgroite_V1_CSI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestionAgroite_V1_CSI.Controllers
{
    public class AdminController : Controller
    {
        Venta venta = new Venta();
        Ubicacion oUbicacion = new Ubicacion();
        Agricultor oAgricultor = new Agricultor();

        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Grafico()
        {
            Pedido obj = new Pedido();
            var datos = obj.Grafico();
            return Json(datos, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Grafico2()
        {
            Pedido obj = new Pedido();
            var datos = obj.Grafico2();
            return Json(datos, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Mapa()
        {
            ViewBag.Agricultor = oAgricultor.Obtener(2);
            return View(oUbicacion.Obtener(2));
        }


        public ActionResult Datos()
        {
            Asociacion datos = new Asociacion();

            var data = datos.Datos();

            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}