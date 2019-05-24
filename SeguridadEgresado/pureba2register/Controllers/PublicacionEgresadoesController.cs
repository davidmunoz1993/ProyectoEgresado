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
    public class PublicacionEgresadoesController : Controller
    {
        private pureba2registerContext db = new pureba2registerContext();

        // GET: PublicacionEgresadoes
        public ActionResult Index()
        {
            var publicacionEgresadoes = db.PublicacionEgresadoes.Include(p => p.InformacionPersonal);
            return View(publicacionEgresadoes.ToList());
        }

        // GET: PublicacionEgresadoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PublicacionEgresado publicacionEgresado = db.PublicacionEgresadoes.Find(id);
            if (publicacionEgresado == null)
            {
                return HttpNotFound();
            }
            return View(publicacionEgresado);
        }

        // GET: PublicacionEgresadoes/Create
        public ActionResult Create()
        {
            ViewBag.InformacionPersonalID = new SelectList(db.InformacionPersonals, "InformacionPersonalID", "NombresEgresado");
            return View();
        }

        // POST: PublicacionEgresadoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PublicacionEgresadoID,FechaInicioPublicacionEgresado,FechaFinalPublicacionEgresado,AsuntoPublicacionEgresado,InformacionPublicacionEgresado,InformacionPersonalID")] PublicacionEgresado publicacionEgresado)
        {
            if (ModelState.IsValid)
            {
                db.PublicacionEgresadoes.Add(publicacionEgresado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.InformacionPersonalID = new SelectList(db.InformacionPersonals, "InformacionPersonalID", "NombresEgresado", publicacionEgresado.InformacionPersonalID);
            return View(publicacionEgresado);
        }

        // GET: PublicacionEgresadoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PublicacionEgresado publicacionEgresado = db.PublicacionEgresadoes.Find(id);
            if (publicacionEgresado == null)
            {
                return HttpNotFound();
            }
            ViewBag.InformacionPersonalID = new SelectList(db.InformacionPersonals, "InformacionPersonalID", "NombresEgresado", publicacionEgresado.InformacionPersonalID);
            return View(publicacionEgresado);
        }

        // POST: PublicacionEgresadoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PublicacionEgresadoID,FechaInicioPublicacionEgresado,FechaFinalPublicacionEgresado,AsuntoPublicacionEgresado,InformacionPublicacionEgresado,InformacionPersonalID")] PublicacionEgresado publicacionEgresado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(publicacionEgresado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.InformacionPersonalID = new SelectList(db.InformacionPersonals, "InformacionPersonalID", "NombresEgresado", publicacionEgresado.InformacionPersonalID);
            return View(publicacionEgresado);
        }

        // GET: PublicacionEgresadoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PublicacionEgresado publicacionEgresado = db.PublicacionEgresadoes.Find(id);
            if (publicacionEgresado == null)
            {
                return HttpNotFound();
            }
            return View(publicacionEgresado);
        }

        // POST: PublicacionEgresadoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PublicacionEgresado publicacionEgresado = db.PublicacionEgresadoes.Find(id);
            db.PublicacionEgresadoes.Remove(publicacionEgresado);
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
