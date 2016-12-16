using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace agencia_viagem_mvc.Models {
    public class Hotel {
        public long Id { get; set; }
        public string NomeFantasia { get; set; }
        public string Cnpj { get; set; }
        public string Telefone { get; set; }
        public string Classificacao { get; set; }
        public string Endereco { get; set; }
        public string Bairro { get; set; }
        public Cidade Cidade { get; set; }
    }
}