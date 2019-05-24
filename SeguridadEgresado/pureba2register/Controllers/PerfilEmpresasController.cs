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
    
    public class PerfilEmpresasController : Controller
    {
        private pureba2registerContext db = new pureba2registerContext();
        //instancia para el metodo el objeto obtener en el metodo ver
        private PerfilEmpresa perfilEmpresa = new PerfilEmpresa();
        

        // GET: PerfilEmpresas
        [Authorize(Roles = "Empresa")]
        public ActionResult Index()
        {
            return View(db.PerfilEmpresas.ToList());
        }

        // motodo para poder ver solo lo del usuario
        public ActionResult Ver(string UserName)
        {

            return View(perfilEmpresa.Obtener(User.Identity.Name));
           
        }

        // GET: PerfilEmpresas/Details/5
        [Authorize(Roles = "Empresa")]
        public ActionResult Details(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PerfilEmpresa perfilEmpresa = db.PerfilEmpresas.Find(id);
            if (perfilEmpresa == null)
            {
                return HttpNotFound();
            }
            return View(perfilEmpresa);
        }

        // GET: PerfilEmpresas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PerfilEmpresas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CrearPerfilEmpresaID,NombreEmpresa,Nit,DireccionEmpresa,NumeroEgresado,DescripccionEmpresa,UserName,TipoDocumentoID,Imagen")] PerfilEmpresa perfilEmpresa)
        {
            HttpPostedFileBase fileBase = Request.Files[0];

            if (fileBase.ContentLength ==0)
            {
                ModelState.AddModelError("Imagen","Es nesesario seleccionar una imagen.");
            }
            else
            {
                if (fileBase.FileName.EndsWith(".jpg"))
                {
                    WebImage Imagen = new WebImage(fileBase.InputStream);

                    perfilEmpresa.Imagen = Imagen.GetBytes();
                }
                else
                {
                    ModelState.AddModelError("Imagen","El sistema unicamente acepta imagenes con formato JPG.");
                }
            }
            


            if (ModelState.IsValid)
            {
                db.PerfilEmpresas.Add(perfilEmpresa);
                db.SaveChanges();
                return RedirectToAction("Index","Home");
            }

            return View(perfilEmpresa);
        }

        // GET: PerfilEmpresas/Edit/5
        [Authorize(Roles = "Empresa")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PerfilEmpresa perfilEmpresa = db.PerfilEmpresas.Find(id);
            if (perfilEmpresa == null)
            {
                return HttpNotFound();
            }
            return View(perfilEmpresa);
        }

        // POST: PerfilEmpresas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CrearPerfilEmpresaID,NombreEmpresa,Nit,DireccionEmpresa,NumeroEgresado,DescripccionEmpresa,UserName,Imagen")] PerfilEmpresa perfilEmpresa)
        {
            //byte[] imagenActual = null;
            PerfilEmpresa _imagenAcutal = new PerfilEmpresa();
            HttpPostedFileBase fileBase = Request.Files[0];
            if(fileBase.ContentLength == 0)
            {

                _imagenAcutal = db.PerfilEmpresas.Find(perfilEmpresa.CrearPerfilEmpresaID);
            }
            else
            {
                if (fileBase.FileName.EndsWith(".jpg"))
                {
                    WebImage Imagen = new WebImage(fileBase.InputStream);

                    perfilEmpresa.Imagen = Imagen.GetBytes();
                }
                else
                {
                    ModelState.AddModelError("Imagen", "El sistema unicamente acepta imagenes con formato JPG.");
                }
            }

            if (ModelState.IsValid)
            {
                db.Entry(_imagenAcutal).State = EntityState.Detached;
                db.Entry(perfilEmpresa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Ver");
            }
            return View(perfilEmpresa);
        }

        // GET: PerfilEmpresas/Delete/5
        [Authorize(Roles = "Empresa")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PerfilEmpresa perfilEmpresa = db.PerfilEmpresas.Find(id);
            if (perfilEmpresa == null)
            {
                return HttpNotFound();
            }
            return View(perfilEmpresa);
        }

        // POST: PerfilEmpresas/Delete/5
        [Authorize(Roles = "Empresa")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PerfilEmpresa perfilEmpresa = db.PerfilEmpresas.Find(id);
            db.PerfilEmpresas.Remove(perfilEmpresa);
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

        public ActionResult getImage(int id)
        {
            PerfilEmpresa lkperfilEmpresa = db.PerfilEmpresas.Find(id);
            byte[] byteImagen = lkperfilEmpresa.Imagen;

            MemoryStream memoryStream = new MemoryStream(byteImagen);
            Image imagen = Image.FromStream(memoryStream);


            memoryStream = new MemoryStream();
            //imagen.Save(memoryStream, ImageFormat.Jpeg);
            imagen.Save(memoryStream, ImageFormat.Jpeg);
            memoryStream.Position = 0;

            return File(memoryStream, "imagen/jpg");
        }


    }

}
