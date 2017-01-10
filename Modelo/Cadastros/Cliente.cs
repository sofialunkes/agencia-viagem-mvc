using System.Collections.Generic;

namespace Modelo.Cadastros {
    public class Cliente {
        public long? ClienteId { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Compra> Compras { get; set; }

    }
}