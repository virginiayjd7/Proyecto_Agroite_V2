using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoSemilleros_Agroite.Models;
namespace ProyectoSemilleros_Agroite.Controllers
{
    public class UnidadVolumenController : Controller
    {
        // GET: UnidadVolumen

        public UnidadVolumen unidadvolumen= new UnidadVolumen();

        public ActionResult Index(String criterio)
        {
            if (criterio == null || criterio == "")
            {
                return View(unidadvolumen.Listar());
            }
            else
            {
                return View(unidadvolumen.Buscar(criterio));
            }
        }

        public ActionResult AgregarEditar(int id = 0)
        {
            ViewBag.Tipo = unidadvolumen.Listar();

            return View(id == 0 ? new UnidadVolumen() : unidadvolumen.Obtener(id));
        }

        public ActionResult Guardar(UnidadVolumen model)
        {
            if (ModelState.IsValid)
            {
                model.Guardar();
                return Redirect("~/UnidadVolumen");
            }
            else
            {
                return View("~/UnidadVolumen/NuevaUnidadVolumen", model);
            }
        }

        public ActionResult Eliminar(int id)
        {
            unidadvolumen.IdUnidadVolumen = id;
            unidadvolumen.Eliminar();
            return Redirect("~/UnidadVolumen");
        }

        public ActionResult Visualizar(int id)
        {
            return View(unidadvolumen.Obtener(id));
        }
    }
}