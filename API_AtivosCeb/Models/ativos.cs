using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_AtivosCeb.Models
{
    public class ativos
    {
        public int idAtivo { get; set; }
        public string item { get; set; }
        public int idPiso { get; set; }
        public int idLocal { get; set; }
        public int idFabricante { get; set; }
        public string modelo { get; set; }
        public string comentarios { get; set; }
        public string dataRetirada { get; set; }
        public string dataRegistro { get; set; }
        public decimal valor { get; set; }
        public string condicao { get; set; }
        public int idCategoria { get; set; }
        public string serviceTag { get; set; }
        public int patrimonio { get; set; }
        public string garantia { get; set; }
        public string numeroSerie { get; set; }
    }
}