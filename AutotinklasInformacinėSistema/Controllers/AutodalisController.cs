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
    public class AutodalisController : Controller
    {
        private AutotinklasDBEntities db = new AutotinklasDBEntities();

        // GET: Autodalis
        public ActionResult Index()
        {
            var autodalis = db.Autodalis.Include(a => a.Parduotuve);
            return View(autodalis.ToList());
        }

        // GET: Autodalis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Autodalis autodalis = db.Autodalis.Find(id);
            if (autodalis == null)
            {
                return HttpNotFound();
            }
            return View(autodalis);
        }

        // GET: Autodalis/Create
        public ActionResult Create()
        {
            ViewBag.fk_parduotuve = new SelectList(db.Parduotuve, "id", "pavadinimas");
            return View();
        }

        // POST: Autodalis/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,pavadinimas,kaina,gamintojas,fk_parduotuve")] Autodalis autodalis)
        {
            if (ModelState.IsValid)
            {
                db.Autodalis.Add(autodalis);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.fk_parduotuve = new SelectList(db.Parduotuve, "id", "pavadinimas", autodalis.fk_parduotuve);
            return View(autodalis);
        }

        // GET: Autodalis/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Autodalis autodalis = db.Autodalis.Find(id);
            if (autodalis == null)
            {
                return HttpNotFound();
            }
            ViewBag.fk_parduotuve = new SelectList(db.Parduotuve, "id", "pavadinimas", autodalis.fk_parduotuve);
            return View(autodalis);
        }

        // POST: Autodalis/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,pavadinimas,kaina,gamintojas,fk_parduotuve")] Autodalis autodalis)
        {
            if (ModelState.IsValid)
            {
                db.Entry(autodalis).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.fk_parduotuve = new SelectList(db.Parduotuve, "id", "pavadinimas", autodalis.fk_parduotuve);
            return View(autodalis);
        }

        // GET: Autodalis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Autodalis autodalis = db.Autodalis.Find(id);
            if (autodalis == null)
            {
                return HttpNotFound();
            }
            return View(autodalis);
        }

        // POST: Autodalis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Autodalis autodalis = db.Autodalis.Find(id);
            db.Autodalis.Remove(autodalis);
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
