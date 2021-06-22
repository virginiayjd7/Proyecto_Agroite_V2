using GestionAgroite_V1_CSI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestionAgroite_V1_CSI.Controllers
{
    public class TransportadorController : Controller
    {
        Transportador oTransportador = new Transportador();
        // GET: Transportador
        public ActionResult Index(string criterio)
        {
            if (criterio == null || criterio == "")
            {
                return View(oTransportador.Listar());
            }
            else
            {
                return View(oTransportador.Buscar(criterio));
            }
        }
        public ActionResult AgregarEditar(int id = 0)
        {
            return View(id == 0 ? new Transportador() : oTransportador.Obtener(id));
        }
        public ActionResult Guardar(Transportador model)
        {
            if (ModelState.IsValid)
            {
                model.Guardar();
                return Redirect("~/Transportador/Index");
            }
            else
            {
                return RedirectToAction("~/Transportador/AgregarEditar", model);
            }
        }
        public ActionResult Eliminar(int id = 0)
        {
            oTransportador.IdTransportador = id;
            oTransportador.Eliminar();
            return Redirect("~/Transportador");
        }
        public ActionResult Visualizar(int id = 0)
        {
            return View(oTransportador.Obtener(id));
        }
    }
}