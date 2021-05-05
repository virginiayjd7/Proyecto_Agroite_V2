using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoSemilleros_Agroite.Models;
namespace ProyectoSemilleros_Agroite.Controllers
{
    public class ActividadController : Controller
    {
        // GET: Actividad
        public Actividad actividad = new Actividad();
        public ActionResult Index(String criterio)
        {
            if (criterio == null || criterio == "")
            {
                return View(actividad.Listar());
            }
            else
            {
                return View(actividad.Buscar(criterio));
            }
        }

        public ActionResult AgregarEditar(int id = 0)
        {
            ViewBag.Tipo = actividad.Listar();

            return View(id == 0 ? new Actividad() : actividad.Obtener(id));
        }

        public ActionResult Guardar(Actividad model)
        {
            if (ModelState.IsValid)
            {
                model.Guardar();
                return Redirect("~/Actividad");
            }
            else
            {
                return View("~/Actividad/NuevaActividad", model);
            }
        }

        public ActionResult Eliminar(int id)
        {
            actividad.IdActividad = id;
            actividad.Eliminar();
            return Redirect("~/Actividad");
        }
        public ActionResult Visualizar(int id)
        {
            return View(actividad.Obtener(id));
        }

    }
}