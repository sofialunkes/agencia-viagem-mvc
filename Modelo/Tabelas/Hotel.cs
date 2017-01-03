using Modelo.Cadastros;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Modelo.Tabelas {
    public class Hotel {
        public long Id { get; set; }
        [Display(Name = "Nome")]
        public string NomeFantasia { get; set; }
        public string Classificacao { get; set; }
        public string Endereco { get; set; }
        public Cidade Cidade { get; set; }

        public virtual ICollection<Pacote> Pacotes { get; set; }
    }
}