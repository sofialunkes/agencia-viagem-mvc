using System;
using Modelo.Cadastros;
using Persistencia.DAL.Cadastros;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servico.Cadastros {
    public class ClienteServico {

        private ClienteDAL clienteDAL = new ClienteDAL();

        public IQueryable<Cliente> ObterClientesPorNome() {
            return clienteDAL.ObterClientesPorNome();
        }

    }
}
