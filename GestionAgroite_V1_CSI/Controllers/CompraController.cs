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
        Ubicacion oUbicacion = new Ubicacion();
        Agricultor oAgricultor = new Agricultor();
        Pedido oPedido = new Pedido();

        Pedido pe = new Pedido();
        // GET: Compra
        public ActionResult Index()
        {

            var lista = pe.Listar2();
            return View(lista);
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
                cantidadCarga= cantidad_carga,
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

        public ActionResult Guardar(Compra model)
        {
            oCompra.Total = model.Total;
            oCompra.IdPedido = model.IdPedido;
            oCompra.IdUsuario = 1;   
            oCompra.Fecha= DateTime.Now.ToShortDateString();         
           // ChangeStatus  
            if (ModelState.IsValid)
            {
                int idreturn = oCompra.Guardar();
                pe.ChangeStatus((int)model.IdPedido, 1);
                if (idreturn != 0)
                {
                    DetallePedido pedid = new DetallePedido();
                    var Detallepeido = pedid.ListaDetallePedido((int)model.IdPedido);
                    foreach (var item in Detallepeido)
                    {
                        DetalleCompra dt = new DetalleCompra();
                        dt.IdCompra = idreturn;
                        dt.Precio_Unitario = item.Producto.Precio_Referencial;
                        dt.IdProducto = item.IdProducto;
                        dt.Cantidad = item.Cantidad;
                        dt.Subtotal = item.Subtotal;
                        dt.Guardar();
                    }
                    // listaCompra.Clear();
                    return Json("Registrado", JsonRequestBehavior.AllowGet);
                }
               //Compra.Guardar2();
              
            }      
            
             return Json("Registrado", JsonRequestBehavior.AllowGet);
        }
        public ActionResult DetalleProducto(Producto obj)
        {
            int idpro = obj.IdProducto;
            var query = oCompra.Obtener(idpro);
            var data = new { datos=query};
            return Json(data,JsonRequestBehavior.AllowGet);
        }
        public ActionResult Realizarcompra(string idpedido)
        {
            
            ViewModel obj = new ViewModel();
            obj = pe.Obtener(int.Parse(idpedido));
            ViewBag.Agricultor = oAgricultor.Obtener(obj.Agricultor.IdAgricultor);
            ViewBag.Ubicacion = oUbicacion.Obtener(obj.Agricultor.IdAgricultor);
            ViewBag.Pedido = oPedido.ObtenerPedidoEntrega(int.Parse(idpedido));
            return View(obj);
        }
        public ActionResult Mapa()
        {
            return View();
        }

    }
}