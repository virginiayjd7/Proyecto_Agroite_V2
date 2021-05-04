using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoSemilleros_Agroite.Models;
namespace ProyectoSemilleros_Agroite.Controllers
{
    public class ProductoController : Controller
    {
        // GET: Producto
        public Producto producto = new Producto();
        public Categoria categoria = new Categoria();
        public UnidadVolumen unidad = new UnidadVolumen();
        public Frecuencia frecuencia = new Frecuencia();
        public Usuario usuario = new Usuario();
        public ActionResult Index(int idusuario)
        {
            //if (criterio == null || criterio == "")
            //{
            //    return View(producto.Listar());
            //}
            //else
            //{
            var lista = producto.Buscar(idusuario);
            return View(lista);
            //  }
        }
        public ActionResult Index2(String criterio)
        {
            if (criterio == null || criterio == "")
            {
                return View(producto.Listar());
            }
            else
            {
                return View(producto.Buscar2(criterio));
            }
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
        public ActionResult Visualizar(int id)
        {
            return View(producto.Obtener(id));
        }
        public ActionResult NuevoProducto(int id = 0)
        {
            ViewBag.Tipo = categoria.Listar();
            ViewBag.Tipo1 = unidad.Listar();
            ViewBag.Tipo2 = frecuencia.Listar();
            ViewBag.Tipo3 = usuario.Listar();
            return View(id == 0 ? new Producto() : producto.Obtener(id));

        }
        // [HttpPost]
        /*public ActionResult Guardar(Producto model, HttpPostedFileBase imgfile)
        {          
            if (ModelState.IsValid)
            {
                model.Guardar();
                return Redirect("~/Producto");
            }
            else
            {
                return View("~/Producto/NuevoProducto", model);
            }
        }*/

        public ActionResult Eliminar(int id)
        {
            producto.IdProducto = id;
            producto.Eliminar();
            return Redirect("~/Producto");
        }
        [HttpPost]
        public ActionResult Guardar(Producto model, HttpPostedFileBase imgfile)
        {
            if (imgfile.ContentLength > 0)
            {
                ModelState.Remove("ImagenesProducto");
                //    int id = (int)Session["idusuario"];
                string id = Session["idusuario"].ToString();
                model.IdUsuario = Convert.ToInt32(id);

                if (ModelState.IsValid)
                {
                    model.Guardar(imgfile);
                    return Redirect("~/Usuario/Menu");
                }
                else
                {
                    return View("Index", producto.Listar());
                }
            }
            return View("Index", producto.Listar());
            //if (ModelState.IsValid)
            //{
            //    model.Guardar();
            //    return Redirect("~/Producto");
            //}
            //else
            //{
            //    return View("~/Producto/NuevoProducto", model);
            //}
        }
    }
}