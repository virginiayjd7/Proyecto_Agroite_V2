namespace GestionAgroite_V1_CSI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("DetalleCompra")]
    public partial class DetalleCompra
    {
        [Key]
        public int IdDetalleCompra { get; set; }

        public int? IdProducto { get; set; }

        public int? IdCompra { get; set; }

        public decimal? Cantidad { get; set; }

        public decimal? Precio_Unitario { get; set; }

        public decimal? Subtotal { get; set; }

        public virtual Compra Compra { get; set; }

        public virtual Producto Producto { get; set; }

        [NotMapped]
        public string Nombre { get; set; }

        public List<DetalleCompra> Listar()
        {
            var oDetalle = new List<DetalleCompra>();
            try
            {
                using (var db = new agroite())
                {
                    oDetalle = db.DetalleCompra.Include("Compra").Include("Producto").ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return oDetalle;
        }
        public void Guardar()
        {
            int idl = 0;
            try
            {
                using (var db = new agroite())
                {
                    if (this.IdDetalleCompra > 0)
                    {
                        db.Entry(this).State = EntityState.Modified;
                    }
                    else
                    {
                        db.Entry(this).State = EntityState.Added;
                    }
                    db.SaveChanges();
                    // idl = this.IdCompra;
                }
            }
            catch (Exception ex)
            {
                //return 0;
                throw;
            }

        }
    }
}
