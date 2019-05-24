using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using pureba2register.Models;

namespace pureba2register.Controllers
{
    public class ParentescoReferenciasController : Controller
    {
        private pureba2registerContext db = new pureba2registerContext();

        // GET: ParentescoReferencias
        public ActionResult Index()
        {
            return View(db.ParentescoReferencias.ToList());
        }

        // GET: ParentescoReferencias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParentescoReferencia parentescoReferencia = db.ParentescoReferencias.Find(id);
            if (parentescoReferencia == null)
            {
                return HttpNotFound();
            }
            return View(parentescoReferencia);
        }

        // GET: ParentescoReferencias/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ParentescoReferencias/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ParentescoReferenciaID,NombreTipoParentesco")] ParentescoReferencia parentescoReferencia)
        {
            if (ModelState.IsValid)
            {
                db.ParentescoReferencias.Add(parentescoReferencia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(parentescoReferencia);
        }

        // GET: ParentescoReferencias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParentescoReferencia parentescoReferencia = db.ParentescoReferencias.Find(id);
            if (parentescoReferencia == null)
            {
                return HttpNotFound();
            }
            return View(parentescoReferencia);
        }

        // POST: ParentescoReferencias/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ParentescoReferenciaID,NombreTipoParentesco")] ParentescoReferencia parentescoReferencia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(parentescoReferencia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(parentescoReferencia);
        }

        // GET: ParentescoReferencias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParentescoReferencia parentescoReferencia = db.ParentescoReferencias.Find(id);
            if (parentescoReferencia == null)
            {
                return HttpNotFound();
            }
            return View(parentescoReferencia);
        }

        // POST: ParentescoReferencias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ParentescoReferencia parentescoReferencia = db.ParentescoReferencias.Find(id);
            db.ParentescoReferencias.Remove(parentescoReferencia);
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
