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
       
        //public ActionResult Registrarse()
        //{
        //    ViewBag.Tipo3 = actividad.Listar();
        //    return View(new Usuario());
        //}
     
        public ActionResult Registrarse(int id = 0)
        {
            ViewBag.Tipo = objusuario.Listar2();

            return View(id == 0 ? new Usuario() : objusuario.Obtener2(id));
        }

        public ActionResult Guardar(Usuario model)
        {
            if (ModelState.IsValid)
            {
                model.Guardar();
                return Redirect("~/Home/Index");
            }
            else
            {
                return View("~/Login/Index", model);
            }
        }
    }
}