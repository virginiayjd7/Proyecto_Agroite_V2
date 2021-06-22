using GestionAgroite_V1_CSI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestionAgroite_V1_CSI.Controllers
{
    public class AlmacenController : Controller
    {
        // GET: Almacen
        public Almacen almacen = new Almacen();
        public ActionResult Index(String criterio)
        {
            if (criterio == null || criterio == "")
            {
                return View(almacen.Listar());
            }
            else
            {
                return View(almacen.Buscar(criterio));
            }
        }
        public ActionResult AgregarEditar(int id = 0)
        {
            ViewBag.Tipo = almacen.Listar();

            return View(id == 0 ? new Almacen() : almacen.Obtener(id));
        }

        public ActionResult Guardar(Asociacion model)
        {
            if (ModelState.IsValid)
            {
                model.Guardar();
                return Redirect("~/Almacen");
            }
            else
            {
                return View("~/Almacen/NuevaAlmacen", model);
            }
        }

        public ActionResult Eliminar(int id)
        {
            almacen.IdAlmacen = id;
            almacen.Eliminar();
            return Redirect("~/Actividad");
        }
        public ActionResult Visualizar(int id)
        {
            return View(almacen.Obtener(id));
        }

    }
}