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

        Pedido pedido = new Pedido();
        DetallePedido detallepe = new DetallePedido();
        static string idpedidologal = "";

        [HttpGet]
        public ActionResult Index(string IdPedido)
        {
            idpedidologal = IdPedido;
            var query = pedido.Obtener(int.Parse(IdPedido));
            return View(query);
        }

        public ActionResult Guardar(ViewModel model, string IdTransportador, string Fecha_Entrega)
        {

            Venta obj = new Venta();
            obj.IdPedido = model.pedido.IdPedido;
            obj.Fecha = model.pedido.Fecha;
            obj.Num_Serie = 1;
            obj.Total = model.pedido.Total;
            obj.IGV = model.pedido.IGV;
            obj.IdTransportador = int.Parse(IdTransportador);
            int idsub = obj.Guardar();

            foreach (var item in detallepe.Listar(obj.IdPedido))
            {
                DetalleVenta detalle = new DetalleVenta();
                detalle.IdVenta = idsub;
                detalle.IdProducto = item.IdProducto;
                detalle.Cantidad = item.Cantidad;
                detalle.Subtotal = item.Subtotal;
                detalle.Guardar();
            }
            pedido.IdPedido = model.pedido.IdPedido;
            pedido.Estado = 0;
            pedido.ChangeStatus(pedido);

            Entrega entre = new Entrega();
            entre.IdVenta = idsub;
            entre.Fecha_Pedido = model.pedido.Fecha;
            entre.Fechar_Entrega = Fecha_Entrega;
            entre.Fecha_Envio = Fecha_Entrega;
            Usuario usu = new Usuario();
            usu = usu.Obtener(model.pedido.IdUsuario);
            entre.Direccion = usu.Direccion;

            entre.Guardar();

            return Redirect("~/Admin");
        }
    }
}