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
    public class ParduotuvesController : Controller
    {
        private AutotinklasDBEntities db = new AutotinklasDBEntities();

        // GET: Parduotuves
        public ActionResult Index()
        {
            return View(db.Parduotuve.ToList());
        }

        // GET: Parduotuves/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Parduotuve parduotuve = db.Parduotuve.Find(id);
            if (parduotuve == null)
            {
                return HttpNotFound();
            }
            return View(parduotuve);
        }

        // GET: Parduotuves/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Parduotuves/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,pavadinimas,miestas,adresas")] Parduotuve parduotuve)
        {
            if (ModelState.IsValid)
            {
                db.Parduotuve.Add(parduotuve);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(parduotuve);
        }

        // GET: Parduotuves/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Parduotuve parduotuve = db.Parduotuve.Find(id);
            if (parduotuve == null)
            {
                return HttpNotFound();
            }
            return View(parduotuve);
        }

        // POST: Parduotuves/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,pavadinimas,miestas,adresas")] Parduotuve parduotuve)
        {
            if (ModelState.IsValid)
            {
                db.Entry(parduotuve).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(parduotuve);
        }

        // GET: Parduotuves/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Parduotuve parduotuve = db.Parduotuve.Find(id);
            if (parduotuve == null)
            {
                return HttpNotFound();
            }
            return View(parduotuve);
        }

        // POST: Parduotuves/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Parduotuve parduotuve = db.Parduotuve.Find(id);
            db.Parduotuve.Remove(parduotuve);
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
