using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FrontEndAgroIte_V1_CSI.Models;
namespace FrontEndAgroIte_V1_CSI.Controllers
{
    public class ProductoController : Controller
    {
        public Producto producto = new Producto();
        public Categoria categoria = new Categoria();
        public UnidadVolumen unidad = new UnidadVolumen();
        public Frecuencia frecuencia = new Frecuencia();
        public Usuario usuario = new Usuario();
        // GET: Producto
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult DetalleProducto(string idProducto)
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