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
      //  [NoLogin]
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
                Session["correo"] = rm.correo;
                Session["nombre"] = rm.nombre;

                return Redirect("~/Home/Index");
            }
            return Redirect("~/Login/Index");
        }

        public ActionResult Ingresar(string user, string password)
        {
            return View();
        }

        public JsonResult Ingreso(string usuario, string password)
        {
           // string epass = HashHelper.SHA256(password);
            var responseModel = objusuario.Acceder(usuario, password);
            if (responseModel.response)
            {
                Session["Email"] = usuario;
                Session["IdCliente"] = responseModel.idusuario;
                responseModel.href = Url.Content("~/Home");
            }

            return Json(responseModel);
        }


        public ActionResult LogOut()
        {
            SessionHelper.DestroyUserSession();
            Session.Clear();
            return Redirect("~/Home/Index");
        }
       
    }
}
    

    
