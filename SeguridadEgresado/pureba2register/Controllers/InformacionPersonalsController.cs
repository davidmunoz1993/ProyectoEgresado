using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using pureba2register.Models;

namespace pureba2register.Controllers
{
    public class InformacionPersonalsController : Controller
    {
        private pureba2registerContext db = new pureba2registerContext();
        InformacionPersonal informacionPersonal = new InformacionPersonal();


        // GET: InformacionPersonals
        public ActionResult Index()
        {
            var informacionPersonals = db.InformacionPersonals.Include(i => i.TipoDocumento);
            return View(informacionPersonal.Obtener(User.Identity.Name).ToList());
        }

        // motodo para poder ver solo lo del usuario
        public ActionResult Ver(string UserName)
        {
            var informacionPersonals = db.InformacionPersonals.Include(i => i.TipoDocumento);
            return View(informacionPersonal.Obtener(User.Identity.Name));

        }

        // GET: InformacionPersonals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InformacionPersonal informacionPersonal = db.InformacionPersonals.Find(id);
            if (informacionPersonal == null)
            {
                return HttpNotFound();
            }
            return View(informacionPersonal);
        }

        // GET: InformacionPersonals/Create
        public ActionResult Create()
        {
            ViewBag.TipoDocumentoID = new SelectList(db.TipoDocumentoes, "TipoDocumentoID", "NombreTipoDocumento");
            ViewBag.DepartamentoID = new SelectList(db.Departamentoes, "DepartamentoID", "NombreDepartamento");
            ViewBag.MunicipioID = new SelectList(db.Municipios.Where(m => m.DepartamentoID == db.Departamentoes.FirstOrDefault().DepartamentoID), "MunicipioID", "NombreMunicipio");
            return View();
        }

        // POST: InformacionPersonals/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "InformacionPersonalID,NombresEgresado,PrimerApellidoEgresado,SegundoApellidoEgresado,FechaNacimientoEgresado,NumeroDocumentoEgresado,FechaExpedicionDocumento,SexoEgresado,correoEgresado,DireccionResidenciaEgresado,TelefonoMovilEgresado,TelefonoFijoEgresado,ExtencionTelefonoEgresado,NumeroActaGrado,FotoEgresado,TipoDocumentoID,DepartamentoID,MunicipioID,UserName,Imagen")] InformacionPersonal informacionPersonal)
        {
            HttpPostedFileBase fileBase = Request.Files[0];

            if (fileBase.ContentLength == 0)
            {
                ModelState.AddModelError("Imagen", "Es nesesario seleccionar una imagen.");
            }
            else
            {
                if (fileBase.FileName.EndsWith(".jpg"))
                {
                    WebImage Imagen = new WebImage(fileBase.InputStream);

                    informacionPersonal.Imagen = Imagen.GetBytes();
                }
                else
                {
                    ModelState.AddModelError("Imagen", "El sistema unicamente acepta imagenes con formato JPG.");
                }
            }



            if (ModelState.IsValid)
            {
                db.InformacionPersonals.Add(informacionPersonal);
                db.SaveChanges();
                return RedirectToAction("Ver");
            }

            ViewBag.TipoDocumentoID = new SelectList(db.TipoDocumentoes, "TipoDocumentoID", "NombreTipoDocumento", informacionPersonal.TipoDocumentoID);
            ViewBag.DeapartamentoID = new SelectList(db.Departamentoes, "DepartamentoID", "NombreDepartamento");
            ViewBag.MunicipioID = new SelectList(db.Municipios.Where(m => m.DepartamentoID == db.Departamentoes.FirstOrDefault().DepartamentoID), "MunicipioID", "NombreMunicipio");
            return View(informacionPersonal);
        }

        // GET: InformacionPersonals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InformacionPersonal informacionPersonal = db.InformacionPersonals.Find(id);
            if (informacionPersonal == null)
            {
                return HttpNotFound();
            }
           
