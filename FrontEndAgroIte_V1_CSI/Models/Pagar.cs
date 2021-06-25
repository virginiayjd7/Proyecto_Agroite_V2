using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FrontEndAgroIte_V1_CSI.Models
{
    public class Pagar
    { 

            public string correo { get; set; }
            public string token { get; set; }
            public int precio { get; set; }
            public string producto { get; set; }
    }
}