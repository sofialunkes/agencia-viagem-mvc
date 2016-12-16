using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace agencia_viagem_mvc.Models {
    public class Estado {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Uf { get; set; }
    }
}