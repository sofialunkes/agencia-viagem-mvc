using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace agencia_viagem_mvc.Models {
    public class Contrato {
        public long Id { get; set; }

        public long? PacoteId { get; set; }
        public long? PagamentoId { get; set; }

        public Pacote Pacote { get; set; }
        public TipoPagamento Pagamento { get; set; }
    }
}