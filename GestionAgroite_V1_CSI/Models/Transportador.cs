namespace GestionAgroite_V1_CSI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("Transportador")]
    public partial class Transportador
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Transportador()
        {
            Compra = new HashSet<Compra>();
            Pedido = new HashSet<Pedido>();
            Venta = new HashSet<Venta>();
        }

        [Key]
        public int IdTransportador { get; set; }

        public int? IdVehiculo { get; set; }

        [StringLength(50)]
        public string Nombre { get; set; }

        [StringLength(20)]
        public string Tefono { get; set; }

        [StringLength(200)]
        public string Email { get; set; }

        public int? Disponibilidad { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Compra> Compra { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pedido> Pedido { get; set; }

        public virtual Vehiculos Vehiculos { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Venta> Venta { get; set; }
        public List<Transportador> Listar()
        {
            var trasnpoador = new List<Transportador>();
            try
            {
                using (var db = new agroite())
                {
                    trasnpoador = db.Transportador.Include("Vehiculos").ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return trasnpoador;
        }
        public Transportador Obtener(int id)
        {
            var oTransportador = new Transportador();
            using (var db = new agroite())
            {
                oTransportador = db.Transportador.Include("Vehiculos").Where(x => x.IdTransportador == id).SingleOrDefault();
            }
            return oTransportador;
        }
        public List<Transportador> Buscar(string criterio)
        {
            var oTransportador = new List<Transportador>();
            try
            {
                using (var db = new agroite())
                {
                    oTransportador = db.Transportador.Include("Vehiculos").Where(x => x.Nombre.Contains(criterio) || x.Tefono.Contains(criterio) || x.Email.Contains(criterio)).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return oTransportador;
        }
        public void Guardar()
        {
            try
            {
                using (var db = new agroite())
                {
                    if (this.IdTransportador > 0)
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
            catch (Exception)
            {
                throw;
            }
        }
        public void Eliminar()
        {
            try
            {
                using (var db = new agroite())
                {
                    db.Entry(this).State = EntityState.Deleted;
                    db.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
