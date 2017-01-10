using Persistencia.Contexts;
using Modelo.Cadastros;
using System.Linq;
using System.Data.Entity;

namespace Persistencia.DAL.Cadastros {
    public class ClienteDAL {

        private EFContext context = new EFContext();

        public IQueryable<Cliente> ObterClientesPorNome() {
            return context.Clientes.OrderBy(c => c.Nome);
        }

        public Cliente ObterClientePorId(long id) {
            return context.Clientes.Where(c => c.ClienteId == id).Include("Compras.Pacote").First();
        }

        public void GravarCliente(Cliente cliente) {
            if(cliente.ClienteId == null) {
                context.Clientes.Add(cliente);
            }else {
                context.Entry(cliente).State = EntityState.Modified;
            }
            context.SaveChanges();
        }

        public Cliente EliminarClientePorId(long id) {
            Cliente cliente = ObterClientePorId(id);
            context.Clientes.Remove(cliente);
            context.SaveChanges();
            return cliente;
        }
    }
}
