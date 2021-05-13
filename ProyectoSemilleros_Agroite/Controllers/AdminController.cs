using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoSemilleros_Agroite.Models;

namespace ProyectoSemilleros_Agroite.Controllers
{
    public class AdminController : Controller
    {
        private Usuario usuario = new Usuario();
        // GET: Admin
        public ActionResult Index()
        {
            string id = Session["idusuario"].ToString();
            int idusuario = Convert.ToInt32(id);
            return View(usuario.Obtener(idusuario));
        }
    }
}