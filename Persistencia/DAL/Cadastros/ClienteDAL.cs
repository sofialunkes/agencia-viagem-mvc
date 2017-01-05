using Persistencia.Contexts;
using Modelo.Cadastros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo.Tabelas;

namespace Persistencia.DAL.Cadastros {
    public class ClienteDAL {
        private EFContext context = new EFContext();
        public IQueryable<Cliente> ObterClientesPorNome() {
            return context.Clientes.OrderBy(c => c.Nome);
        }
    }
}
