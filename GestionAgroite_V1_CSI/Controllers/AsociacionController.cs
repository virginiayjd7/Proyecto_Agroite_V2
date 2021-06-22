using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GestionAgroite_V1_CSI.Models;
namespace GestionAgroite_V1_CSI.Controllers
{
    public class AsociacionController : Controller
    {
        // GET: Asociacion
        public Asociacion asociacion= new Asociacion();
        public ActionResult Index(String criterio)
        {
            if (criterio == null || criterio == "")
            {
                return View(asociacion.Listar());
            }
            else
            {
                return View(asociacion.Buscar(criterio));
            }
        }

        public ActionResult AgregarEditar(int id = 0)
        {
            ViewBag.Tipo = asociacion.Listar();

            return View(id == 0 ? new Asociacion() : asociacion.Obtener(id));
        }

        public ActionResult Guardar(Asociacion model)
        {
            if (ModelState.IsValid)
            {
                model.Guardar();
                return Redirect("~/Asociacion");
            }
            else
            {
                return View("~/Asociacion/NuevaAsociacion", model);
            }
        }

        public ActionResult Eliminar(int id)
        {
            asociacion.IdAsociacion = id;
            asociacion.Eliminar();
            return Redirect("~/Actividad");
        }
        public ActionResult Visualizar(int id)
        {
            return View(asociacion.Obtener(id));
        }

    }
}