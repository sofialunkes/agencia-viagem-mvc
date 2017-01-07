using Persistencia.DAL.Cadastros;
using Modelo.Cadastros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servico.Cadastros {
    public class CompraServico {
        private CompraDAL compraDAL = new CompraDAL();

        public IQueryable<Compra> ObterCompraPorMaiorData() {
            return compraDAL.ObterCompraPorMaiorData();
        }

        public Compra ObterCompraPorId(long id) {
            return compraDAL.ObterCompraPorId(id);
        }

        public void GravarCompra(Compra compra) {
            compraDAL.GravarCompra(compra);
        }

        public Compra EliminarCompraPorId(long id) {
            return compraDAL.EliminarCompraPorId(id);
        }

    }
}
