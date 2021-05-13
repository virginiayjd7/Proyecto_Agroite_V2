using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoSemilleros_Agroite.Models
{
    public class ResponseModel
    {
        public dynamic result { get; set; }
        public bool response { get; set; }
        public string message { get; set; }
        public string href { get; set; }
        public string function { get; set; }
        public string idusuario { get; set; }
        public string actividad { get; set; }

        public ResponseModel()
        {
            this.response = false;
            this.message = "Ocurrio un Error Inesperado...!";
        }

        public void SetResponse(bool r, string m = "")
        {
            this.response = r;
            this.message = m;

            if (!r && m == "") this.message = "Ocurrio un Error Inesperado...!";
        }
    }
}