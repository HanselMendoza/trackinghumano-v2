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
    public class TBMOTIVOENTRADAsController : Controller
    {
        private DBENTRYTRAKYNGEntities db = new DBENTRYTRAKYNGEntities();

        // GET: TBMOTIVOENTRADAs
        public ActionResult Index()
        {
            var tBMOTIVOENTRADAs = db.TBMOTIVOENTRADAs.Include(t => t.TBESTADO);
            return View(tBMOTIVOENTRADAs.ToList());
        }

        // GET: TBMOTIVOENTRADAs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBMOTIVOENTRADA tBMOTIVOENTRADA = db.TBMOTIVOENTRADAs.Find(id);
            if (tBMOTIVOENTRADA == null)
            {
                return HttpNotFound();
            }
            return View(tBMOTIVOENTRADA);
        }

        // GET: TBMOTIVOENTRADAs/Create
        public ActionResult Create()
        {
            ViewBag.IDESTADO = new SelectList(db.TBESTADOes, "IDESTADO", "NOMBRE");
            return View();
        }

        // POST: TBMOTIVOENTRADAs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDMOTIVOENTRADA,IDESTADO,DESCRIPCION")] TBMOTIVOENTRADA tBMOTIVOENTRADA)
        {
            if (ModelState.IsValid)
            {
                db.TBMOTIVOENTRADAs.Add(tBMOTIVOENTRADA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDESTADO = new SelectList(db.TBESTADOes, "IDESTADO", "NOMBRE", tBMOTIVOENTRADA.IDESTADO);
            return View(tBMOTIVOENTRADA);
        }

        // GET: TBMOTIVOENTRADAs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBMOTIVOENTRADA tBMOTIVOENTRADA = db.TBMOTIVOENTRADAs.Find(id);
            if (tBMOTIVOENTRADA == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDESTADO = new SelectList(db.TBESTADOes, "IDESTADO", "NOMBRE", tBMOTIVOENTRADA.IDESTADO);
            return View(tBMOTIVOENTRADA);
        }

        // POST: TBMOTIVOENTRADAs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDMOTIVOENTRADA,IDESTADO,DESCRIPCION")] TBMOTIVOENTRADA tBMOTIVOENTRADA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tBMOTIVOENTRADA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDESTADO = new SelectList(db.TBESTADOes, "IDESTADO", "NOMBRE", tBMOTIVOENTRADA.IDESTADO);
            return View(tBMOTIVOENTRADA);
        }

        // GET: TBMOTIVOENTRADAs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBMOTIVOENTRADA tBMOTIVOENTRADA = db.TBMOTIVOENTRADAs.Find(id);
            if (tBMOTIVOENTRADA == null)
            {
                return HttpNotFound();
            }
            return View(tBMOTIVOENTRADA);
        }

        // POST: TBMOTIVOENTRADAs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TBMOTIVOENTRADA tBMOTIVOENTRADA = db.TBMOTIVOENTRADAs.Find(id);
            db.TBMOTIVOENTRADAs.Remove(tBMOTIVOENTRADA);
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
