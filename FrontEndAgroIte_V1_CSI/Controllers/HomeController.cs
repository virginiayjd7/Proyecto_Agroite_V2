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
            return View();
        }
    }
}