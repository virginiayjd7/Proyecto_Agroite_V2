namespace ProyectoSemilleros_Agroite.Models
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

        public int? IdTransaccion { get; set; }

        public int? IdUsuario { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
