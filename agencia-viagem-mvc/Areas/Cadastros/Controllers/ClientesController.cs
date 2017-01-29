using Persistencia.Contexts;
using Modelo.Cadastros;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Servico.Cadastros;

namespace agencia_viagem_mvc.Areas.Cadastros.Controllers {
    public class ClientesController : Controller {
        private EFContext context = new EFContext();

        private ClienteServico clienteServico = new ClienteServico();

        public ActionResult Index() {
            var clientes = clienteServico.ObterClientesPorNome();
            return View(clientes);
        }

        public ActionResult Create() {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Cliente cliente) {
            context.Clientes.Add(cliente);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(long? id) {
            return ObterVisaoClientePorId(id);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Cliente cliente) {
            return GravarCliente(cliente);
        }

        public ActionResult Details(long? id) {
            return ObterVisaoClientePorId(id);
        }

        public ActionResult Delete (long? id) {
            return ObterVisaoClientePorId(id);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete (long id) {
            try {
                Cliente cliente = clienteServico.EliminarClientePorId(id);
                TempData["Mensagem"] = "Hotel " + cliente.Nome.ToUpper() + " foi removido";
                return RedirectToAction("Index");
            } catch{
                return View();
            }
        }


        private ActionResult ObterVisaoClientePorId(long? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = clienteServico.ObterClientePorId((long)id);
            if(cliente == null) {
                return HttpNotFound();
            }
            return View(cliente);
        }

        private ActionResult GravarCliente(Cliente cliente) {
            try {
                if (ModelState.IsValid) {
                    clienteServico.GravarCliente(cliente);
                    return RedirectToAction("Index");
                }
                return View(cliente);
            } catch {
                return View(cliente);
            }
        }
    }
}