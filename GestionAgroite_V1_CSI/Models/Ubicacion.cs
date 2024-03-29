namespace GestionAgroite_V1_CSI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("Ubicacion")]
    public partial class Ubicacion
    {
        [Key]
        public int IdUbicacion { get; set; }

        public int IdAgricultor { get; set; }

        [Required]
        [StringLength(40)]
        public string latitud { get; set; }

        [Required]
        [StringLength(40)]
        public string longitud { get; set; }

        public DateTime? Fecha_Creacion { get; set; }

        public Ubicacion Obtener(int id)
        {
            var oUbicacion = new Ubicacion();
            using (var db = new agroite())
            {
                oUbicacion = db.Ubicacion.Where(x => x.IdAgricultor == id).SingleOrDefault();
            }
            return oUbicacion;
        }
        public void Guardar()
        {
            try
            {
                using (var db = new agroite())
                {
                    if (this.IdUbicacion > 0)
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
    }
}
