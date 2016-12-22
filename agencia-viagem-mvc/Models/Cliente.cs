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
        [Display(Name ="Data de Nascimento")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime DataNascimento { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }
        public string Email { get; set; }
        public string Endereco { get; set; }
        public string Bairro { get; set; }
        public Cidade Cidade { get; set; }
    }
}