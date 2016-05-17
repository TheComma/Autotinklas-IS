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
    public class GedimasController : Controller
    {
        private AutotinklasDBEntities db = new AutotinklasDBEntities();

        // GET: Gedimas
        public ActionResult Index(int? id)
        {
            var gedimas = db.Gedimas.Where(x => x.fk_uzsakymas == id).Include(g => g.Uzsakymas);
            return View(gedimas.ToList());
        }

        // GET: Gedimas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gedimas gedimas = db.Gedimas.Find(id);
            if (gedimas == null)
            {
                return HttpNotFound();
            }
            return View(gedimas);
        }

        // GET: Gedimas/Create
        public ActionResult Create()
        {
            ViewBag.fk_uzsakymas = new SelectList(db.Uzsakymas, "uzsakymo_nr", "uzsakymo_nr");
            return View();
        }

        // POST: Gedimas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,pavadinimas,fk_uzsakymas")] Gedimas gedimas)
        {
            if (ModelState.IsValid)
            {
                db.Gedimas.Add(gedimas);
                db.SaveChanges();
                return RedirectToAction("Index","Gedimas",new { id = gedimas.fk_uzsakymas });
            }

            ViewBag.fk_uzsakymas = new SelectList(db.Uzsakymas, "uzsakymo_nr", "uzsakymo_nr", gedimas.fk_uzsakymas);
            return View(gedimas);
        }

        // GET: Gedimas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gedimas gedimas = db.Gedimas.Find(id);
            if (gedimas == null)
            {
                return HttpNotFound();
            }
            ViewBag.fk_uzsakymas = new SelectList(db.Uzsakymas, "uzsakymo_nr", "uzsakymo_nr", gedimas.fk_uzsakymas);
            return View(gedimas);
        }

        // POST: Gedimas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,pavadinimas,fk_uzsakymas")] Gedimas gedimas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gedimas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Gedimas", new { id = gedimas.fk_uzsakymas });
            }
            ViewBag.fk_uzsakymas = new SelectList(db.Uzsakymas, "uzsakymo_nr", "kliento_vardas", gedimas.fk_uzsakymas);
            return View(gedimas);
        }

        // GET: Gedimas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gedimas gedimas = db.Gedimas.Find(id);
            if (gedimas == null)
            {
                return HttpNotFound();
            }
            return View(gedimas);
        }

        // POST: Gedimas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Gedimas gedimas = db.Gedimas.Find(id);
            db.Gedimas.Remove(gedimas);
            db.SaveChanges();
            return RedirectToAction("Index", "Gedimas", new { id = gedimas.fk_uzsakymas });
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
