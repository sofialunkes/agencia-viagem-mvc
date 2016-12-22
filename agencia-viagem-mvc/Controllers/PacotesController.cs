﻿using agencia_viagem_mvc.Context;
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
            return View(context.Pacotes.OrderBy(
                p=> p.Nome));
        }

        public ActionResult Create() {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Pacote pacote) {
            context.Pacotes.Add(pacote);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(long? id) {
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
        public ActionResult Edit(Pacote pacote) {
            if (ModelState.IsValid) {
                context.Entry(pacote).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pacote);
        }

        public ActionResult Details(long? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pacote pacote = context.Pacotes.Find(id);
            if (pacote == null) {
                return HttpNotFound();
            }
            return View(pacote);
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