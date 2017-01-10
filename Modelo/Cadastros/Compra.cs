using Modelo.Tabelas;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Modelo.Cadastros {
    public class Compra {
        [DisplayName("Id")]
        public long? CompraId { get; set; }

        [StringLength(140,ErrorMessage="Descricao deve possuir no maximo 140 caracteres")]
        public string Descricao { get; set; }
        
        [DisplayName("Data de Aquisição")]
        [Required(ErrorMessage ="Data não pode ser nula")]
        public DateTime DataAquisicao { get; set; }

        [DisplayName("Cliente")]
        public long? ClienteId { get; set; }

        [DisplayName("Pacote")]
        public long? PacoteId { get; set; }

        public Cliente Cliente { get; set; }
        public Pacote Pacote { get; set; }
        
    }
}