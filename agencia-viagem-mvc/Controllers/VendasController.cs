using agencia_viagem_mvc.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using agencia_viagem_mvc.Models;
using System.Net;

namespace agencia_viagem_mvc.Controllers {
    public class VendasController : Controller {
        private EFContext context = new EFContext();
        // GET: Vendas
        public ActionResult Index() {
            var vendas = context.Vendas.Include(c => c.Cliente).Include(p => p.Pacote).OrderByDescending(n => n.DataAquisicao);
            return View(vendas);
        }

        // GET: Vendas/Details/5
        public ActionResult Details(long? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Venda venda = context.Vendas.Where(v => v.Id == id).Include(c => c.Cliente).Include(p => p.Pacote).First();
            if(venda == null) {
                return HttpNotFound();
            }
            return View(venda);
        }

        // GET: Vendas/Create
        public ActionResult Create() {
            ViewBag.ClienteId = new SelectList(context.Clientes.OrderBy(b => b.Nome), "Id", "Nome");
            ViewBag.PacoteId = new SelectList(context.Pacotes.OrderBy(b => b.Nome), "Id", "Nome");
            return View();
        }

        // POST: Vendas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
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
        public ActionResult Edit(long? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Venda venda = context.Vendas.Find(id);
            if (venda == null) {
                return HttpNotFound();
            }
            ViewBag.ClienteId = new SelectList(context.Clientes.OrderBy(b => b.Nome), "Id", "Nome", venda.ClienteId);
            ViewBag.PacoteId = new SelectList(context.Pacotes.OrderBy(b => b.Nome), "Id", "Nome", venda.PacoteId);
            return View(venda);
        }

        // POST: Vendas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Venda venda) {
            try {
                if (ModelState.IsValid) {
                    context.Entry(venda).State = EntityState.Modified;
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(venda);
            } catch {
                return View(venda);
            }
        }

        // GET: Vendas/Delete/5
        public ActionResult Delete(int id) {
            return View();
        }

        // POST: Vendas/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
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
