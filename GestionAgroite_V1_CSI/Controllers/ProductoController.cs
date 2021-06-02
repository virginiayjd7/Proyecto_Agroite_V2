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
        public Producto producto = new Producto();
        public Categoria categoria = new Categoria();
        public UnidadVolumen unidad = new UnidadVolumen();
        public Frecuencia frecuencia = new Frecuencia();
        public Usuario usuario = new Usuario();
        public ViewModel oviewModel = new ViewModel();
        public ActionResult Index(String criterio)
        {
            if (criterio == null || criterio == "")
            {
                return View(producto.Listar());
            }
            else
            {
                return View(producto.Buscar(criterio));
            }
        }
        public ActionResult AgregarEditar(int id = 0)
        {
            if (id == 0)
            {
                return View(producto.vmInstancia());
            }
            return View(producto.vmObtener(id));
        }
        [HttpPost]
        public ActionResult Guardar(ViewModel model, HttpPostedFileBase imgfile)
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
                        model.producto.IdAsociacion = Convert.ToInt32(Request.Form["IdAsociacion"]);
                        model.producto.IdCategoria = Convert.ToInt32(Request.Form["IdCategoria"]);
                        model.producto.IdFrecuencia = Convert.ToInt32(Request.Form["IdFrecuencia"]);
                        model.producto.IdUnidadVolumen = Convert.ToInt32(Request.Form["IdUnidadVolumen"]);
                        model.producto.Imagenes_Producto = imgfile.FileName;
                        model.producto.Guardar();
                        return Redirect("~/Producto/Index");
                    }
                    else
                    {
                        return View("Index", producto.Listar());
                    }
                }
            }

            return View("~/Producto/Index");

        }
        public ActionResult DetalleProducto(Producto oProducto)
        {
            int id = oProducto.IdProducto;
            var query = oProducto.Obtener(id);
            return Json(query, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Visualizar(int id)
        {
            return View(producto.Obtener(id));
        }
        public ActionResult Eliminar(int id)
        {
            producto.IdProducto = id;
            producto.Eliminar();
            return Redirect("~/Producto");
        }
    }
}