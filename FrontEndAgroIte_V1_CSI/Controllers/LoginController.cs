using FrontEndAgroIte_V1_CSI.Filters;
using FrontEndAgroIte_V1_CSI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FrontEndAgroIte_V1_CSI.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        private Usuario objusuario = new Usuario();
        private Actividad actividad = new Actividad();
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
                Session["idusuario"] = rm.idusuario;
                return Redirect("~/Home/Index");
            }
            return Redirect("~/Login/Index");
        }

        public ActionResult LogOut()
        {
            SessionHelper.DestroyUserSession();
            Session.Clear();
            return Redirect("~/Home/Index");
        }
       
    }
}
    

    
