using FrontEndAgroIte_V1_CSI.Filters;
using FrontEndAgroIte_V1_CSI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FrontEndAgroIte_V1_CSI.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
       
        private Usuario objusuario = new Usuario();
        private Actividad actividad = new Actividad();
       
        public ActionResult Registrarse()
        {
            ViewBag.Tipo3 = actividad.Listar();
            return View(new Usuario());
        }
        [HttpPost]
        public ActionResult Guardar(Usuario model, HttpPostedFileBase imgfile1)
        {
            if (imgfile1 == null)
            {
                return Redirect("~/Login/LogOut");
            }
            if (imgfile1.ContentLength > 0)
            {
                ModelState.Remove("Foto_Perfil");
                if (ModelState.IsValid)
                {
                    model.Guardar(imgfile1);
                    return Redirect("~/Login/Index");
                }
            }
            return Redirect("~/Login/LogOut");
        }
    }
}