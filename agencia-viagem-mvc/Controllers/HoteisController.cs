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
    public class HoteisController : Controller {

        private EFContext context = new EFContext();

        // GET: Hoteis
        public ActionResult Index() {
            return View(context.Hoteis.OrderBy(
                h => h.NomeFantasia));
        }

        public ActionResult Create() {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Hotel hotel) {
            context.Hoteis.Add(hotel);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(long? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hotel hotel = context.Hoteis.Find(id);
            if (hotel == null) {
                return HttpNotFound();
            }
            return View(hotel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Hotel hotel) {
            if (ModelState.IsValid) {
                context.Entry(hotel).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hotel);
        }

        public ActionResult Details(long? id) {
            if(id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hotel hotel = context.Hoteis.Find(id);
            if(hotel == null) {
                return HttpNotFound();
            }
            return View(hotel);
        }

        public ActionResult Delete(long? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hotel hotel = context.Hoteis.Find(id);
            if(hotel == null) {
                return HttpNotFound();
            }
            return View(hotel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id) {
            Hotel hotel = context.Hoteis.Find(id);
            context.Hoteis.Remove(hotel);
            context.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}