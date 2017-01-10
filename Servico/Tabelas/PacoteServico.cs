using Modelo.Tabelas;
using Persistencia.DAL.Tabelas;
using System.Linq;

namespace Servico.Tabelas {
    public class PacoteServico {

        private PacoteDAL pacoteDAL = new PacoteDAL();

        public IQueryable<Pacote> ObterPacotesPorNome() {
            return pacoteDAL.ObterPacotesPorNome();
        }

        public Pacote ObterPacotePorId(long id) {
            return pacoteDAL.ObterPacotePorId(id);
        }

        public void GravarPacote(Pacote pacote) {
            pacoteDAL.GravarPacote(pacote);
        }

        public Pacote EliminarPacotePorId(long id) {
            return pacoteDAL.EliminarPacotePorId(id);
        }
    }
}
