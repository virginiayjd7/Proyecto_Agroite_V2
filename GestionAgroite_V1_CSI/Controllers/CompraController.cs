using GestionAgroite_V1_CSI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestionAgroite_V1_CSI.Controllers
{
    public class CompraController : Controller
    {
        public static List<DetalleCompra> listaCompra = new List<DetalleCompra>();
        Compra oCompra = new Compra();
        Asociacion oAsocicacion = new Asociacion();
        Transportador oTransporte = new Transportador();
        Vehiculos oVehiculo = new Vehiculos();
        ModelCompra vmCompra = new ModelCompra();
        // GET: Compra
        public ActionResult Index()
        {
            return View(oCompra.vmComprasRealizadas());
        }
        public ActionResult Agregar()
        {
            vmCompra.asociacion = oAsocicacion.Listar();
            vmCompra.compra = oCompra;
            vmCompra.transportador = oTransporte.Listar();
            vmCompra.vehiculos = oVehiculo.listarVehiculos();

            return View(vmCompra);
        }

        public ActionResult AddItems(DetalleCompra detalle)
        {
            Boolean existe = false;
            foreach (var item in listaCompra)
            {
                if (item.IdProducto == detalle.IdProducto)
                {
                    existe = true;
                    break;
                }
            }
            if (existe)
            {
                var TotCompra = listaCompra.Sum(x => x.Subtotal);
                var Cant_Carga = listaCompra.Sum(x => x.Cantidad);
                var list = new
                {
                    lista = listaCompra,
                    total = TotCompra,
                    cantidadCarga = Cant_Carga,
                    existe = true,
                };
                return Json(list, JsonRequestBehavior.AllowGet);
            }
            else
            {
                listaCompra.Add(detalle);
            }
            var Total = listaCompra.Sum(x => x.Subtotal);
            var cantidad_carga = listaCompra.Sum(x => x.Cantidad);
            var data = new
            {
                lista = listaCompra,
                total = Total,
                cantidadCarga = cantidad_carga,
                existe = false,
            };

            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public ActionResult ListProduct(Asociacion a)
        {
            int idd = a.IdAsociacion;
            var query = oAsocicacion.ProductoAsos(idd);
            var data = new
            {
                produc = query
            };
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Guardar(Compra model, string IdTransportador, string Fecha_Entrega)
        {
            model.IdUsuario = 1;
            model.Total = listaCompra.Sum(x => x.Subtotal);
            model.IdTransportador = model.IdTransportador;
            model.Fecha = DateTime.Now.ToShortDateString();
            if (ModelState.IsValid)
            {
                int idreturn = model.Guardar();

                if (idreturn != 0)
                {
                    foreach (var item in listaCompra)
                    {
                        DetalleCompra dt = new DetalleCompra();
                        dt.IdCompra = idreturn;
                        dt.Precio_Unitario = item.Precio_Unitario;
                        dt.IdProducto = item.IdProducto;
                        dt.Cantidad = item.Cantidad;
                        dt.Subtotal = item.Subtotal;
                        dt.Guardar();
                    }
                    listaCompra.Clear();
                    return Json("Registroad", JsonRequestBehavior.AllowGet);
                }
            }

            return View("~/Producto/Index");
        }
        public ActionResult DetalleProducto(Producto obj)
        {
            int idpro = obj.IdProducto;
            var query = oCompra.Obtener(idpro);
            var data = new { datos = query };
            return Json(data, JsonRequestBehavior.AllowGet);
        }


    }
}