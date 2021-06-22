namespace GestionAgroite_V1_CSI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("Entrega")]
    public partial class Entrega
    {
        [Key]
        public int IdEntrega { get; set; }

        public int? IdVenta { get; set; }

        [StringLength(11)]
        public string Fecha_Envio { get; set; }

        [StringLength(11)]
        public string Fechar_Entrega { get; set; }

        [StringLength(100)]
        public string Detalles { get; set; }

        [StringLength(100)]
        public string Direccion { get; set; }

        [StringLength(50)]
        public string Fecha_Pedido { get; set; }

        public int? Estado { get; set; }

        public virtual Venta Venta { get; set; }

        public void Guardar()
        {
            int idl = 0;
            try
            {
                using (var db = new agroite())
                {
                    if (this.IdEntrega > 0)
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
            //return idl;
        }
        public List<Entrega> Listar()
        {
            var query = new List<Entrega>();
            try
            {
                using (var db = new agroite())
                {
                    query = db.Entrega.ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return query;
        }
    }
}
