using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GestionAgroite_V1_CSI.Models;
namespace GestionAgroite_V1_CSI.Controllers
{
    public class FrecuenciaController : Controller
    {
        public Frecuencia frecuencia = new Frecuencia();

        // GET: Frecuencia
        public ActionResult Index(String criterio)
        {
            if (criterio == null || criterio == "")
            {
                return View(frecuencia.Listar());
            }
            else
            {
                return View(frecuencia.Buscar(criterio));
            }
        }

        public ActionResult AgregarEditar(int id = 0)
        {
            ViewBag.Tipo = frecuencia.Listar();

            return View(id == 0 ? new Frecuencia() : frecuencia.Obtener(id));
        }

        public ActionResult Guardar(Frecuencia model)
        {
            if (ModelState.IsValid)
            {
                model.Guardar();
                return Redirect("~/Frecuencia");
            }
            else
            {
                return View("~/Frecuencia/NuevaFrecuencia", model);
            }
        }

        public ActionResult Eliminar(int id)
        {
            frecuencia.IdFrecuencia = id;
            frecuencia.Eliminar();
            return Redirect("~/Frecuencia");
        }

        public ActionResult Visualizar(int id)
        {
            return View(frecuencia.Obtener(id));
        }
    }
}