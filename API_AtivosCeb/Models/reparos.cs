using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_AtivosCeb.Models
{
    public class reparos
    {
        public int idReparo { get; set; }
        public int idAtivo { get; set; }
        public string dataEnvio { get; set; }
        public string dataRetorno { get; set; }
        public string descDefeito { get; set; }
        public string situacao { get; set; }
    }
}