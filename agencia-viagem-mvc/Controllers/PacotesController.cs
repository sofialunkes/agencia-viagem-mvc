using agencia_viagem_mvc.Context;
using agencia_viagem_mvc.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace agencia_viagem_mvc.Controllers {
    public class PacotesController : Controller {
        private EFContext context = new EFContext();
        // GET: Pacotes
        public ActionResult Index() {
            var pacotes = context.Pacotes.Include(p => p.Hotel).OrderBy(p => p.Id);
            return View(pacotes);
        }


        public ActionResult Details(long? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pacote pacote = context.Pacotes.Where(p => p.Id == id).Include("Vendas.Cliente").First();
            if (pacote == null) {
                return HttpNotFound();
            }
            return View(pacote);
        }

        public ActionResult Create() {
            ViewBag.HotelId = new SelectList(context.Hoteis.OrderBy(h => h.Id), "Id", "NomeFantasia");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Pacote pacote) {
            try {
                context.Pacotes.Add(pacote);
                context.SaveChanges();
                return RedirectToAction("Index");
            } catch {
                return View(pacote);
            }
        }


        public ActionResult Edit(long? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pacote pacote = context.Pacotes.Find(id);
            if (pacote == null) {
                return HttpNotFound();
            }
            ViewBag.HotelId = new SelectList(context.Hoteis.OrderBy(b => b.NomeFantasia), "Id", "NomeFantasia", pacote.HotelId);
            return View(pacote);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Pacote pacote) {
            try {
                if (ModelState.IsValid) {
                    context.Entry(pacote).State = EntityState.Modified;
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(pacote);
            } catch {
                return View(pacote);
            }

        }

        public ActionResult Delete(long? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pacote pacote = context.Pacotes.Find(id);
            if (pacote == null) {
                return HttpNotFound();
            }
            return View(pacote);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id) {
            Pacote pacote = context.Pacotes.Find(id);
            context.Pacotes.Remove(pacote);
            context.SaveChanges();
            TempData["Mensagem"] = "Pacote " + pacote.Nome.ToUpper() + " foi removido";
            return RedirectToAction("Index");
        }
    }
}