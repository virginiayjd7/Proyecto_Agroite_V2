namespace FrontEndAgroIte_V1_CSI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Almacen")]
    public partial class Almacen
    {
        [Key]
        public int IdAlmacen { get; set; }

        [StringLength(50)]
        public string Nombre { get; set; }

        [StringLength(200)]
        public string Direccion { get; set; }

        [StringLength(50)]
        public string Localidad { get; set; }

        [StringLength(50)]
        public string Provincia { get; set; }

        public decimal? Capacidad { get; set; }

        public int? IdProducto { get; set; }

        public decimal? Precio { get; set; }

        public DateTime? Tiempo_Inicio { get; set; }

        public DateTime? Tiempo_Final { get; set; }

        public decimal? Cantida_Dejada { get; set; }

        [StringLength(50)]
        public string Unidad_Medida { get; set; }

        public virtual Producto Producto { get; set; }
    }
}
