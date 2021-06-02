namespace GestionAgroite_V1_CSI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

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

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetallePedido> DetallePedido { get; set; }

        public virtual Usuario Usuario { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Venta> Venta { get; set; }
        public List<Pedido> Listar()
        {
            var unidadvolumen = new List<Pedido>();
            try
            {
                using (var db = new agroite())
                {
                    unidadvolumen = db.Pedido.Where(x => x.Estado == 1).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return unidadvolumen;
        }



        public ViewModel Obtener(int idpedido)
        {
            var viewmodel = new ViewModel();
            DetallePedido detalle = new DetallePedido();
            Transportador trasnpotador = new Transportador();
            try
            {
                using (var db = new agroite())
                {
                    //viewmodel.
                    // 1 es pendiente   0 ->atendido
                    viewmodel.pedido = db.Pedido.Include("Usuario").Where(x => x.IdPedido == idpedido && x.Estado == 1).FirstOrDefault();
                    //   viewmodel.detallepedido = db.DetallePedido.Where(x => x.IdPedido == idpedido).ToList();
                    viewmodel.detallepedido = detalle.Listar(viewmodel.pedido.IdPedido);
                    viewmodel.transportador = trasnpotador.Listar();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return viewmodel;
        }

        public Pedido ChangeStatus(Pedido c)
        {
            using (var db = new agroite())
            {
                var resul = db.Pedido
                    .Where(d => d.IdPedido.Equals(c.IdPedido)).FirstOrDefault();
                resul.Estado = c.Estado;
                db.SaveChanges();
                return resul;
            }
        }
    }
}