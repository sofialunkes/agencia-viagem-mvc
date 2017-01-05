using Modelo.Tabelas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Modelo.Cadastros{
    public class Compra {
        public long? CompraId { get; set; }
        public string Descricao { get; set; }
        public DateTime DataAquisicao { get; set; }

        public long? ClienteId { get; set; }
        public long? PacoteId { get; set; }

        public Cliente Cliente { get; set; }
        public Pacote Pacote { get; set; }
        
    }
}