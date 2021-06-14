using FrontEndAgroIte_V1_CSI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FrontEndAgroIte_V1_CSI.Controllers
{
    public class ProductosController : Controller
    {
        // GET: Productos
        public Asociacion asociacion = new Asociacion();
        public Producto producto = new Producto();

      
       
        public ActionResult CatalogoProductos(string criterio)
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
        public ActionResult ProductosDetalles(string idProducto)
        {
            
                string id = idProducto;

                // if (idProducto == null || idProducto == "")
                // {
                //     return View(producto.Listar());
                // }
                //     else
                //   {
                //  string id = Session["idusuario"].ToString();
                int idpro = Convert.ToInt32(id);
                return View(producto.Obtener(idpro));

                // return View();
                //   }

            
        }
      
    }
}