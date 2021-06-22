namespace GestionAgroite_V1_CSI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("Compra")]
    public partial class Compra
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Compra()
        {
            DetalleCompra = new HashSet<DetalleCompra>();
        }

        [Key]
        public int IdCompra { get; set; }

        [StringLength(50)]
        public string Fecha { get; set; }

        public decimal? Total { get; set; }

        public int? IdUsuario { get; set; }

        public int? IdTransportador { get; set; }

        public virtual Transportador Transportador { get; set; }

        public virtual Usuario Usuario { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetalleCompra> DetalleCompra { get; set; }
        public ModelCompra vmComprasRealizadas()
        {
            var vmCompra = new ModelCompra();
            var oUsuario = new Usuario();
            var oProducto = new Producto();
            var oDetalleCompra = new DetalleCompra();
            var oTransportista = new Transportador();
            var oAsociacion = new Asociacion();
            try
            {
                using (var db = new agroite())
                {
                    vmCompra.oCompras = db.Compra.Include("Usuario").Include("Transportador").ToList();
                    vmCompra.oUsuario = oUsuario.Listar();
                    vmCompra.oProducto = oProducto.Listar();
                    vmCompra.transportador = oTransportista.Listar();
                    vmCompra.oDetallecompra = oDetalleCompra.Listar();
                    vmCompra.asociacion = oAsociacion.Listar();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return vmCompra;
        }
        public int Guardar()
        {
            int idl = 0;
            try
            {
                using (var db = new agroite())
                {
                    if (this.IdCompra > 0)
                    {
                        db.Entry(this).State = EntityState.Modified;
                    }
                    else
                    {
                        db.Entry(this).State = EntityState.Added;
                    }
                    db.SaveChanges();
                    idl = this.IdCompra;
                }
            }
            catch (Exception ex)
            {
                //return 0;
                throw;
            }
            return idl;
        }

        public Producto Obtener(int id)
        {
            var producto = new Producto();
            try
            {
                using (var db = new agroite())
                {
                    db.Configuration.ProxyCreationEnabled = false;
                    producto = db.Producto.Where(x => x.IdProducto == id).SingleOrDefault();
                }

            }
            catch (Exception)
            {
                throw;
            }
            return producto;
        }
    }
}
