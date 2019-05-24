﻿using System;
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
    public class PublicacionesEnEsperasController : Controller
    {
        private pureba2registerContext db = new pureba2registerContext();

        // GET: PublicacionesEnEsperas
        public ActionResult Index()
        {
            return View(db.PublicacionesEnEsperas.ToList());
        }

        // GET: PublicacionesEnEsperas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PublicacionesEnEspera publicacionesEnEspera = db.PublicacionesEnEsperas.Find(id);
            if (publicacionesEnEspera == null)
            {
                return HttpNotFound();
            }
            return View(publicacionesEnEspera);
        }

        // GET: PublicacionesEnEsperas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PublicacionesEnEsperas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PublicacionEnEspera,FechaInicio,FechaFinalizacion,Asunto,Informacion,EstadoPublicacion")] PublicacionesEnEspera publicacionesEnEspera)
        {
            if (ModelState.IsValid)
            {
                db.PublicacionesEnEsperas.Add(publicacionesEnEspera);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(publicacionesEnEspera);
        }

        // GET: PublicacionesEnEsperas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PublicacionesEnEspera publicacionesEnEspera = db.PublicacionesEnEsperas.Find(id);
            if (publicacionesEnEspera == null)
            {
                return HttpNotFound();
            }
            return View(publicacionesEnEspera);
        }

        // POST: PublicacionesEnEsperas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PublicacionEnEspera,FechaInicio,FechaFinalizacion,Asunto,Informacion,EstadoPublicacion")] PublicacionesEnEspera publicacionesEnEspera)
        {
            if (ModelState.IsValid)
            {
                db.Entry(publicacionesEnEspera).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(publicacionesEnEspera);
        }

        // GET: PublicacionesEnEsperas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PublicacionesEnEspera publicacionesEnEspera = db.PublicacionesEnEsperas.Find(id);
            if (publicacionesEnEspera == null)
            {
                return HttpNotFound();
            }
            return View(publicacionesEnEspera);
        }

        // POST: PublicacionesEnEsperas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PublicacionesEnEspera publicacionesEnEspera = db.PublicacionesEnEsperas.Find(id);
            db.PublicacionesEnEsperas.Remove(publicacionesEnEspera);
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
