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
    public class InformacionProfesionalsController : Controller
    {
        private pureba2registerContext db = new pureba2registerContext();
        InformacionProfesional informacionProfesional = new InformacionProfesional();
        // GET: InformacionProfesionals
        public ActionResult Index()
        {
            var informacionProfesionals = db.InformacionProfesionals.Include(i => i.CarreraProfesional).Include(i => i.InformacionPersonal).Include(i => i.TipoEstudio);
            return View(informacionProfesionals.ToList());
        }

        public ActionResult Ver(string UserName)
        {
            return View(informacionProfesional.Obtener(User.Identity.Name));

        }

        // GET: InformacionProfesionals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InformacionProfesional informacionProfesional = db.InformacionProfesionals.Find(id);
            if (informacionProfesional == null)
            {
                return HttpNotFound();
            }
            return View(informacionProfesional);
        }

        // GET: InformacionProfesionals/Create
        public ActionResult Create()
        {
            ViewBag.CarreraProfesionalID = new SelectList(db.CarreraProfesionals, "CarreraProfesionalID", "NombreCarrera");
            ViewBag.InformacionPersonalID = new SelectList(db.InformacionPersonals, "InformacionPersonalID", "NombresEgresado");
            ViewBag.TipoEstudioID = new SelectList(db.TipoEstudios, "TipoEstudioID", "NombreTipoEstudio");
            return View();
        }

        // POST: InformacionProfesionals/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "InformacionProfesionalID,EstudiaActualmente,FechaTerminacionProfesional,DuracionProfesional,InformacionPersonalID,TipoEstudioID,CarreraProfesionalID,UserName")] InformacionProfesional informacionProfesional)
        {
            if (ModelState.IsValid)
            {
                db.InformacionProfesionals.Add(informacionProfesional);
                db.SaveChanges();
                return RedirectToAction("Ver");
            }

            ViewBag.CarreraProfesionalID = new SelectList(db.CarreraProfesionals, "CarreraProfesionalID", "NombreCarrera", informacionProfesional.CarreraProfesionalID);
            ViewBag.InformacionPersonalID = new SelectList(db.InformacionPersonals, "InformacionPersonalID", "NombresEgresado", informacionProfesional.InformacionPersonalID);
            ViewBag.TipoEstudioID = new SelectList(db.TipoEstudios, "TipoEstudioID", "NombreTipoEstudio", informacionProfesional.TipoEstudioID);
            return View(informacionProfesional);
        }

        // GET: InformacionProfesionals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InformacionProfesional informacionProfesional = db.InformacionProfesionals.Find(id);
            if (informacionProfesional == null)
            {
                return HttpNotFound();
            }
            ViewBag.CarreraProfesionalID = new SelectList(db.CarreraProfesionals, "CarreraProfesionalID", "NombreCarrera", informacionProfesional.CarreraProfesionalID);
            ViewBag.InformacionPersonalID = new SelectList(db.InformacionPersonals, "InformacionPersonalID", "NombresEgresado", informacionProfesional.InformacionPersonalID);
            ViewBag.TipoEstudioID = new SelectList(db.TipoEstudios, "TipoEstudioID", "NombreTipoEstudio", informacionProfesional.TipoEstudioID);
            return View(informacionProfesional);
        }

        // POST: InformacionProfesionals/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "InformacionProfesionalID,EstudiaActualmente,FechaTerminacionProfesional,DuracionProfesional,InformacionPersonalID,TipoEstudioID,CarreraProfesionalID,UserName")] InformacionProfesional informacionProfesional)
        {
            if (ModelState.IsValid)
            {
                db.Entry(informacionProfesional).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CarreraProfesionalID = new SelectList(db.CarreraProfesionals, "CarreraProfesionalID", "NombreCarrera", informacionProfesional.CarreraProfesionalID);
            ViewBag.InformacionPersonalID = new SelectList(db.InformacionPersonals, "InformacionPersonalID", "NombresEgresado", informacionProfesional.InformacionPersonalID);
            ViewBag.TipoEstudioID = new SelectList(db.TipoEstudios, "TipoEstudioID", "NombreTipoEstudio", informacionProfesional.TipoEstudioID);
            return View(informacionProfesional);
        }

        // GET: InformacionProfesionals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InformacionProfesional informacionProfesional = db.InformacionProfesionals.Find(id);
            if (informacionProfesional == null)
            {
                return HttpNotFound();
            }
            return View(informacionProfesional);
        }

        // POST: InformacionProfesionals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            InformacionProfesional informacionProfesional = db.InformacionProfesionals.Find(id);
            db.InformacionProfesionals.Remove(informacionProfesional);
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
        public ActionResult ConsultaEgresadosPorPrograma()
        {
            // var publicacion = db.PublicacionAdmins.ToList(); ;
            List<ModeloGenerico> prueba = db.Database.SqlQuery<ModeloGenerico>("EgresadosPorPrograma").ToList();
            ViewBag.resultado = prueba;
            //ViewBag.resultado = publicacion;
            return View("ConsultaEgresadosPorPrograma");
        }
        public class ModeloGenerico
        {
            public int InformacionProfesionalID { get; set; }
            public string NombresEgresado { get; set; }
            public string PrimerApellidoEgresado { get; set; }
            public String correoEgresado { get; set; }
            public String TelefonoMovilEgresado { get; set; }
            public String NombreCarrera { get; set; }
            public string DescripcionCarrera { get; set; }

        }
        public ActionResult ConsultaEgresadosEstudiando()
        {
            // var publicacion = db.PublicacionAdmins.ToList(); ;
            List<ModeloEgresadosEstudiando> prueba = db.Database.SqlQuery<ModeloEgresadosEstudiando>("EgresadoEstudiaActualmenteSi").ToList();
            ViewBag.resultado = prueba;
            //ViewBag.resultado = publicacion;
            return View("ConsultaEgresadosEstudiando");
        }
        public class ModeloEgresadosEstudiando
        {
            public int InformacionProfesionalID { get; set; }
            public int InformacionPersonalID { get; set; }
            public string NombresEgresado { get; set; }
            public string PrimerApellidoEgresado { get; set; }

            public String TelefonoMovilEgresado { get; set; }


        }
        public ActionResult ConsultaEgresadosPorAno()
        {
            // var publicacion = db.PublicacionAdmins.ToList(); ;
            List<ModeloEgresadosPorAno> prueba = db.Database.SqlQuery<ModeloEgresadosPorAno>("EgresadosPorAño ").ToList();
            ViewBag.resultado = prueba;
            //ViewBag.resultado = publicacion;
            return View("ConsultaEgresadosPorAno");
        }
        public class ModeloEgresadosPorAno
        {
            public int InformacionProfesionalID { get; set; }
            public int InformacionPersonalID { get; set; }
            public string NombresEgresado { get; set; }
            public string PrimerApellidoEgresado { get; set; }
            public DateTime fechaTerminacionProfesional { get; set; }

        }

    }
}
