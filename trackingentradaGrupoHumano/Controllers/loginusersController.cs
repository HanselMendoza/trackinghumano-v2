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
    public class loginusersController : Controller
    {
        private DBENTRYTRAKYNGEntities db = new DBENTRYTRAKYNGEntities();

        // GET: loginusers
        public ActionResult Index()
        {
            return View(db.loginusers.ToList());
        }

        // GET: loginusers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            loginuser loginuser = db.loginusers.Find(id);
            if (loginuser == null)
            {
                return HttpNotFound();
            }
            return View(loginuser);
        }

        // GET: loginusers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: loginusers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,codigoempleado,nombre,apellido,email,contrasena")] loginuser loginuser)
        {
            if (ModelState.IsValid)
            {
                db.loginusers.Add(loginuser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(loginuser);
        }

        // GET: loginusers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            loginuser loginuser = db.loginusers.Find(id);
            if (loginuser == null)
            {
                return HttpNotFound();
            }
            return View(loginuser);
        }

        // POST: loginusers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,codigoempleado,nombre,apellido,email,contrasena")] loginuser loginuser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loginuser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(loginuser);
        }

        // GET: loginusers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            loginuser loginuser = db.loginusers.Find(id);
            if (loginuser == null)
            {
                return HttpNotFound();
            }
            return View(loginuser);
        }

        // POST: loginusers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            loginuser loginuser = db.loginusers.Find(id);
            db.loginusers.Remove(loginuser);
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
