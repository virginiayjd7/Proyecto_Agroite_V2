using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoSemilleros_Agroite.Models;
namespace ProyectoSemilleros_Agroite.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public Producto producto = new Producto();
        public ActionResult Index(string criterio)
        {
            if (criterio == null || criterio == "")
            {
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
    }
}