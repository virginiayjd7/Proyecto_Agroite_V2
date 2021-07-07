using GestionAgroite_V1_CSI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestionAgroite_V1_CSI.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        private Usuario usuario = new Usuario();
        private Actividad actividad = new Actividad();
        public Producto producto = new Producto();
        private Asociacion asociacion = new Asociacion();
        
        public ActionResult Index(String criterio)
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
            string id = idusuario;
            int idusu = int.Parse(id);
            return View(usuario.Obtener(idusu));

        }
        public ActionResult Menu()
        {
            string id = Session["idusuario"].ToString();
            int idusuario = Convert.ToInt32(id);
            return View(usuario.Obtener(idusuario));

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
            if (id!=0)
            {
                var imagen = usuario.Obtener(id);
                ViewBag.imagen = imagen.Foto_Perfil;
                return View(usuario.Obtener(id));
            }

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
                    if (model.IdActividad==3)
                    {
                        model.Guardar(imgfile1);
                        return Redirect("~/Usuario/Index");
                    }                    
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