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
    public class DarbuotojasController : Controller
    {
        private AutotinklasDBEntities db = new AutotinklasDBEntities();

        // GET: Darbuotojas
        public ActionResult Index()
        {
            var darbuotojas = db.Darbuotojas.Include(d => d.Padalinys);
            return View(darbuotojas.ToList());
        }

        // GET: Darbuotojas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Darbuotojas darbuotojas = db.Darbuotojas.Find(id);
            if (darbuotojas == null)
            {
                return HttpNotFound();
            }
            return View(darbuotojas);
        }

        // GET: Darbuotojas/Create
        public ActionResult Create()
        {
            ViewBag.fk_Padalinys = new SelectList(db.Padalinys, "id", "adresas");
            return View();
        }

        // POST: Darbuotojas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,pavarde,vardas,adresas,telefonas,fk_Padalinys")] Darbuotojas darbuotojas)
        {
            if (ModelState.IsValid)
            {
                db.Darbuotojas.Add(darbuotojas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.fk_Padalinys = new SelectList(db.Padalinys, "id", "adresas", darbuotojas.fk_Padalinys);
            return View(darbuotojas);
        }

        // GET: Darbuotojas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Darbuotojas darbuotojas = db.Darbuotojas.Find(id);
            if (darbuotojas == null)
            {
                return HttpNotFound();
            }
            ViewBag.fk_Padalinys = new SelectList(db.Padalinys, "id", "adresas", darbuotojas.fk_Padalinys);
            return View(darbuotojas);
        }

        // POST: Darbuotojas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,pavarde,vardas,adresas,telefonas,fk_Padalinys")] Darbuotojas darbuotojas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(darbuotojas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.fk_Padalinys = new SelectList(db.Padalinys, "id", "adresas", darbuotojas.fk_Padalinys);
            return View(darbuotojas);
        }

        // GET: Darbuotojas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Darbuotojas darbuotojas = db.Darbuotojas.Find(id);
            if (darbuotojas == null)
            {
                return HttpNotFound();
            }
            return View(darbuotojas);
        }

        // POST: Darbuotojas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Darbuotojas darbuotojas = db.Darbuotojas.Find(id);
            db.Darbuotojas.Remove(darbuotojas);
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
