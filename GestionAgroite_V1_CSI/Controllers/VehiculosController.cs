using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GestionAgroite_V1_CSI.Models;

namespace GestionAgroite_V1_CSI.Controllers
{
    public class VehiculosController : Controller
    {
        Vehiculos objVehiculo = new Vehiculos();
        // GET: Vehiculos
        public ActionResult Index(string criterio)
        {
            if (criterio == null || criterio == "")
            {
                return View(objVehiculo.Listar());
            }
            else
            {
                return View(objVehiculo.Buscar(criterio));
            }
        }
        public ActionResult AgregarEditar(int id = 0)
        {
            return View(id == 0 ? new Vehiculos() : objVehiculo.Obtener(id));
        }

        public ActionResult Guardar(Vehiculos model)
        {
            if (ModelState.IsValid)
            {
                model.Guardar();
                return Redirect("~/Vehiculos");
            }
            else
            {
                return View("~/Vehiculos/AgregarEditar", model);
            }
        }

        public ActionResult Eliminar(int id)
        {
            objVehiculo.IdVehiculo = id;
            objVehiculo.Eliminar();
            return Redirect("~/Vehiculos");
        }
        public ActionResult Visualizar(int id)
        {
            return View(objVehiculo.Obtener(id));
        }
    }
}