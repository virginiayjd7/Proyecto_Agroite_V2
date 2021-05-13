namespace FrontEndAgroIte_V1_CSI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("Usuario")]
    public partial class Usuario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Usuario()
        {
            Compra = new HashSet<Compra>();
            Pago = new HashSet<Pago>();
            Pedido = new HashSet<Pedido>();
            Producto = new HashSet<Producto>();
        }

        [Key]
        public int IdUsuario { get; set; }

        public int? IdActividad { get; set; }

        [StringLength(250)]
        public string Nombres { get; set; }

        [StringLength(250)]
        public string Apellidos { get; set; }

        public int? Tipo_Documento { get; set; }

        [StringLength(12)]
        public string Num_Identificacion { get; set; }

        public byte[] Foto_Perfil { get; set; }

        [StringLength(9)]
        public string Celular { get; set; }

        [StringLength(200)]
        public string Direccion { get; set; }

        [StringLength(150)]
        public string Correo { get; set; }

        [Required]
        [StringLength(50)]
        public string Alias { get; set; }

        [Required]
        [StringLength(20)]
        public string Contraseña { get; set; }

        [StringLength(200)]
        public string Organizacion { get; set; }

        [StringLength(250)]
        public string Descripcion { get; set; }

        public int? IdAsociacion { get; set; }

        public virtual Actividad Actividad { get; set; }

        public virtual Asociacion Asociacion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Compra> Compra { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pago> Pago { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pedido> Pedido { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Producto> Producto { get; set; }
        public List<Usuario> Listar()
        {
            var usuarios = new List<Usuario>();
            try
            {
                using (var db = new agroite())
                {
                    usuarios = db.Usuario.Include("Actividad").Include("Asociacion").ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return usuarios;
        }
    }
}
