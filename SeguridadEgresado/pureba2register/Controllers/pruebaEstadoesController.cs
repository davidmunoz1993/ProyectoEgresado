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
    public class pruebaEstadoesController : Controller
    {
        private pureba2registerContext db = new pureba2registerContext();

        // GET: pruebaEstadoes
        public ActionResult Index()
        {
            return View(db.AgregarOfertas.ToList());
        }

        // GET: pruebaEstadoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AgregarOferta agregarOferta = db.AgregarOfertas.Find(id);
            if (agregarOferta == null)
            {
                return HttpNotFound();
            }
            return View(agregarOferta);
        }


        // GET: pruebaEstadoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: pruebaEstadoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "pruebaEstadoID,FechaInicio,FechaFinal,Asunto,PerfilRequerido,Descripcion,UserName,Estado")] pruebaEstado pruebaEstado)
        {
            if (ModelState.IsValid)
            {
                db.pruebaEstadoes.Add(pruebaEstado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pruebaEstado);
        }

        // GET: pruebaEstadoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AgregarOferta agregarOferta = db.AgregarOfertas.Find(id);
            if (agregarOferta == null)
            {
                return HttpNotFound();
            }
            return View(agregarOferta);
        }
        // POST: pruebaEstadoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AgregarOfertaID,FechaInicio,FechaFinal,Asunto,PerfilRequerido,Descripcion,UserName,Estado")] AgregarOferta agregarOferta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(agregarOferta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(agregarOferta);
        }
        // GET: pruebaEstadoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AgregarOferta agregarOferta = db.AgregarOfertas.Find(id);
            if (agregarOferta == null)
            {
                return HttpNotFound();
            }
            return View(agregarOferta);
        }


        // POST: pruebaEstadoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AgregarOferta agregarOferta = db.AgregarOfertas.Find(id);
            db.AgregarOfertas.Remove(agregarOferta);
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

