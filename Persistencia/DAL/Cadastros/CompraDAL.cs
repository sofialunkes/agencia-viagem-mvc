using Persistencia.Contexts;
using Modelo.Cadastros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Persistencia.DAL.Cadastros {
    public class CompraDAL {
        EFContext context = new EFContext();
        public IQueryable<Compra> ObterCompraPorMaiorData() {
            return context.Compras.Include(cl => cl.Cliente).Include(p => p.Pacote).OrderByDescending(c => c.DataAquisicao);
        }
        public Compra ObterCompraPorId(long id) {
            return context.Compras.Where(c => c.CompraId == id).Include(p => p.Pacote).Include(cl => cl.Cliente).First();
        }
        public void GravarCompra(Compra compra) {
            if(compra.CompraId == null) {
                context.Compras.Add(compra);
            }else {
                context.Entry(compra).State = EntityState.Modified;
            }
            context.SaveChanges();
        }
        public Compra EliminarCompraPorId(long id) {
            Compra compra = ObterCompraPorId(id);
            context.Compras.Remove(compra);
            context.SaveChanges();
            return compra;
        }
    }
}
