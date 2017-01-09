using Modelo.Cadastros;
using Persistencia.Contexts;
using System.Linq;
using System.Web.Mvc;
using System.Net;
using System.Data.Entity;
using Servico.Cadastros;
using Servico.Tabelas;

namespace agencia_viagem_mvc.Controllers {
    public class ComprasController : Controller {
        private CompraServico compraServico = new CompraServico();
        private ClienteServico clienteServico = new ClienteServico();
        private PacoteServico pacoteServico = new PacoteServico();

        // GET: Compras
        public ActionResult Index() {
            //var compras = context.Compras.Include(c => c.Cliente).Include(p => p.Pacote).OrderByDescending(co => co.DataAquisicao);
            //return View(compras);
            var compras = compraServico.ObterCompraPorMaiorData();
            return View(compras);
        }

        private ActionResult ObterVisaoCompraPorId(long? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Compra compra = compraServico.ObterCompraPorId((long)id);
            if (compra == null) {
                return HttpNotFound();
            }
            return View(compra);
        }

        private void PopularViewBag(Compra compra = null) {
            if (compra == null) {
                ViewBag.PacoteId = new SelectList(pacoteServico.ObterPacotesPorNome(), "PacoteId", "Nome");
                ViewBag.ClienteId = new SelectList(clienteServico.ObterClientesPorNome(), "ClienteId", "Nome");
            } else {
                ViewBag.PacoteId = new SelectList(pacoteServico.ObterPacotesPorNome(), "PacoteId", "Nome", compra.PacoteId);
                ViewBag.ClienteId = new SelectList(clienteServico.ObterClientesPorNome(), "ClienteId", "Nome", compra.ClienteId);
            }
        }

        private ActionResult GravarCompra(Compra compra) {
            try {
                if (ModelState.IsValid) {
                    compraServico.GravarCompra(compra);
                    return RedirectToAction("Index");
                }
                return View(compra);
            } catch {
                return View(compra);
            }
        }


        // GET: Compras/Create
        public ActionResult Create() {
            PopularViewBag();
            return View();
        }

        // POST: Compras/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Compra compra) {
            return GravarCompra(compra);
        }

        // GET: Compras/Edit/5
        public ActionResult Edit(long? id) {
            PopularViewBag(compraServico.ObterCompraPorId((long)id));
            return ObterVisaoCompraPorId(id);
        }

        // POST: Compras/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Compra compra) {
            return GravarCompra(compra);
        }

        // GET: Compras/Details/5
        public ActionResult Details(long? id) {
            return ObterVisaoCompraPorId(id);
        }

        // GET: Compras/Delete/5
        public ActionResult Delete(long? id) {
            return ObterVisaoCompraPorId(id);
        }

        // POST: Compras/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id) {
            try {
                Compra compra = compraServico.EliminarCompraPorId(id);
                TempData["Mensagem"] = "A compra realizada do Cliente " + compra.Cliente.Nome + " de pacote " + compra.Pacote.Nome + " com data de aquisição em " + compra.DataAquisicao + "foi removida";
                return RedirectToAction("Index");
            } catch {
                return View();
            }
        }
    }
}
