using FrontEndAgroIte_V1_CSI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FrontEndAgroIte_V1_CSI.Controllers
{
    public class AsociacionController : Controller
    {
        // GET: Asociacion
        public Asociacion asociacion = new Asociacion();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult NuestrosAsociados(String criterio)
        {
            if (criterio == null || criterio == "")
            {
                return View(asociacion.Listar());
            }
            else
            {
                return View(asociacion.Buscar(criterio));
            }
        }
    }

}