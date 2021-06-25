namespace FrontEndAgroIte_V1_CSI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Pago")]
    public partial class Pago
    {
        [Key]
        public int IdPago { get; set; }

        [StringLength(50)]
        public string Num_Transaccion { get; set; }

        public int? IdUsuario { get; set; }

        public decimal? Cantidad { get; set; }

        [StringLength(50)]
        public string Fecha { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
