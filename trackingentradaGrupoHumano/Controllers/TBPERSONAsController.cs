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
    public class TBPERSONAsController : Controller
    {
        private DBENTRYTRAKYNGEntities db = new DBENTRYTRAKYNGEntities();

        // GET: TBPERSONAs
        public ActionResult Index()
        {
            var tBPERSONAs = db.TBPERSONAs.Include(t => t.TBESTADO);
            return View(tBPERSONAs.ToList());
        }

        // GET: TBPERSONAs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBPERSONA tBPERSONA = db.TBPERSONAs.Find(id);
            if (tBPERSONA == null)
            {
                return HttpNotFound();
            }
            return View(tBPERSONA);
        }

        // GET: TBPERSONAs/Create
        public ActionResult Create()
        {
            ViewBag.IDESTADO = new SelectList(db.TBESTADOes, "IDESTADO", "NOMBRE");
            return View();
        }

        // POST: TBPERSONAs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDPERSONA,IDESTADO,CEDULA,NOMBRES,APELLIDOS,FECHANACIMIENTO,LUGARNACIMIENTO,PERSONAGRATA")] TBPERSONA tBPERSONA)
        {
            if (ModelState.IsValid)
            {
                db.TBPERSONAs.Add(tBPERSONA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDESTADO = new SelectList(db.TBESTADOes, "IDESTADO", "NOMBRE", tBPERSONA.IDESTADO);
            return View(tBPERSONA);
        }

        // GET: TBPERSONAs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBPERSONA tBPERSONA = db.TBPERSONAs.Find(id);
            if (tBPERSONA == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDESTADO = new SelectList(db.TBESTADOes, "IDESTADO", "NOMBRE", tBPERSONA.IDESTADO);
            return View(tBPERSONA);
        }

        // POST: TBPERSONAs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDPERSONA,IDESTADO,CEDULA,NOMBRES,APELLIDOS,FECHANACIMIENTO,LUGARNACIMIENTO,PERSONAGRATA")] TBPERSONA tBPERSONA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tBPERSONA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDESTADO = new SelectList(db.TBESTADOes, "IDESTADO", "NOMBRE", tBPERSONA.IDESTADO);
            return View(tBPERSONA);
        }

        // GET: TBPERSONAs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBPERSONA tBPERSONA = db.TBPERSONAs.Find(id);
            if (tBPERSONA == null)
            {
                return HttpNotFound();
            }
            return View(tBPERSONA);
        }

        // POST: TBPERSONAs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TBPERSONA tBPERSONA = db.TBPERSONAs.Find(id);
            db.TBPERSONAs.Remove(tBPERSONA);
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
