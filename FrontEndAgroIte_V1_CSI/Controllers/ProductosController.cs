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
       
        public Categoria categoria = new Categoria();
        public ActionResult CatalogoProductos(int id = 0)
        {
            if (id == 0)
            {
                ViewBag.asociacion = asociacion.Listar();
                ViewBag.categoria = categoria.Listar();
                return View(producto.Listar());
            }
            else
            {
                ViewBag.productos = producto.Listar();
                ViewBag.asociacion = asociacion.Listar();
                ViewBag.categoria = categoria.Listar();
                return View(producto.ObtenerTipoProducto(id));
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