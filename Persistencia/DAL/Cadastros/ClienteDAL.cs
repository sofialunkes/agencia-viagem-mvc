using Persistencia.Contexts;
using Modelo.Cadastros;
using System.Linq;

namespace Persistencia.DAL.Cadastros {
    public class ClienteDAL {

        private EFContext context = new EFContext();

        public IQueryable<Cliente> ObterClientesPorNome() {
            return context.Clientes.OrderBy(c => c.Nome);
        }
    }
}
