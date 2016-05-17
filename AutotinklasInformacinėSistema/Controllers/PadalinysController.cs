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
    public class PadalinysController : Controller
    {
        private AutotinklasDBEntities db = new AutotinklasDBEntities();

        // GET: Padalinys
        public ActionResult Index()
        {
            return View(db.Padalinys.ToList());
        }

        // GET: Padalinys/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Padalinys padalinys = db.Padalinys.Find(id);
            if (padalinys == null)
            {
                return HttpNotFound();
            }
            return View(padalinys);
        }

        // GET: Padalinys/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Padalinys/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,adresas,miestas")] Padalinys padalinys)
        {
            if (ModelState.IsValid)
            {
                db.Padalinys.Add(padalinys);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(padalinys);
        }

        // GET: Padalinys/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Padalinys padalinys = db.Padalinys.Find(id);
            if (padalinys == null)
            {
                return HttpNotFound();
            }
            return View(padalinys);
        }

        // POST: Padalinys/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,adresas,miestas")] Padalinys padalinys)
        {
            if (ModelState.IsValid)
            {
                db.Entry(padalinys).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(padalinys);
        }

        // GET: Padalinys/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Padalinys padalinys = db.Padalinys.Find(id);
            if (padalinys == null)
            {
                return HttpNotFound();
            }
            return View(padalinys);
        }

        // POST: Padalinys/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Padalinys padalinys = db.Padalinys.Find(id);
            db.Padalinys.Remove(padalinys);
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
