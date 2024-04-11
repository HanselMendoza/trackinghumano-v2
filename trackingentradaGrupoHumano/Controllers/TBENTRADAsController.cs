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
    public class TBENTRADAsController : Controller
    {
        private DBENTRYTRAKYNGEntities db = new DBENTRYTRAKYNGEntities();

        // GET: TBENTRADAs
        [Authorize]
        public ActionResult Index()
        {
            var tBENTRADAs = db.TBENTRADAs
       .Include(t => t.CONFIGURACION)
       .Include(t => t.CONFIGURACION1)
       .Include(t => t.CONFIGURACION2)
       .Include(t => t.TBDEPARTAMENTO)
       .Include(t => t.TBMOTIVOENTRADA)
       .Include(t => t.TBOCUPACION)
       .Include(t => t.tblocalidad)
       .Include(t => t.CONFIGURACION3)
       .Include(t => t.TBCOORDENADA)
       .Include(t => t.TBPISO)
       .Include(t => t.estado)
       .OrderByDescending(t => t.FECHAENTRADA);

            return View(tBENTRADAs.ToList());
        }

        // GET: TBENTRADAs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBENTRADA tBENTRADA = db.TBENTRADAs.Find(id);
            if (tBENTRADA == null)
            {
                return HttpNotFound();
            }
            return View(tBENTRADA);
        }

        // GET: TBENTRADAs/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.Entro = new SelectList(db.CONFIGURACIONs, "ID", "DESCRIPCION");
            ViewBag.TENIACITA = new SelectList(db.CONFIGURACIONs, "ID", "DESCRIPCION");
            ViewBag.vpresidencial = new SelectList(db.CONFIGURACIONs, "ID", "DESCRIPCION");
            ViewBag.IDDEPART = new SelectList(db.TBDEPARTAMENTOes, "IDDEPARTM", "NOMBRE");
            ViewBag.IDMOTIVOENTRADA = new SelectList(db.TBMOTIVOENTRADAs, "IDMOTIVOENTRADA", "DESCRIPCION");
            ViewBag.IDOCUPACION = new SelectList(db.TBOCUPACIONs, "IDOCUPACION", "NOMBRE");
            ViewBag.Localidad = new SelectList(db.tblocalidads, "id", "descripcion");
            ViewBag.IDOCUPACION = new SelectList(db.TBOCUPACIONs, "IDOCUPACION", "NOMBRE");
            ViewBag.COORDENADA = new SelectList(db.TBCOORDENADAs, "IDCOORDENADA", "NOMBRE");
            ViewBag.PISO = new SelectList(db.TBPISOes, "IDPISO", "NOMBRE");
            ViewBag.EstadoSolicitud = new SelectList(db.estadoes, "id", "descripcion");
            return View();
        }

        // POST: TBENTRADAs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind(Include = "IDENTRADA,IDDEPART,IDOCUPACION,IDMOTIVOENTRADA,CEDULA,NOMBRES,APELLIDOS,FECHAENTRADA,TiempoESTIMADO,TENIACITA,Entro,Localidad,vpresidencial,PISO,COORDENADA,codigoempleado,NombreAnfitrion,HORAENTRADA,HORASALIDA,EstadoSolicitud,telefono_2")] TBENTRADA tBENTRADA)
        {
            if (ModelState.IsValid)
            {
                db.TBENTRADAs.Add(tBENTRADA);
                db.SaveChanges();
                return RedirectToAction("Index", "TBENTRADAuser");
            }

            ViewBag.Entro = new SelectList(db.CONFIGURACIONs, "ID", "DESCRIPCION", tBENTRADA.Entro);
            ViewBag.TENIACITA = new SelectList(db.CONFIGURACIONs, "ID", "DESCRIPCION", tBENTRADA.TENIACITA);
            ViewBag.vpresidencial = new SelectList(db.CONFIGURACIONs, "ID", "DESCRIPCION", tBENTRADA.vpresidencial);
            ViewBag.IDDEPART = new SelectList(db.TBDEPARTAMENTOes, "IDDEPARTM", "NOMBRE", tBENTRADA.IDDEPART);
            ViewBag.IDMOTIVOENTRADA = new SelectList(db.TBMOTIVOENTRADAs, "IDMOTIVOENTRADA", "DESCRIPCION", tBENTRADA.IDMOTIVOENTRADA);
            ViewBag.IDOCUPACION = new SelectList(db.TBOCUPACIONs, "IDOCUPACION", "NOMBRE", tBENTRADA.IDOCUPACION);
            ViewBag.Localidad = new SelectList(db.tblocalidads, "id", "descripcion", tBENTRADA.Localidad);
            ViewBag.IDOCUPACION = new SelectList(db.TBOCUPACIONs, "IDOCUPACION", "NOMBRE", tBENTRADA.IDOCUPACION);
            ViewBag.COORDENADA = new SelectList(db.TBCOORDENADAs, "IDCOORDENADA", "NOMBRE", tBENTRADA.COORDENADA);
            ViewBag.PISO = new SelectList(db.TBPISOes, "IDPISO", "NOMBRE", tBENTRADA.PISO);
            ViewBag.EstadoSolicitud = new SelectList(db.estadoes, "id", "descripcion", tBENTRADA.EstadoSolicitud);
            return View(tBENTRADA);
        }

        // GET: TBENTRADAs/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBENTRADA tBENTRADA = db.TBENTRADAs.Find(id);
            if (tBENTRADA == null)
            {
                return HttpNotFound();
            }
            ViewBag.Entro = new SelectList(db.CONFIGURACIONs, "ID", "DESCRIPCION", tBENTRADA.Entro);
            ViewBag.TENIACITA = new SelectList(db.CONFIGURACIONs, "ID", "DESCRIPCION", tBENTRADA.TENIACITA);
            ViewBag.vpresidencial = new SelectList(db.CONFIGURACIONs, "ID", "DESCRIPCION", tBENTRADA.vpresidencial);
            ViewBag.IDDEPART = new SelectList(db.TBDEPARTAMENTOes, "IDDEPARTM", "NOMBRE", tBENTRADA.IDDEPART);
            ViewBag.IDMOTIVOENTRADA = new SelectList(db.TBMOTIVOENTRADAs, "IDMOTIVOENTRADA", "DESCRIPCION", tBENTRADA.IDMOTIVOENTRADA);
            ViewBag.IDOCUPACION = new SelectList(db.TBOCUPACIONs, "IDOCUPACION", "NOMBRE", tBENTRADA.IDOCUPACION);
            ViewBag.Localidad = new SelectList(db.tblocalidads, "id", "descripcion", tBENTRADA.Localidad);
            ViewBag.IDOCUPACION = new SelectList(db.TBOCUPACIONs, "IDOCUPACION", "NOMBRE", tBENTRADA.IDOCUPACION);
            ViewBag.COORDENADA = new SelectList(db.TBCOORDENADAs, "IDCOORDENADA", "NOMBRE", tBENTRADA.COORDENADA);
            ViewBag.PISO = new SelectList(db.TBPISOes, "IDPISO", "NOMBRE", tBENTRADA.PISO);
            ViewBag.EstadoSolicitud = new SelectList(db.estadoes, "id", "descripcion", tBENTRADA.EstadoSolicitud);
            return View(tBENTRADA);
        }

        // POST: TBENTRADAs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit([Bind(Include = "IDENTRADA,IDDEPART,IDOCUPACION,IDMOTIVOENTRADA,CEDULA,NOMBRES,APELLIDOS,FECHAENTRADA,TiempoESTIMADO,TENIACITA,Entro,Localidad,vpresidencial,PISO,COORDENADA,codigoempleado,NombreAnfitrion,HORAENTRADA,HORASALIDA,EstadoSolicitud,telefono_2")] TBENTRADA tBENTRADA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tBENTRADA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Entro = new SelectList(db.CONFIGURACIONs, "ID", "DESCRIPCION", tBENTRADA.Entro);
            ViewBag.TENIACITA = new SelectList(db.CONFIGURACIONs, "ID", "DESCRIPCION", tBENTRADA.TENIACITA);
            ViewBag.vpresidencial = new SelectList(db.CONFIGURACIONs, "ID", "DESCRIPCION", tBENTRADA.vpresidencial);
            ViewBag.IDDEPART = new SelectList(db.TBDEPARTAMENTOes, "IDDEPARTM", "NOMBRE", tBENTRADA.IDDEPART);
            ViewBag.IDMOTIVOENTRADA = new SelectList(db.TBMOTIVOENTRADAs, "IDMOTIVOENTRADA", "DESCRIPCION", tBENTRADA.IDMOTIVOENTRADA);
            ViewBag.IDOCUPACION = new SelectList(db.TBOCUPACIONs, "IDOCUPACION", "NOMBRE", tBENTRADA.IDOCUPACION);
            ViewBag.Localidad = new SelectList(db.tblocalidads, "id", "descripcion", tBENTRADA.Localidad);
            ViewBag.IDOCUPACION = new SelectList(db.CONFIGURACIONs, "ID", "DESCRIPCION", tBENTRADA.IDOCUPACION);
            ViewBag.COORDENADA = new SelectList(db.TBCOORDENADAs, "IDCOORDENADA", "NOMBRE", tBENTRADA.COORDENADA);
            ViewBag.PISO = new SelectList(db.TBPISOes, "IDPISO", "NOMBRE", tBENTRADA.PISO);
            ViewBag.EstadoSolicitud = new SelectList(db.estadoes, "id", "descripcion", tBENTRADA.EstadoSolicitud);
            return View(tBENTRADA);
        }

        // GET: TBENTRADAs/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBENTRADA tBENTRADA = db.TBENTRADAs.Find(id);
            if (tBENTRADA == null)
            {
                return HttpNotFound();
            }
            return View(tBENTRADA);
        }

        // POST: TBENTRADAs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TBENTRADA tBENTRADA = db.TBENTRADAs.Find(id);
            db.TBENTRADAs.Remove(tBENTRADA);
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
