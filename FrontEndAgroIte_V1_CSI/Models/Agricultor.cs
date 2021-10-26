namespace FrontEndAgroIte_V1_CSI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("Agricultor")]
    public partial class Agricultor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Agricultor()
        {
            Pedido = new HashSet<Pedido>();
        }

        [Key]
        public int IdAgricultor { get; set; }

        [StringLength(50)]
        public string Nombre { get; set; }

        [StringLength(50)]
        public string Apellidos { get; set; }

        public int? Tipo_Documento { get; set; }

        [StringLength(12)]
        public string Num_Identificacion { get; set; }

        [StringLength(100)]
        public string Foto_Perfil { get; set; }

        [StringLength(9)]
        public string Celular { get; set; }

        [StringLength(200)]
        public string Direccion { get; set; }

        [StringLength(150)]
        public string Correo { get; set; }

        public int? Estado { get; set; }

        public int? IdAsociacion { get; set; }

        public virtual Asociacion Asociacion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pedido> Pedido { get; set; }
        public List<Agricultor> Listar()
        {
            var oAgricutores = new List<Agricultor>();
            try
            {
                using (var db = new agroite())
                {
                    oAgricutores = db.Agricultor.ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return oAgricutores;
        }
        public Agricultor Obtener(int id)
        {
            var oAgricultor = new Agricultor();
            using (var db = new agroite())
            {
                oAgricultor = db.Agricultor.Where(x => x.IdAgricultor == id).SingleOrDefault();
            }
            return oAgricultor;
        }
        public List<Agricultor> Buscar(string criterio)
        {
            var oAgricultores = new List<Agricultor>();
            try
            {
                using (var db = new agroite())
                {
                    oAgricultores = db.Agricultor.Where(x => x.Nombre.Contains(criterio) || x.Apellidos.Contains(Apellidos) || x.Num_Identificacion.Contains(criterio) || x.Direccion.Contains(criterio)).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return oAgricultores;
        }
        
    }
}
