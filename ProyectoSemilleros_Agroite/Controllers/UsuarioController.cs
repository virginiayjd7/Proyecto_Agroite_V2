using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoSemilleros_Agroite.Models;
namespace ProyectoSemilleros_Agroite.Controllers
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
        public ActionResult Index2(String criterio)
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
        public ActionResult Menu()
        {

            //if (criterio == null || criterio == "")
            //{
            //    return View(usuario.Listar());
            //}
            //else
            //{
            string id = Session["idusuario"].ToString();
            int idusuario = Convert.ToInt32(id);
            return View(usuario.Obtener(idusuario));
            //   }

        }
        public ActionResult Ver(int id)
        {
            return View(usuario.Obtener(id));
        }
       
        public ActionResult Buscar(string criterio)
        {
            return View(criterio == null || criterio == "" ? usuario.Listar() : usuario.Buscar(criterio));
        }

        public ActionResult AgregarEditar(int id = 0)
        {
            ViewBag.Tipo3 = actividad.Listar();

            return View(id == 0 ? new Usuario() : usuario.Obtener(id));
        }
        [HttpPost]
        public ActionResult Guardar(Usuario model, HttpPostedFileBase imgfile1)
        {
            if (imgfile1.ContentLength > 0)
            {
                ModelState.Remove("FotoPerfil");
                ModelState.Remove("Identificacion");
                if (ModelState.IsValid)
                {
                    model.Guardar(imgfile1);
                    return Redirect("~/Usuario/Menu");
                }

            }
            return Redirect("~/Usuario/AgregarEditar");
        }

        public ActionResult Eliminar(int id)
        {
            usuario.IdUsuario = id;
            usuario.Eliminar();
            return Redirect("~/usuario");
        }


    }
}