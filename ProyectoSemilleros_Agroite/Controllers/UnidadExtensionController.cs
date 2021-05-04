using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoSemilleros_Agroite.Models;
namespace ProyectoSemilleros_Agroite.Controllers
{
    public class UnidadExtensionController : Controller
    {
        // GET: UnidadExtension

        public UnidadExtension unidadextension = new UnidadExtension();

        public ActionResult Index(String criterio)
        {
            if (criterio == null || criterio == "")
            {
                return View(unidadextension.Listar());
            }
            else
            {
                return View(unidadextension.Buscar(criterio));
            }
        }

        public ActionResult AgregarEditar(int id = 0)
        {
            ViewBag.Tipo = unidadextension.Listar();

            return View(id == 0 ? new UnidadExtension() : unidadextension.Obtener(id));
        }
        public ActionResult Guardar(UnidadExtension model)
        {
            if (ModelState.IsValid)
            {
                model.Guardar();
                return Redirect("~/UnidadExtension");
            }
            else
            {
                return View("~/UnidadExtension/NuevaUnidadExtension", model);
            }
        }

        public ActionResult Eliminar(int id)
        {
           unidadextension.IdUnidadExtension = id;
            unidadextension.Eliminar();
            return Redirect("~/UnidadExtension");
        }

        public ActionResult Visualizar(int id)
        {
            return View(unidadextension.Obtener(id));
        }
    }
}