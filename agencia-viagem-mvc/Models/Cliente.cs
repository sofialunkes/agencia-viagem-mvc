using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace agencia_viagem_mvc.Models {
    public class Cliente {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Venda> Vendas { get; set; }

    }
}