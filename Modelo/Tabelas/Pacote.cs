using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Modelo.Tabelas;
using Modelo.Cadastros;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Modelo.Tabelas {
    public class Pacote {
        [DisplayName("Id")]
        public long? PacoteId { get; set; }
        [Required(ErrorMessage = "Nome obrigatório")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Descricao obrigatório")]
        public string Descricao { get; set; }
        [Required(ErrorMessage = "Quantidade de Dias precisa ser Informada")]
        public int QuantidadeDias { get; set; }

        public virtual ICollection<Compra> Compras { get; set; }
    }
}