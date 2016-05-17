using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutotinklasInformacinėSistema;

namespace AutotinklasInformacinėSistema.Controllers
{
    public class SaskaitasController : Controller
    {
        private AutotinklasDBEntities db = new AutotinklasDBEntities();

        // GET: Saskaitas
        public ActionResult Index()
        {
            var saskaita = db.Saskaita.Include(s => s.Uzsakymas);
            return View(saskaita.ToList());
        }

        // GET: Saskaitas/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Saskaita saskaita = db.Saskaita.Find(id);
            if (saskaita == null)
            {
                return HttpNotFound();
            }
            return View(saskaita);
        }

        // GET: Saskaitas/Create
        public ActionResult Create()
        {
            ViewBag.fk_uzsakymas = new SelectList(db.Uzsakymas, "uzsakymo_nr", "kliento_vardas");
            return View();
        }

        // POST: Saskaitas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "saskaitos_numeris,data,suma,fk_uzsakymas")] Saskaita saskaita)
        {
            if (ModelState.IsValid)
            {
                db.Saskaita.Add(saskaita);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.fk_uzsakymas = new SelectList(db.Uzsakymas, "uzsakymo_nr", "kliento_vardas", saskaita.fk_uzsakymas);
            return View(saskaita);
        }

        // GET: Saskaitas/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Saskaita saskaita = db.Saskaita.Find(id);
            if (saskaita == null)
            {
                return HttpNotFound();
            }
            ViewBag.fk_uzsakymas = new SelectList(db.Uzsakymas, "uzsakymo_nr", "kliento_vardas", saskaita.fk_uzsakymas);
            return View(saskaita);
        }

        // POST: Saskaitas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "saskaitos_numeris,data,suma,fk_uzsakymas")] Saskaita saskaita)
        {
            if (ModelState.IsValid)
            {
                db.Entry(saskaita).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.fk_uzsakymas = new SelectList(db.Uzsakymas, "uzsakymo_nr", "kliento_vardas", saskaita.fk_uzsakymas);
            return View(saskaita);
        }

        // GET: Saskaitas/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Saskaita saskaita = db.Saskaita.Find(id);
            if (saskaita == null)
            {
                return HttpNotFound();
            }
            return View(saskaita);
        }

        // POST: Saskaitas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Saskaita saskaita = db.Saskaita.Find(id);
            db.Saskaita.Remove(saskaita);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
