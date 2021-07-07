using GestionAgroite_V1_CSI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestionAgroite_V1_CSI.Controllers
{
    public class AgricultorController : Controller
    {
        Agricultor oAgricultor = new Agricultor();
        Asociacion oAsociacion = new Asociacion();
        // GET: Agricultor
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
        public ActionResult AgregarEditar(int id = 0)
        {
            ViewBag.Asociacion = oAsociacion.Listar();
            return View(id == 0 ? new Agricultor() : oAgricultor.Obtener(id));
        }
        public ActionResult Guardar(Agricultor model, HttpPostedFileBase update)
        {
            if (update != null)
            {
                if (update.ContentLength>0)
                {
                    if (ModelState.IsValid)
                    {
                        string path = Path.Combine(Server.MapPath("~/Content/AgricultoresFiles/"), update.FileName);
                        update.SaveAs(path);
                        model.Foto_Perfil = update.FileName;
                        model.Guardar();
                        return Redirect("~/Agricultor/Index");
                    }
                    else
                    {
                        return RedirectToAction("~/Agricultor/AgregarEditar", model);
                    }
                }
                else
                {
                    return RedirectToAction("~/Agricultor/AgregarEditar", model);
                }
            }
            else
            {
                return RedirectToAction("~/Agricultor/AgregarEditar", model);
            }
        }
        public ActionResult Eliminar(int id = 0)
        {
            oAgricultor.IdAgricultor = id;
            oAgricultor.Eliminar();
            return Redirect("~/Agricultor");
        }
        public ActionResult Visualizar(int id = 0)
        {
            return View(oAgricultor.Obtener(id));
        }
    }
}