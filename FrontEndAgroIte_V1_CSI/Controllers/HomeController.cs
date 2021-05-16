using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FrontEndAgroIte_V1_CSI.Models;
namespace FrontEndAgroIte_V1_CSI.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public Usuario usuario = new Usuario();
        public Producto producto = new Producto();

        public static List<Carrito> lstCarrito = new List<Carrito>();
        public ActionResult Index(string criterio)
        {
            if (criterio == null || criterio == "")
            {
                ViewBag.usuario = usuario.Listar();
                return View(producto.Listar());
            }
            else
            {
                return View();
            }
        }
        public ActionResult Acerca()
        {
            return View();
        }
        public ActionResult Galeria()
        {
            return View();
        }
        public ActionResult Contacto()
        {
            return View();
        }
        public ActionResult CatalogoProductos()
        {
            return View();
        }
        public ActionResult detallecarrito()
        {
            return View(lstCarrito);
        }

        [ChildActionOnly]
        public ActionResult _Carrito()
        {
            List<Carrito> lista = lstCarrito;
         

            return PartialView(lista);            
        }
      
        public ActionResult AgregarCArritoMomentaneo(Carrito o)
        {
            Carrito ca = new Carrito();
            Boolean existe = false;          
            foreach (var item in lstCarrito)
            {
                if (item.id_producto == o.id_producto)                
                {
                    existe = true;                    
                    break;
                }
            }

            if (existe)
            {
                int index = lstCarrito.FindIndex(c => c.id_producto == o.id_producto);
                int can = lstCarrito[index].cantidad;
                decimal sub = lstCarrito[index].subtotal;
                lstCarrito[index].cantidad = can+ o.cantidad;
                lstCarrito[index].subtotal = sub + o.subtotal;
            }
            else
            {
                ca.AgrrgarCrrito(o);
            }
            return Json("Agregado", JsonRequestBehavior.AllowGet);
        }

        public ActionResult Eliminar(Carrito o)
        {
              
            lstCarrito = lstCarrito.Where(c => c.id_producto != o.id_producto).ToList();
            return Json("eliminado", JsonRequestBehavior.AllowGet);
        }
    }
}