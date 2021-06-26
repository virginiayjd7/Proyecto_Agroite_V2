namespace FrontEndAgroIte_V1_CSI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;

    [Table("Pedido")]
    public partial class Pedido
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Pedido()
        {
            DetallePedido = new HashSet<DetallePedido>();
            Venta = new HashSet<Venta>();
        }

        [Key]
        public int IdPedido { get; set; }

        [StringLength(50)]
        public string Fecha { get; set; }

        public int? Estado { get; set; }

        public int? IdUsuario { get; set; }

        public decimal? Total { get; set; }

        public decimal? IGV { get; set; }

        public int? IdTrasportador { get; set; }

        public string Punto_Entrega { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetallePedido> DetallePedido { get; set; }

        public virtual Transportador Transportador { get; set; }

        public virtual Usuario Usuario { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Venta> Venta { get; set; }


        public int RegistarPedido()
        {
            int id = 0;
            try
            {
                using (var db = new agroite())
                {
                    if (this.IdPedido > 0)
                    {
                        db.Entry(this).State = EntityState.Modified;
                    }
                    else
                    {
                        db.Entry(this).State = EntityState.Added;
                    }
                    db.SaveChanges();
                    id = this.IdPedido;
                }
            }
            catch (Exception e)
            {
                throw;
            }
            return id;
        }

    }
}
