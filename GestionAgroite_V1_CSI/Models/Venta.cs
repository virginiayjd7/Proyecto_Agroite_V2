namespace GestionAgroite_V1_CSI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("Venta")]
    public partial class Venta
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Venta()
        {
            DetalleVenta = new HashSet<DetalleVenta>();
            Entrega = new HashSet<Entrega>();
        }

        [Key]
        public int IdVenta { get; set; }

        [StringLength(50)]
        public string Fecha { get; set; }

        [StringLength(12)]
        public string Num_Serie { get; set; }

        public int? IdPedido { get; set; }

        public decimal? Total { get; set; }

        public decimal? IGV { get; set; }

        public int? IdTransportador { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetalleVenta> DetalleVenta { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Entrega> Entrega { get; set; }

        public virtual Pedido Pedido { get; set; }

        public virtual Transportador Transportador { get; set; }

        public List<Venta> Listar()
        {
            var oVenta = new List<Venta>();
            try
            {
                using (var db = new agroite())
                {
                    oVenta = db.Venta.Include("Pedido").Include("Transportador").ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return oVenta;
        }
        public VModelVenta vmVentasRealizadas()
        {
            var VMVenta = new VModelVenta();
            //var Ventas = new List<VModelVenta>();
            var oPedido = new Pedido();
            var oProducto = new Producto();
            var oDetallePedido = new DetallePedido();
            var oTransportista = new Transportador();
            try
            {
                using (var db = new agroite())
                {
                    VMVenta.Venta = db.Venta.Include("Pedido").Include("Transportador").ToList();
                    VMVenta.pedido = oPedido.Listar();
                    VMVenta.producto = oProducto.Listar();
                    VMVenta.detallepedido = oDetallePedido.tabla();
                    VMVenta.transportador = oTransportista.Listar();
                }
            }
            catch (Exception)
            {
                throw;
            }
            //Ventas.Add(VMVenta);
            return VMVenta;
        }
        public List<Venta> Obtener(int? idVenta)
        {
            var detalle = new List<Venta>();
            try
            {
                using (var db = new agroite())
                {
                    var query = (from v in db.Venta
                                 join t in db.Transportador on v.IdTransportador equals t.IdTransportador
                                 join p in db.Pedido on v.IdPedido equals p.IdPedido
                                 join u in db.Usuario on p.IdUsuario equals u.IdUsuario
                                 where v.IdVenta == IdVenta
                                 select new
                                 {
                                     v.Fecha,
                                     v.Num_Serie,
                                     u.Nombres,
                                     u.Apellidos,
                                     t.Nombre,
                                     v.Total
                                 }).ToList();

                    foreach (var item in query)
                    {
                        Transportador t = new Transportador();
                        Usuario u = new Usuario();
                        Pedido p = new Pedido();
                        u.Nombres = item.Nombres;
                        u.Apellidos = item.Apellidos;
                        t.Nombre = item.Nombre;
                        p.Usuario = u;
                        detalle.Add(new Venta()
                        {
                            Transportador = t,
                            Pedido = p,
                            Fecha = item.Fecha,
                            Num_Serie = item.Num_Serie,
                            Total = item.Total
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
        public int Guardar()
        {
            int idl = 0;
            try
            {
                using (var db = new agroite())
                {
                    if (this.IdVenta > 0)
                    {
                        db.Entry(this).State = EntityState.Modified;
                    }
                    else
                    {
                        db.Entry(this).State = EntityState.Added;
                    }
                    db.SaveChanges();
                    idl = this.IdVenta;
                }
            }
            catch (Exception ex)
            {
                //return 0;
                throw;
            }
            return idl;
        }
    }
}
