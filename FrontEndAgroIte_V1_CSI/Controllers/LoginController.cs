using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FrontEndAgroIte_V1_CSI.Filters;
using FrontEndAgroIte_V1_CSI.Models;
namespace FrontEndAgroIte_V1_CSI.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        private Usuario usuario = new Usuario();
        private Actividad actividad = new Actividad();
        // GET: Login
        [NoLogin]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Acceder(string usuario, string password)
        {

            var rm = usuario.Acceder(usuario, password);
            if (rm.response)
            {
                rm.href = Url.Content("~/Usuario/Menu");
                Session["idusuario"] = rm.idusuario;
                string ud = Session["idusuario"].ToString();

            }
            return Redirect("~/Usuario/Menu");
        }

        public ActionResult LogOut()
        {
            SessionHelper.DestroyUserSession();
            Session.Clear();
            return Redirect("~/Home/Index");
        }
        public ActionResult SignUp()
        {
            return View();
        }
        public ActionResult LogIn()
        {
            return View();
        }
       
        public ActionResult Registrarse()
        {
            ViewBag.Tipo3 = actividad.Listar();
            return View(new Usuario());
        }
        [HttpPost]
        public ActionResult Guardar(Usuario model, HttpPostedFileBase imgfile1)
        {
            if (imgfile1.ContentLength > 0)
            {
                ModelState.Remove("Foto_Perfil");
                if (ModelState.IsValid)
                {
                    model.Guardar(imgfile1);
                    return Redirect("~/Login/Index");
                }

            }
            return Redirect("~/Usuario/AgregarEditar");
        }
    }
}