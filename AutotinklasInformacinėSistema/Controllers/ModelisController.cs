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
    public class ModelisController : Controller
    {
        private AutotinklasDBEntities db = new AutotinklasDBEntities();

        // GET: Modelis
        public ActionResult Index()
        {
            var modelis = db.Modelis.Include(m => m.Marke);
            return View(modelis.ToList());
        }

        // GET: Modelis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Modelis modelis = db.Modelis.Find(id);
            if (modelis == null)
            {
                return HttpNotFound();
            }
            return View(modelis);
        }

        // GET: Modelis/Create
        public ActionResult Create()
        {
            ViewBag.fk_marke = new SelectList(db.Marke, "id", "pavadinimas");
            return View();
        }

        // POST: Modelis/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,pavadinimas,fk_marke")] Modelis modelis)
        {
            if (ModelState.IsValid)
            {
                db.Modelis.Add(modelis);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.fk_marke = new SelectList(db.Marke, "id", "pavadinimas", modelis.fk_marke);
            return View(modelis);
        }

        // GET: Modelis/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Modelis modelis = db.Modelis.Find(id);
            if (modelis == null)
            {
                return HttpNotFound();
            }
            ViewBag.fk_marke = new SelectList(db.Marke, "id", "pavadinimas", modelis.fk_marke);
            return View(modelis);
        }

        // POST: Modelis/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,pavadinimas,fk_marke")] Modelis modelis)
        {
            if (ModelState.IsValid)
            {
                db.Entry(modelis).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.fk_marke = new SelectList(db.Marke, "id", "pavadinimas", modelis.fk_marke);
            return View(modelis);
        }

        // GET: Modelis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Modelis modelis = db.Modelis.Find(id);
            if (modelis == null)
            {
                return HttpNotFound();
            }
            return View(modelis);
        }

        // POST: Modelis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Modelis modelis = db.Modelis.Find(id);
            db.Modelis.Remove(modelis);
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
