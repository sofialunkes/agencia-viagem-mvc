using System.Linq;
using Modelo.Tabelas;
using Persistencia.Contexts;

namespace Persistencia.DAL.Tabelas {
    public class PacoteDAL {

        private EFContext context = new EFContext();

        public IQueryable<Pacote> ObterPacotesPorNome() {
            return context.Pacotes.OrderBy(p => p.Nome);
        }
    }
}
