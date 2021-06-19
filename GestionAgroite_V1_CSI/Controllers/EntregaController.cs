using GestionAgroite_V1_CSI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestionAgroite_V1_CSI.Controllers
{
    public class EntregaController : Controller
    {
        Entrega entre = new Entrega();
        // GET: Entrega
        public ActionResult Index()
        {
            var query = entre.Listar();
            return View(query);
        }
    }
}