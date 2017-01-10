using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Modelo.Tabelas;
using Modelo.Cadastros;

namespace Modelo.Tabelas {
    public class Pacote {
        public long? PacoteId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int QuantidadeDias { get; set; }

        public virtual ICollection<Compra> Compras { get; set; }
    }
}