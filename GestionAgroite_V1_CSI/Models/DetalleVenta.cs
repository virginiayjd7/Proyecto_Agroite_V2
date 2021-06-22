namespace GestionAgroite_V1_CSI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("DetalleVenta")]
    public partial class DetalleVenta
    {
        [Key]
        public int IdDetalleVenta { get; set; }

        public int? IdVenta { get; set; }

        public int? IdProducto { get; set; }

        public decimal? Cantidad { get; set; }

        public decimal? Subtotal { get; set; }

        public virtual Producto Producto { get; set; }

        public virtual Venta Venta { get; set; }

        public List<DetalleVenta> Listar(int? idVenta)
        {
            var detalle = new List<DetalleVenta>();
            try
            {
                using (var db = new agroite())
                {
                    var query = (from de in db.DetalleVenta
                                 join pro in db.Producto on de.IdProducto equals pro.IdProducto
                                 where de.IdVenta == IdVenta
                                 select new
                                 {
                                     pro.Nombre_Producto,
                                     pro.Precio_Referencial,
                                     de.Cantidad,
                                     de.Subtotal
                                 }).ToList();

                    foreach (var item in query)
                    {
                        Producto a = new Producto();
                        a.Nombre_Producto = item.Nombre_Producto;
                        a.Precio_Referencial = item.Precio_Referencial;
                        detalle.Add(new DetalleVenta()
                        {
                            Producto = a,
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
        public void Guardar()
        {
            try
            {
                using (var db = new agroite())
                {
                    if (this.IdDetalleVenta > 0)
                    {
                        db.Entry(this).State = EntityState.Modified;
                    }
                    else
                    {
                        db.Entry(this).State = EntityState.Added;
                    }
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
