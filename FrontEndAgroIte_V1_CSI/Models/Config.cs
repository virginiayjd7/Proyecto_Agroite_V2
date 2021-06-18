using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FrontEndAgroIte_V1_CSI.Models
{
    public class Config
    {
        public Config()
        {
        }

        public string url_api_base { get; set; } = "https://api.culqi.com/v2";
    }
}