using agencia_viagem_mvc.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using agencia_viagem_mvc.Models;

namespace agencia_viagem_mvc.Controllers {
    public class VendasController : Controller {
        private EFContext context = new EFContext();
        // GET: Vendas
        public ActionResult Index() {
            var vendas = context.Vendas.Include(c => c.Cliente).Include(p => p.Pacote).OrderByDescending(n => n.DataAquisicao);
            return View(vendas);
        }

        // GET: Vendas/Details/5
        public ActionResult Details(int id) {
            return View();
        }

        // GET: Vendas/Create
        public ActionResult Create() {
            ViewBag.ClienteId = new SelectList(context.Clientes.OrderBy(b => b.Nome), "Id","Nome");
            ViewBag.PacoteId = new SelectList(context.Pacotes.OrderBy(b => b.Nome), "Id","Nome");
            return View();
        }

        // POST: Vendas/Create
        [HttpPost]
        public ActionResult Create(Venda venda) {
            try {
                context.Vendas.Add(venda);
                context.SaveChanges();
                return RedirectToAction("Index");
            } catch {
                return View(venda);
            }
        }

        // GET: Vendas/Edit/5
        public ActionResult Edit(int id) {
            return View();
        }

        // POST: Vendas/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Venda venda) {
            try {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            } catch {
                return View();
            }
        }

        // GET: Vendas/Delete/5
        public ActionResult Delete(int id) {
            return View();
        }

        // POST: Vendas/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Venda venda) {
            try {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            } catch {
                return View();
            }
        }
    }
}
