using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FrontEndAgroIte_V1_CSI.Models;
namespace FrontEndAgroIte_V1_CSI.Controllers
{
    public class UsuarioController : Controller
    {
        private Usuario usuario = new Usuario();
        private Actividad actividad = new Actividad();
        public Producto producto = new Producto();
        private Usuario objModelo = new Usuario();
        //[Autenticado]
        // GET: Usuario
        public ActionResult Index(string criterio)
        {
            if (criterio == null || criterio == "")
            {
                return View(usuario.Listar());
            }
            else
            {
                return View(usuario.Buscar(criterio));
            }
        }
        public ActionResult Perfil(string idusuario)
        {
            //if (criterio == null || criterio == "")
            //{
            //    return View(usuario.Listar());
            //}
            //else
            //{
            string id = idusuario;
            int idusu = int.Parse(id);
            return View(usuario.Obtener(idusu));
            //   }

        }
    }
}