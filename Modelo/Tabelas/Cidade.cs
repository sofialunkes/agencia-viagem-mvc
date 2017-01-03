using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Modelo.Tabelas {
    public class Cidade {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string CodigoIbge { get; set; }
        public Estado Estado { get; set; }
    }
}