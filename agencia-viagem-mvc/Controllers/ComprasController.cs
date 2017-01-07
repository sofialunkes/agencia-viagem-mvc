using Modelo.Cadastros;
using Persistencia.Contexts;
using System.Linq;
using System.Web.Mvc;
using System.Net;
using System.Data.Entity;

namespace agencia_viagem_mvc.Controllers {
    public class ComprasController : Controller {
        private EFContext context = new EFContext();

        // GET: Compras
        public ActionResult Index() {
            var compras = context.Compras.Include(c => c.Cliente).Include(p => p.Pacote).OrderByDescending(co => co.DataAquisicao);
            return View(compras);
        }

        // GET: Compras/Details/5
        public ActionResult Details(long? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Compra compra = context.Compras.Where(c => c.CompraId == id).Include("Cliente").Include("Pacote").First();
            if (compra == null) {
                return HttpNotFound();
            }
            return View(compra);
        }

        // GET: Compras/Create
        public ActionResult Create() {
            ViewBag.PacoteId = new SelectList(context.Pacotes.OrderBy(p =>p.Nome),"PacoteId","Nome");
            ViewBag.ClienteId = new SelectList(context.Clientes.OrderBy(c => c.Nome), "ClienteId", "Nome");
            return View();
        }

        // POST: Compras/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Compra compra) {
            try {
                context.Compras.Add(compra);
                context.SaveChanges();
                return RedirectToAction("Index");
            } catch {
                return View(compra);
            }
        }

        // GET: Compras/Edit/5
        public ActionResult Edit(long? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Compra compra = context.Compras.Where(c =>c.CompraId == id).Include("Pacote").Include("Cliente").First();
            if (compra == null) {
                return HttpNotFound();
            }
            ViewBag.ClienteId = new SelectList(context.Clientes.OrderBy(c =>c.Nome), "ClienteId","Nome", compra.ClienteId);
            ViewBag.PacoteId = new SelectList(context.Pacotes.OrderBy(p => p.Nome), "PacoteId", "Nome", compra.PacoteId);
            return View(compra);
        }

        // POST: Compras/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Compra compra) {
            try {
                if (ModelState.IsValid) {
                    context.Entry(compra).State = EntityState.Modified;
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(compra);
            } catch {
                return View(compra);
            }
        }

        // GET: Compras/Delete/5
        public ActionResult Delete(long? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Compra compra = context.Compras.Where(c => c.CompraId == id).Include(p =>p.Pacote).Include(cl => cl.Cliente).First();
            if (compra == null) {
                return HttpNotFound();
            }
            return View(compra);
        }

        // POST: Compras/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id) {
            try {
                Compra compra = context.Compras.Find(id);
                context.Compras.Remove(compra);
                context.SaveChanges();
                TempData["Mensagem"] = "A compra realizada do Cliente " + compra.Cliente.Nome + " de pacote " + compra.Pacote.Nome + " com data de aquisição em " + compra.DataAquisicao + "foi removida";
                return RedirectToAction("Index");
            } catch {
                return View();
            }
        }
    }
}
