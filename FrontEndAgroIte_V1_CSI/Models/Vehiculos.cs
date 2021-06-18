namespace FrontEndAgroIte_V1_CSI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    public partial class Vehiculos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Vehiculos()
        {
            Transportador = new HashSet<Transportador>();
        }

        [Key]
        public int IdVehiculo { get; set; }

        [StringLength(20)]
        public string Marca { get; set; }

        [StringLength(20)]
        public string Modelo { get; set; }

        [StringLength(20)]
        public string Año { get; set; }

        [StringLength(20)]
        public string Tipo { get; set; }

        [StringLength(20)]
        public string Placa { get; set; }

        public decimal? Capacidad { get; set; }

        public int? Estado { get; set; }

        public decimal? Precio { get; set; }

        [StringLength(100)]
        public string Unidad_Medida { get; set; }

        [StringLength(50)]
        public string Tipo_Carga { get; set; }

        [StringLength(10)]
        public string Carga_Total { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Transportador> Transportador { get; set; }
        public List<Vehiculos> listarVehiculos()
        {
            var vehiculo = new List<Vehiculos>();
            try
            {
                using (var db = new agroite())
                {
                    db.Configuration.ProxyCreationEnabled = false;
                    vehiculo = db.Vehiculos.ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return vehiculo;
        }
    }
}
