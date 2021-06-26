using FrontEndAgroIte_V1_CSI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FrontEndAgroIte_V1_CSI.Controllers
{
    public class AgricultorController : Controller
    {
        Agricultor oAgricultor = new Agricultor();
        // GET: Agricultor
        public ActionResult Productores(string criterio)
        {
            if (criterio == null || criterio == "")
            {
                return View(oAgricultor.Listar());
            }
            else
            {
                return View(oAgricultor.Buscar(criterio));
            }
        }
    }
}