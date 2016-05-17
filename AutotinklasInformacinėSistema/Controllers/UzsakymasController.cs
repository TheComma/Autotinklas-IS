using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutotinklasInformacinėSistema;
using AutotinklasInformacinėSistema.Models;

namespace AutotinklasInformacinėSistema.Controllers
{
    public class UzsakymasController : Controller
    {
        private AutotinklasDBEntities db = new AutotinklasDBEntities();

        // GET: Uzsakymas
        public ActionResult Index()
        {
            var uzsakymas = db.Uzsakymas.Include(u => u.Automobilis).Include(u => u.Darbuotojas).Include(u => u.Pakaitinis_automobilis);
            return View(uzsakymas.ToList());
        }

        // GET: Uzsakymas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Uzsakymas uzsakymas = db.Uzsakymas.Find(id);
            if (uzsakymas == null)
            {
                return HttpNotFound();
            }
            return View(uzsakymas);
        }

        // GET: Uzsakymas/Create
        public ActionResult Create()
        {
            ViewBag.fk_meistras = new SelectList(db.Darbuotojas, "id", "pavarde");
            ViewBag.fk_pakaitinis_automobilis = new SelectList(db.Pakaitinis_automobilis, "valstybinis_numeris", "metai");
            return View();
        }

        // POST: Uzsakymas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Uzsakymas model)
        {
            if (ModelState.IsValid)
            {
                db.Marke.Add(model.Automobilis.Modelis.Marke);
                db.Modelis.Add(model.Automobilis.Modelis);
                db.Automobilis.Add(model.Automobilis);
                db.Uzsakymas.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.fk_meistras = new SelectList(db.Darbuotojas, "id", "pavarde", model.fk_meistras);
            ViewBag.fk_pakaitinis_automobilis = new SelectList(db.Pakaitinis_automobilis, "valstybinis_numeris", "valstybinis_numeris", model.fk_pakaitinis_automobilis);
            return View(model);
        }

        // GET: Uzsakymas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Uzsakymas u = db.Uzsakymas.Where(x => x.uzsakymo_nr == id).FirstOrDefault();
            if (u == null)
            {
                return HttpNotFound();
            }

            ViewBag.fk_meistras = new SelectList(db.Darbuotojas, "id", "pavarde", u.fk_meistras);
            ViewBag.fk_pakaitinis_automobilis = new SelectList(db.Pakaitinis_automobilis, "valstybinis_numeris", "valstybinis_numeris", u.fk_pakaitinis_automobilis);
            return View(u);
        }

        // POST: Uzsakymas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Edit(Uzsakymas uzsakymas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(uzsakymas).State = EntityState.Modified;
                Automobilis a = db.Automobilis.Where(x => x.valstybinis_numeris == uzsakymas.Automobilis.valstybinis_numeris).FirstOrDefault();
                a.valstybinis_numeris = uzsakymas.Automobilis.valstybinis_numeris;
                a.metai = uzsakymas.Automobilis.metai;
                a.kebulo_numeris = uzsakymas.Automobilis.kebulo_numeris;
                a.kebulo_tipas = uzsakymas.Automobilis.kebulo_tipas;
                a.fk_modelis = uzsakymas.Automobilis.fk_modelis;
                db.Entry(a).State = EntityState.Modified;
                Modelis m = db.Modelis.Where(x => x.id == uzsakymas.Automobilis.Modelis.id).FirstOrDefault();
                m.id = uzsakymas.Automobilis.Modelis.id;
                m.pavadinimas = uzsakymas.Automobilis.Modelis.pavadinimas;
                m.fk_marke = uzsakymas.Automobilis.Modelis.fk_marke;
                db.Entry(m).State = EntityState.Modified;
                Marke mar = db.Marke.Where(x => x.id == uzsakymas.Automobilis.Modelis.Marke.id).FirstOrDefault();
                mar.id = uzsakymas.Automobilis.Modelis.Marke.id;
                mar.pavadinimas = uzsakymas.Automobilis.Modelis.Marke.pavadinimas;
                db.Entry(mar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.fk_meistras = new SelectList(db.Darbuotojas, "id", "pavarde", uzsakymas.fk_meistras);
            ViewBag.fk_pakaitinis_automobilis = new SelectList(db.Pakaitinis_automobilis, "valstybinis_numeris", "valstybinis_numeris", uzsakymas.fk_pakaitinis_automobilis);
            return View(uzsakymas);
        }

        // GET: Uzsakymas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Uzsakymas uzsakymas = db.Uzsakymas.Find(id);
            if (uzsakymas == null)
            {
                return HttpNotFound();
            }
            return View(uzsakymas);
        }

        // POST: Uzsakymas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Uzsakymas uzsakymas = db.Uzsakymas.Find(id);
            Automobilis auto = db.Automobilis.Find(uzsakymas.fk_automobilis);
            Modelis modelis = db.Modelis.Find(auto.fk_modelis);
            Marke marke = db.Marke.Find(modelis.fk_marke);
            db.Marke.Remove(marke);
            db.Modelis.Remove(modelis);
            db.Automobilis.Remove(auto);
            db.Uzsakymas.Remove(uzsakymas);
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
