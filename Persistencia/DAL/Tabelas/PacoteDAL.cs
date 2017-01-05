using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo.Cadastros;
using Persistencia.Contexts;

namespace Persistencia.DAL.Tabelas {
    public class PacoteDAL {
        private EFContext context = new EFContext();
        public IQueryable<Pacote> ObterPacotesPorNome() {
            return context.Pacotes.OrderBy(p => p.Nome);
        }
    }
}
