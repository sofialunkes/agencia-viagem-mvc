using Modelo.Tabelas;
using Persistencia.DAL.Tabelas;
using System.Linq;

namespace Servico.Tabelas {
    public class PacoteServico {

        private PacoteDAL pacoteDAL = new PacoteDAL();

        public IQueryable<Pacote> ObterPacotesPorNome() {
            return pacoteDAL.ObterPacotesPorNome();
        }
    }
}
