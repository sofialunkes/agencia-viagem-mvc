using System.Linq;
using Modelo.Tabelas;
using Persistencia.Contexts;
using System.Data.Entity;

namespace Persistencia.DAL.Tabelas {
    public class PacoteDAL {

        private EFContext context = new EFContext();

        public IQueryable<Pacote> ObterPacotesPorNome() {
            return context.Pacotes.OrderBy(p => p.Nome);
        }

        public Pacote ObterPacotePorId(long id) {
            return context.Pacotes.Where(p => p.PacoteId == id).Include("Compras.Cliente").First();
        }

        public void GravarPacote(Pacote pacote) {
            if(pacote.PacoteId == null) {
                context.Pacotes.Add(pacote);
            } else {
                context.Entry(pacote).State = EntityState.Modified;
            }
            context.SaveChanges();
        }

        public Pacote EliminarPacotePorId(long id) {
            Pacote pacote = ObterPacotePorId(id);
            context.Pacotes.Remove(pacote);
            context.SaveChanges();
            return pacote;
        }
    }
}
