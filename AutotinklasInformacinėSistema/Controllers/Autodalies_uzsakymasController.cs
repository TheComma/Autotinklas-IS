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
    public class Autodalies_uzsakymasController : Controller
    {
        private AutotinklasDBEntities db = new AutotinklasDBEntities();

        // GET: Autodalies_uzsakymas
        public ActionResult Index(int? id)
        {
            var autodalies_uzsakymas = db.Autodalies_uzsakymas.Where(x => x.fk_uzsakymas == id).Include(a => a.Autodalis).Include(a => a.Uzsakymas);
            return View(autodalies_uzsakymas.ToList());
        }

        // GET: Autodalies_uzsakymas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Autodalies_uzsakymas autodalies_uzsakymas = db.Autodalies_uzsakymas.Find(id);
            if (autodalies_uzsakymas == null)
            {
                return HttpNotFound();
            }
            return View(autodalies_uzsakymas);
        }

        // GET: Autodalies_uzsakymas/Create
        public ActionResult Create()
        {
            ViewBag.fk_autodalis = new SelectList(db.Autodalis, "id", "pavadinimas");
            ViewBag.fk_uzsakymas = new SelectList(db.Uzsakymas, "uzsakymo_nr", "uzsakymo_nr");
            return View();
        }

        // POST: Autodalies_uzsakymas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,kiekis,fk_autodalis,fk_uzsakymas")] Autodalies_uzsakymas autodalies_uzsakymas)
        {
            if (ModelState.IsValid)
            {
                db.Autodalies_uzsakymas.Add(autodalies_uzsakymas);
                db.SaveChanges();
                return RedirectToAction("Index", "Autodalies_uzsakymas", new { id = autodalies_uzsakymas.fk_uzsakymas });
            }

            ViewBag.fk_autodalis = new SelectList(db.Autodalis, "id", "pavadinimas", autodalies_uzsakymas.fk_autodalis);
            ViewBag.fk_uzsakymas = new SelectList(db.Uzsakymas, "uzsakymo_nr", "uzsakymo_nr", autodalies_uzsakymas.fk_uzsakymas);
            return View(autodalies_uzsakymas);
        }

        // GET: Autodalies_uzsakymas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Autodalies_uzsakymas autodalies_uzsakymas = db.Autodalies_uzsakymas.Find(id);
            if (autodalies_uzsakymas == null)
            {
                return HttpNotFound();
            }
            ViewBag.fk_autodalis = new SelectList(db.Autodalis, "id", "pavadinimas", autodalies_uzsakymas.fk_autodalis);
            ViewBag.fk_uzsakymas = new SelectList(db.Uzsakymas, "uzsakymo_nr", "uzsakymo_nr", autodalies_uzsakymas.fk_uzsakymas);
            return View(autodalies_uzsakymas);
        }

        // POST: Autodalies_uzsakymas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,kiekis,fk_autodalis,fk_uzsakymas")] Autodalies_uzsakymas autodalies_uzsakymas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(autodalies_uzsakymas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Autodalies_uzsakymas", new { id = autodalies_uzsakymas.fk_uzsakymas });
            }
            ViewBag.fk_autodalis = new SelectList(db.Autodalis, "id", "pavadinimas", autodalies_uzsakymas.fk_autodalis);
            ViewBag.fk_uzsakymas = new SelectList(db.Uzsakymas, "uzsakymo_nr", "uzsakymo_nr", autodalies_uzsakymas.fk_uzsakymas);
            return View(autodalies_uzsakymas);
        }

        // GET: Autodalies_uzsakymas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Autodalies_uzsakymas autodalies_uzsakymas = db.Autodalies_uzsakymas.Find(id);
            if (autodalies_uzsakymas == null)
            {
                return HttpNotFound();
            }
            return View(autodalies_uzsakymas);
        }

        // POST: Autodalies_uzsakymas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Autodalies_uzsakymas autodalies_uzsakymas = db.Autodalies_uzsakymas.Find(id);
            db.Autodalies_uzsakymas.Remove(autodalies_uzsakymas);
            db.SaveChanges();
            return RedirectToAction("Index", "Autodalies_uzsakymas", new { id = autodalies_uzsakymas.fk_uzsakymas });
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
