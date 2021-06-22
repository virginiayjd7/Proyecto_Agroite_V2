using GestionAgroite_V1_CSI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestionAgroite_V1_CSI.Controllers
{
    public class VentaController : Controller
    {
        // GET: Venta
        Venta oVenta = new Venta();
        Pedido oPedido = new Pedido();
        DetallePedido oDetallepe = new DetallePedido();
        static string idPedidoLocal = "";

        [HttpGet]
        public ActionResult Index()
        {
            return View(oVenta.vmVentasRealizadas());
        }
        public ActionResult Agregar(string IdPedido)
        {
            idPedidoLocal = IdPedido;
            var query = oPedido.Obtener(int.Parse(IdPedido));
            return View(query);
        }
        public ActionResult Guardar(ViewModel model, string IdTransportador, string Fecha_Entrega)
        {

            Venta obj = new Venta();

            var numero_serie = obj.Listar().Last();
            string año = DateTime.Now.Year.ToString();
            string palabra = numero_serie.Num_Serie;
            string[] cadena = palabra.Split('-');
            int numero = 0;
            numero = Convert.ToInt32(cadena[2]) + 1;

            obj.IdPedido = model.pedido.IdPedido;
            obj.Fecha = DateTime.Now.ToShortDateString();
            obj.Num_Serie = cadena[0] + "-" + año + "-" + numero.ToString();
            //obj.Num_Serie = "AG-2021-0001";
            obj.Total = model.pedido.Total;
            obj.IGV = model.pedido.IGV;
            obj.IdTransportador = int.Parse(IdTransportador);
            int idsub = obj.Guardar();

            foreach (var item in oDetallepe.Listar(obj.IdPedido))
            {
                DetalleVenta detalle = new DetalleVenta();
                detalle.IdVenta = idsub;
                detalle.IdProducto = item.IdProducto;
                detalle.Cantidad = item.Cantidad;
                detalle.Subtotal = item.Subtotal;
                detalle.Guardar();
            }
            oPedido.IdPedido = model.pedido.IdPedido;
            oPedido.Estado = 0;
            oPedido.ChangeStatus(oPedido);

            Entrega entre = new Entrega();
            entre.IdVenta = idsub;
            entre.Fecha_Pedido = model.pedido.Fecha;
            entre.Fechar_Entrega = Fecha_Entrega;
            entre.Fecha_Envio = DateTime.Now.ToShortDateString();
            Usuario usu = new Usuario();
            usu = usu.Obtener(model.pedido.IdUsuario);
            entre.Direccion = usu.Direccion;
            entre.Estado = 1;
            entre.Guardar();

            return Redirect("~/Admin");
        }
        public ActionResult DetalleVenta(DetalleVenta oDetalleVenta)
        {
            int? IdDetalleVenta = oDetalleVenta.IdVenta;
            var query = oDetalleVenta.Listar(IdDetalleVenta);
            return Json(query, JsonRequestBehavior.AllowGet);
        }
        public ActionResult LlenarCabecera(Venta oVenta)
        {
            int? IdVenta = oVenta.IdVenta;
            var query = oVenta.Obtener(IdVenta);
            return Json(query, JsonRequestBehavior.AllowGet);
        }
    }
}