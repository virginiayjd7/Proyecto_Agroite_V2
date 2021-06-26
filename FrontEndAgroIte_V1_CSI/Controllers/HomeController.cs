using FrontEndAgroIte_V1_CSI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FrontEndAgroIte_V1_CSI.Controllers
{
    public class HomeController : Controller
    {
 
        // GET: Home
        public Asociacion asociacion = new Asociacion();
        public Producto producto = new Producto();
        public  static List<Carrito> carrito = new List<Carrito>();
        
        //public static List<Carrito> lstCarrito = new List<Carrito>();
        public ActionResult Index(string criterio)
        {
            if (criterio == null || criterio == "")
            {
                ViewBag.asociacion = asociacion.Listar();
                return View(producto.Listar());
            }
            else
            {
                return View();
            }
        }
        public ActionResult Nosotros()
        {
            return View();
        }
        public ActionResult Contactenos()
        {
            return View();
        }
        public ActionResult Galeria()
        {
            return View();
        }

        public ActionResult CatalogoProductos()
        {
            return View();
        }
      

        public ActionResult _carrito()
        {
            List<Carrito> lista = carrito;
            return PartialView(lista);
        }

        public ActionResult AgregarCarrito(Carrito o)
        {
            Carrito ca = new Carrito();
            Boolean existe = false;
            foreach (var item in carrito)
            {
                if (item.id_producto == o.id_producto)
                {
                    existe = true;
                    break;
                }
            }

            if (existe)
            {
                int index = carrito.FindIndex(c => c.id_producto == o.id_producto);
                int can = carrito[index].cantidad;
                decimal precio = carrito[index].precio;
                carrito[index].cantidad = can + o.cantidad;
                carrito[index].subtotal = carrito[index].cantidad * precio;
            }
            else
            {
               
                o.subtotal = o.precio*o.cantidad;
               // o.precio = 0;
                ca.AgrrgarCrrito(o);
            }
            return Json("Agregado", JsonRequestBehavior.AllowGet);
        }
        public ActionResult Remove(Carrito o)
        {//eliminar 
            carrito = carrito.Where(c => c.id_producto != o.id_producto).ToList();
            return Json("eliminado", JsonRequestBehavior.AllowGet);
        }
        public ActionResult Update(Carrito o)
        {
            Boolean existe = false;
            foreach (var item in carrito)
            {
                if (item.id_producto == o.id_producto)
                {
                    existe = true;
                    break;
                }
            }
            if (existe)
            {
                int index = carrito.FindIndex(c => c.id_producto == o.id_producto);
                int can = carrito[index].cantidad;
                decimal sub = carrito[index].precio;
                carrito[index].cantidad = o.cantidad;
                carrito[index].subtotal = sub * carrito[index].cantidad;
                // lstCarrito[index].subtotal = sub + o.subtotal;
            }
            var sum = carrito.Sum(x => x.cantidad);
            var Total = carrito.Sum(x => x.subtotal);
            var data = new { cantidad = sum, total = Total };
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Datos()
        {
            var sum = carrito.Sum(x => x.cantidad);
            var Total = carrito.Sum(x => x.subtotal);
            var response = new { cantidad = sum, total = Total };
            return Json(response, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SumarTotal(string preciocamion)
        {
            // string da = preciocamion;
            int pre = int.Parse(preciocamion);
            var sum = carrito.Sum(x => x.cantidad);

            var Total = carrito.Sum(x => x.subtotal)+ pre;
            
            var response = new { cantidad = sum, total = Total };

            return Json(response, JsonRequestBehavior.AllowGet);
        }
    }
}