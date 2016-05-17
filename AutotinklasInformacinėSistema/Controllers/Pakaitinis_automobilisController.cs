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
    public class Pakaitinis_automobilisController : Controller
    {
        private AutotinklasDBEntities db = new AutotinklasDBEntities();

        // GET: Pakaitinis_automobilis
        public ActionResult Index()
        {
            var pakaitinis_automobilis = db.Pakaitinis_automobilis.Include(p => p.Modelis).Include(p => p.Padalinys).Include(p => p.Modelis.Marke);
            return View(pakaitinis_automobilis.ToList());
        }

        // GET: Pakaitinis_automobilis/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pakaitinis_automobilis pakaitinis_automobilis = db.Pakaitinis_automobilis.Find(id);
            if (pakaitinis_automobilis == null)
            {
                return HttpNotFound();
            }
            return View(pakaitinis_automobilis);
        }

        // GET: Pakaitinis_automobilis/Create
        public ActionResult Create()
        {
            ViewBag.fk_padalinys = new SelectList(db.Padalinys, "id", "adresas");
            return View();
        }

        // POST: Pakaitinis_automobilis/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Pakaitinis_automobilis model)
        {
            if (ModelState.IsValid)
            {
                db.Marke.Add(model.Modelis.Marke);
                db.Modelis.Add(model.Modelis);
                db.Pakaitinis_automobilis.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.fk_padalinys = new SelectList(db.Padalinys, "id", "adresas", model.fk_padalinys);
            return View(model);
        }

        // GET: Pakaitinis_automobilis/Edit/
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pakaitinis_automobilis pakaitinis_automobilis = db.Pakaitinis_automobilis.Find(id);
            if (pakaitinis_automobilis == null)
            {
                return HttpNotFound();
            }
            ViewBag.fk_modelis = new SelectList(db.Modelis, "id", "pavadinimas", pakaitinis_automobilis.fk_modelis);
            ViewBag.fk_marke = db.Modelis.Find(pakaitinis_automobilis.fk_modelis).Marke.pavadinimas;
            ViewBag.fk_padalinys = new SelectList(db.Padalinys, "id", "adresas", pakaitinis_automobilis.fk_padalinys);
            return View(pakaitinis_automobilis);
        }

        // POST: Pakaitinis_automobilis/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include ="valstybinis_numeris,metai,degalu_kiekis,fk_modelis,fk_padalinys,Modelis.Marke.pavadinimas")] Pakaitinis_automobilis model)
        {
            if (ModelState.IsValid)
            {
                
                db.Entry(model).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            ViewBag.fk_modelis = db.Modelis.Find(model.fk_modelis).pavadinimas;
            ViewBag.fk_marke = db.Modelis.Find(model.fk_modelis).Marke.pavadinimas;
            ViewBag.fk_padalinys = new SelectList(db.Padalinys, "id", "adresas", model.fk_padalinys);
            return View(model);
        }

        // GET: Pakaitinis_automobilis/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pakaitinis_automobilis pakaitinis_automobilis = db.Pakaitinis_automobilis.Find(id);
            if (pakaitinis_automobilis == null)
            {
                return HttpNotFound();
            }
            return View(pakaitinis_automobilis);
        }

        // POST: Pakaitinis_automobilis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Pakaitinis_automobilis pakaitinis_automobilis = db.Pakaitinis_automobilis.Find(id);
            db.Pakaitinis_automobilis.Remove(pakaitinis_automobilis);
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
