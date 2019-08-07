using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_AtivosCeb.Models
{
    public class logs
    {
        public int idLogs { get; set; }
        public string data { get; set; }
        public string hora { get; set; }
        public string usuario { get; set; }
        public string mensagem { get; set; }
        public int idAtivo { get; set; }
    }
}