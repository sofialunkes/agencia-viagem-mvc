using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Modelo.Cadastros {
    public class Cliente {
        [DisplayName("Id")]
        public long? ClienteId { get; set; }
        [Required(ErrorMessage="Nome obrigatório")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Sobrenome obrigatório")]
        public string Sobrenome { get; set; }
        [Required(ErrorMessage = "Cpf obrigatório")]
        public string Cpf { get; set; }
        public string Rg { get; set; }
        [Required(ErrorMessage = "Email obrigatório")]
        public string Email { get; set; }

        public virtual ICollection<Compra> Compras { get; set; }

    }
}