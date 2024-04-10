using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using trackingentradaGrupoHumano.Models;

namespace trackingentradaGrupoHumano.Controllers
{
    public class tblocalidadsController : Controller
    {
        private DBENTRYTRAKYNGEntities db = new DBENTRYTRAKYNGEntities();

        // GET: tblocalidads
        public ActionResult Index()
        {
            return View(db.tblocalidads.ToList());
        }

        // GET: tblocalidads/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblocalidad tblocalidad = db.tblocalidads.Find(id);
            if (tblocalidad == null)
            {
                return HttpNotFound();
            }
            return View(tblocalidad);
        }

        // GET: tblocalidads/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tblocalidads/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,descripcion")] tblocalidad tblocalidad)
        {
            if (ModelState.IsValid)
            {
                db.tblocalidads.Add(tblocalidad);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblocalidad);
        }

        // GET: tblocalidads/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblocalidad tblocalidad = db.tblocalidads.Find(id);
            if (tblocalidad == null)
            {
                return HttpNotFound();
            }
            return View(tblocalidad);
        }

        // POST: tblocalidads/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,descripcion")] tblocalidad tblocalidad)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblocalidad).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblocalidad);
        }

        // GET: tblocalidads/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblocalidad tblocalidad = db.tblocalidads.Find(id);
            if (tblocalidad == null)
            {
                return HttpNotFound();
            }
            return View(tblocalidad);
        }

        // POST: tblocalidads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblocalidad tblocalidad = db.tblocalidads.Find(id);
            db.tblocalidads.Remove(tblocalidad);
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
