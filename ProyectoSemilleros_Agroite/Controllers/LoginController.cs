
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoSemilleros_Agroite.Models;
using ProyectoSemilleros_Agroite.Filters;
namespace ProyectoSemilleros_Agroite.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        private Usuario usuario = new Usuario();
        private Usuario objusuario = new Usuario();
        // GET: Login
        [NoLogin]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Acceder(string usuario, string password)
        {

            var rm = objusuario.Acceder(usuario, password);
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
            return Redirect("~/Login");
        }
        public ActionResult SignUp()
        {
            return View();
        }
        public ActionResult LogIn()
        {
            return View();
        }
    }
}