        ViewBag.TipoDocumentoID = new SelectList(db.TipoDocumentoes, "TipoDocumentoID", "NombreTipoDocumento", informacionPersonal.TipoDocumentoID);
            ViewBag.DepartamentoID = new SelectList(db.Departamentoes, "DepartamentoID", "NombreDepartamento");
            ViewBag.MunicipioID = new SelectList(db.Municipios.Where(m => m.DepartamentoID == db.Departamentoes.FirstOrDefault().DepartamentoID), "MunicipioID", "NombreMunicipio");
            return View(informacionPersonal);
        }

        // POST: InformacionPersonals/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "InformacionPersonalID,NombresEgresado,PrimerApellidoEgresado,SegundoApellidoEgresado,FechaNacimientoEgresado,NumeroDocumentoEgresado,FechaExpedicionDocumento,SexoEgresado,correoEgresado,DireccionResidenciaEgresado,TelefonoMovilEgresado,TelefonoFijoEgresado,ExtencionTelefonoEgresado,NumeroActaGrado,FotoEgresado,UserName,Imagen,MunicipioID,TipoDocumentoID,DepartamentoID")] InformacionPersonal informacionPersonal)
        {
            InformacionPersonal _imagenAcutal = new InformacionPersonal();
            HttpPostedFileBase fileBase = Request.Files[0];
            if (fileBase.ContentLength == 0)
            {

                _imagenAcutal = db.InformacionPersonals.Find(informacionPersonal.InformacionPersonalID);
            }
            else
            {
                if (fileBase.FileName.EndsWith(".jpg"))
                {
                    WebImage Imagen = new WebImage(fileBase.InputStream);

                    informacionPersonal.Imagen = Imagen.GetBytes();
                }
                else
                {
                    ModelState.AddModelError("Imagen", "El sistema unicamente acepta imagenes con formato JPG.");
                }
            }

            if (ModelState.IsValid)
            {
                db.Entry(_imagenAcutal).State = EntityState.Detached;
                db.Entry(informacionPersonal).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Ver");
            }
            ViewBag.TipoDocumentoID = new SelectList(db.TipoDocumentoes, "TipoDocumentoID", "NombreTipoDocumento", informacionPersonal.TipoDocumentoID);
            ViewBag.DepartamentoID = new SelectList(db.Departamentoes, "DepartamentoID", "NombreDepartamento");
            ViewBag.MunicipioID = new SelectList(db.Municipios.Where(m => m.DepartamentoID == db.Departamentoes.FirstOrDefault().DepartamentoID), "MunicipioID", "NombreMunicipio");
            return View(informacionPersonal);
        }

        // GET: InformacionPersonals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InformacionPersonal informacionPersonal = db.InformacionPersonals.Find(id);
            if (informacionPersonal == null)
            {
                return HttpNotFound();
            }
            return View(informacionPersonal);
        }

        // POST: InformacionPersonals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            InformacionPersonal informacionPersonal = db.InformacionPersonals.Find(id);
            db.InformacionPersonals.Remove(informacionPersonal);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public JsonResult GetCities(int departmentId)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var cuidad = db.Municipios.Where(c => c.DepartamentoID == departmentId);
            return Json(cuidad);
        }




        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult getImage(int id)
        {
            InformacionPersonal lkinformacionPersonal = db.InformacionPersonals.Find(id); /*db.InformacionPersonal.Find(id);*/
            byte[] byteImagen = lkinformacionPersonal.Imagen;

            MemoryStream memoryStream = new MemoryStream(byteImagen);
            Image imagen = Image.FromStream(memoryStream);


            memoryStream = new MemoryStream();
            //imagen.Save(memoryStream, ImageFormat.Jpeg);
            imagen.Save(memoryStream, ImageFormat.Jpeg);
            memoryStream.Position = 0;

            return File(memoryStream, "imagen/jpg");
        }

        public ActionResult ConsultaEgresadosMujeres()
        {
            // var publicacion = db.PublicacionAdmins.ToList(); ;
            List<InformacionPersonal> prueba = db.Database.SqlQuery<InformacionPersonal>("select * from InformacionPersonals where SexoEgresado = 'Mujer' ").ToList();
            ViewBag.resultado1 = prueba;
            //ViewBag.resultado = publicacion;
            return View("ConsultaEgresadosMujeres");
        }

        public ActionResult ConsultaEgresadosHombres()
        {
            // var publicacion = db.PublicacionAdmins.ToList(); ;
            List<InformacionPersonal> prueba1 = db.Database.SqlQuery<InformacionPersonal>("select * from InformacionPersonals where SexoEgresado = 'Hombre' ").ToList();
            ViewBag.resultado = prueba1;
            //ViewBag.resultado = publicacion;
            return View("ConsultaEgresadosHombres");
        }
    }
}
