namespace GestionAgroite_V1_CSI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("DetallePedido")]
    public partial class DetallePedido
    {
        [Key]
        public int IdDetallePedido { get; set; }

        public int? IdPedido { get; set; }

        public int? IdProducto { get; set; }

        public decimal? Cantidad { get; set; }

        public decimal? Subtotal { get; set; }

        public virtual Pedido Pedido { get; set; }

        public virtual Producto Producto { get; set; }

        public List<DetallePedido> Listar(int? idpedido)
        {
            var detalle = new List<DetallePedido>();
            try
            {
                using (var db = new agroite())
                {
                    var query = (from de in db.DetallePedido
                                 join pro in db.Producto on de.IdProducto equals pro.IdProducto
                                 where de.IdPedido == idpedido
                                 select new
                                 {
                                     de.IdPedido,
                                     de.IdProducto,
                                     pro.Nombre_Producto,
                                     de.Cantidad,
                                     de.Subtotal
                                 }).ToList();

                    foreach (var item in query)
                    {
                        Producto a = new Producto();
                        a.Nombre_Producto = item.Nombre_Producto;
                        detalle.Add(new DetallePedido()
                        {
                            Producto = a,
                            IdPedido = item.IdPedido,
                            IdProducto = item.IdProducto,
                            Cantidad = item.Cantidad,
                            Subtotal = item.Subtotal
                        });

                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return detalle;
        }
        public List<DetallePedido> tabla()
        {
            var oDetalle = new List<DetallePedido>();
            try
            {
                using (var db = new agroite())
                {
                    oDetalle = db.DetallePedido.Include("Pedido").Include("Producto").ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return oDetalle;
        }
    }
}
