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
        private Usuario objUsuario = new Usuario();
        private Actividad objActividad = new Actividad();
        public Producto objProducto = new Producto();
        private Asociacion objAsociacion = new Asociacion();
        
        public ActionResult Index(String criterio)
        {
            if (criterio == null || criterio == "")
            {
                return View(objUsuario.Listar());
            }
            else
            {
                return View(objUsuario.Buscar(criterio));
            }
        }
        public ActionResult Perfil(string idusuario)
        {
            string id = idusuario;
            int idusu = int.Parse(id);
            return View(objUsuario.Obtener(idusu));

        }
        public ActionResult Menu()
        {
            string id = Session["idusuario"].ToString();
            int idusuario = Convert.ToInt32(id);
            return View(objUsuario.Obtener(idusuario));

        }
        public ActionResult Ver(int id)
        {
            return View(objUsuario.Obtener(id));
        }

        public ActionResult Buscar(string criterio)
        {
            return View(criterio == null || criterio == "" ? objUsuario.Listar() : objUsuario.Buscar(criterio));
        }

        public ActionResult AgregarEditar(int id = 0)
        {
            ViewBag.Tipo3 = objActividad.Listar();
            if (id!=0)
            {
                var imagen = objUsuario.Obtener(id);
                ViewBag.imagen = imagen.Foto_Perfil;
                return View(objUsuario.Obtener(id));
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
            objUsuario.IdUsuario = id;
            objUsuario.Eliminar();
            return Redirect("~/usuario");
        }        
    }
}