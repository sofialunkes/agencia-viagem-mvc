using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace agencia_viagem_mvc.Models {
    public class Venda {
        public long? Id { get; set; }
        public string Descricao { get; set; }

        public long? ClienteId { get; set; }
        public long? PacoteId { get; set; }

        public Cliente Cliente { get; set; }
        public Pacote Pacote { get; set; }
        
    }
}