using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace agencia_viagem_mvc.Models {
    public class Pacote {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int QuantidadeDias { get; set; }

        public List<long?> ClientesId { get; set; }
        public long? ViagemId { get; set; }
        public long? AlimentacaoId { get; set; }

        public List<Cliente> Clientes { get; set; }
        public Viagem Viagem { get; set; }
        public TipoAlimentacao Alimentacao { get; set; }
    }
}