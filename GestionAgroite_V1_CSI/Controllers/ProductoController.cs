using GestionAgroite_V1_CSI.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestionAgroite_V1_CSI.Controllers
{
    public class ProductoController : Controller
    {
        // GET: Producto
        public Producto objProducto = new Producto();
        public Categoria objCategoria = new Categoria();
        public UnidadVolumen objUnidad = new UnidadVolumen();
        public Frecuencia objFrecuencia = new Frecuencia();
        public Usuario objUsuario = new Usuario();
        public Asociacion objAsociacion = new Asociacion();
        public ViewModel oviewModel = new ViewModel();
        public ActionResult Index(String criterio)
        {
            if (criterio == null || criterio == "")
            {
                return View(objProducto.Listar());
            }
            else
            {
                return View(objProducto.Buscar(criterio));
            }
        }
        public ActionResult AgregarEditar(int id = 0)
        {
            //if (id == 0)
            //{
            //    ViewBag.Producto = new Producto();
            //    return View(producto.vmInstancia());
            //}
            //return View(producto.vmObtener(id));
            ViewBag.Asociacion = objAsociacion.Listar();
            ViewBag.Categoria = objCategoria.Listar();
            ViewBag.Frecuencia = objFrecuencia.Listar();
            ViewBag.Unidad = objUnidad.Listar();
            return View(id == 0 ? new Producto(): objProducto.Obtener(id));
        }

        
        [HttpPost]
        public ActionResult Guardar(Producto model, HttpPostedFileBase imgfile)
        {
            foreach (string key in Request.Form.Keys)
            {
                Debug.WriteLine(key + " " + Request.Form[key]);
            }
            if (imgfile != null)
            {
                if (imgfile.ContentLength > 0)
                {
                    if (ModelState.IsValid)
                    {
                        string path = Path.Combine(Server.MapPath("~/Content/ProductosFiles/"), imgfile.FileName);
                        imgfile.SaveAs(path);
                        model.Imagenes_Producto = imgfile.FileName;
                        model.Guardar();
                        return Redirect("~/Producto/Index");
                    }
                    else
                    {
                        return View("Index");
                    }
                }
            }

            return View("~/Producto/Index");

        }
        public ActionResult DetalleProducto(string idProducto)
        {
            string id = idProducto;
            int idpro = Convert.ToInt32(id);
            return View(objProducto.Obtener(idpro));
        }
        public ActionResult Visualizar(int id)
        {
            return View(objProducto.Obtener(id));
        }        
        public ActionResult Eliminar(int id)
        {
            objProducto.IdProducto = id;
            objProducto.Eliminar();
            return Redirect("~/Producto");
        }        
    }
}