using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GestionAgroite_V1_CSI.Models;

namespace GestionAgroite_V1_CSI.Controllers
{
    public class UbicacionController : Controller
    {
        // GET: Ubicacion
        Ubicacion oUbicacion = new Ubicacion();
        Agricultor oAgricultor = new Agricultor();
        public ActionResult Index(string criterio)
        {
            if (criterio == null || criterio == "")
            {
                return View(oAgricultor.Listar());
            }
            else
            {
                return View(oAgricultor.Buscar(criterio));
            }
        }
        public ActionResult UbicacionAgricultor(int id = 0)
        {
            //return View(oAgricultor.Obtener(id));
            ViewBag.Agricultor = oAgricultor.Obtener(id);
            return View(new Ubicacion());
        }
        public ActionResult Guardar(Ubicacion model)
        {
           
            if (ModelState.IsValid)
            {
                model.IdAgricultor = Convert.ToInt32(Request.Form["IdAgricultor"]);
                model.Fecha_Creacion = DateTime.Now.Date;
                model.Guardar();
                return Redirect("~/Ubicacion/Index");
            }
            else
            {
                return RedirectToAction("~/Ubicacion/UbicacionAgricultor", model);
            }
        }
    }
}