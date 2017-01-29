using Modelo.Tabelas;
using Persistencia.Contexts;
using Servico.Tabelas;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace agencia_viagem_mvc.Areas.Tabelas.Controllers {
    public class PacotesController : Controller {
        private EFContext context = new EFContext();

        private PacoteServico pacoteServico = new PacoteServico();

        // GET: Pacotes
        public ActionResult Index() {
            var pacotes = pacoteServico.ObterPacotesPorNome();
            return View(pacotes);
        }

        private ActionResult ObterVisaoPacotePorId(long? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pacote pacote = pacoteServico.ObterPacotePorId((long)id);
            if (pacote == null) {
                return HttpNotFound();
            }
            return View(pacote);
        }

        private ActionResult GravarPacote(Pacote pacote) {
            try {
                if (ModelState.IsValid) {
                    pacoteServico.GravarPacote(pacote);
                    return RedirectToAction("Index");
                }
                return View(pacote);
            } catch {
                return View(pacote);
            }
        }

        public ActionResult Details(long? id) {
            return ObterVisaoPacotePorId(id);
        }

        public ActionResult Create() {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Pacote pacote) {
            return GravarPacote(pacote);
        }


        public ActionResult Edit(long? id) {
            return ObterVisaoPacotePorId(id);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Pacote pacote) {
            return GravarPacote(pacote);

        }

        public ActionResult Delete(long? id) {
            return ObterVisaoPacotePorId(id);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id) {
            try {
                Pacote pacote = pacoteServico.EliminarPacotePorId(id);
                TempData["Mensagem"] = "Pacote " + pacote.Nome.ToUpper() + " foi removido";
                return RedirectToAction("Index");
            } catch {
                return View();
            }
        }
    }
}