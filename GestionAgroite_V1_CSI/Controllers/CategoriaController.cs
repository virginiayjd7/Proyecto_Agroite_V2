using GestionAgroite_V1_CSI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestionAgroite_V1_CSI.Controllers
{
    public class CategoriaController : Controller
    {
        // GET: Categoria
        public Categoria categoria = new Categoria();
        public ActionResult Index(String criterio)
        {
            if (criterio == null || criterio == "")
            {
                return View(categoria.Listar());
            }
            else
            {
                return View(categoria.Buscar(criterio));
            }
        }
        public ActionResult NuevaCategoria(int id = 0)
        {
            ViewBag.Tipo = categoria.Listar();

            return View(id == 0 ? new Categoria() : categoria.Obtener(id));
        }
        public ActionResult Guardar(Categoria model)
        {
            if (ModelState.IsValid)
            {
                model.Guardar();
                return Redirect("~/Categoria");
            }
            else
            {
                return View("~/Categoria/NuevaCategoria", model);
            }
        }
        public ActionResult Eliminar(int id)
        {
            categoria.IdCategoria = id;
            categoria.Eliminar();
            return Redirect("~/Categoria");
        }
        public ActionResult AgregarEditar(int id = 0)
        {
            ViewBag.Tipo = categoria.Listar();

            return View(id == 0 ? new Categoria() : categoria.Obtener(id));
        }

        public ActionResult Visualizar(int id)
        {
            return View(categoria.Obtener(id));
        }

    }
}
