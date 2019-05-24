using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using pureba2register.Models;

namespace pureba2register.Controllers
{
    public class UsuarioXOfertasController : Controller
    {
        private pureba2registerContext db = new pureba2registerContext();
        private UsuarioXOferta usuarioXOferta = new UsuarioXOferta();
        private ReferenciasPersonales referenciasPersonales = new ReferenciasPersonales();
        private InformacionPersonal informacionPersonal = new InformacionPersonal();

        // GET: UsuarioXOfertas
        public ActionResult Index()
        {
            List<datos> MuestraPostulado = db.Database.SqlQuery<datos>("Postulado").ToList();
            ViewBag.Postulado = MuestraPostulado;
            return View();
        }

        //idenx 2 vista referencias personales
        public ActionResult Index2(string id)
        {
            List<datos> MuestraPostulado = db.Database.SqlQuery<datos>("Postulado2 '"+id+"'").ToList();
            ViewBag.Postulado = MuestraPostulado;
            return View();
        }

        //idenx 3 vista informacion laboral
        public ActionResult Index3(string id)
        {
            List<datos> MuestraPostulado = db.Database.SqlQuery<datos>("Postulado2 '" + id + "'").ToList();
            ViewBag.Postulado = MuestraPostulado;
            return View();
        }
        //idenx 4 vista informacion Profesional
        public ActionResult Index4(string id)
        {
            List<datos> MuestraPostulado = db.Database.SqlQuery<datos>("Postulado2 '" + id + "'").ToList();
            ViewBag.Postulado = MuestraPostulado;
            return View();
        }

        //idenx 5 vista informacion Profesional
        public ActionResult Index5(string id)
        {
            List<datos> MuestraPostulado = db.Database.SqlQuery<datos>("Postulado2 '" + id + "'").ToList();
            ViewBag.Postulado = MuestraPostulado;
            return View();
        }


        // GET: UsuarioXOfertas/Details/5


        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReferenciasPersonales referenciasPersonales = db.ReferenciasPersonales.Find(id);
            if (referenciasPersonales == null)
            {
                return HttpNotFound();
            }
            return View(referenciasPersonales);
        }

        


       

       



        // GET: UsuarioXOfertas/Create
        public ActionResult Create(int? id)
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


        // GET: UsuarioXOfertas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsuarioXOferta usuarioXOferta = db.UsuarioXOfertas.Find(id);
            if (usuarioXOferta == null)
            {
                return HttpNotFound();
            }
            return View(usuarioXOferta);
        }

        // POST: UsuarioXOfertas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UsuarioXOfertaID,Usuario,Oferta")] UsuarioXOferta usuarioXOferta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuarioXOferta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(usuarioXOferta);
        }

        // GET: UsuarioXOfertas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsuarioXOferta usuarioXOferta = db.UsuarioXOfertas.Find(id);
            if (usuarioXOferta == null)
            {
                return HttpNotFound();
            }
            return View(usuarioXOferta);
        }

        // POST: UsuarioXOfertas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UsuarioXOferta usuarioXOferta = db.UsuarioXOfertas.Find(id);
            db.UsuarioXOfertas.Remove(usuarioXOferta);
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

        public class datos
        {
            public int UsuarioXOfertaID { get; set; }
            public int AgregarOfertaID { get; set; }
            public string Asunto { get; set; }
            public string UserName { get; set; }
            public string Usuario { get; set; }
            public int Oferta { get; set; }

            //--------------------------------------------------------------------------------

            public string NombresEgresado { get; set; }

            public string PrimerApellidoEgresado { get; set; }

            public string SegundoApellidoEgresado { get; set; }
            public DateTime FechaNacimientoEgresado { get; set; }
            public String NumeroDocumentoEgresado { get; set; }
            public DateTime FechaExpedicionDocumento { get; set; }
                    public string SexoEgresado { get; set; }
            public string correoEgresado { get; set; }
            public string DireccionResidenciaEgresado { get; set; }
            public string TelefonoMovilEgresado { get; set; }
            public string TelefonoFijoEgresado { get; set; }
            public string ExtencionTelefonoEgresado { get; set; }
            public String NumeroActaGrado { get; set; }
            public String FotoEgresado { get; set; }
            public int TipoDocumentoID { get; set; }
            public string NombreTipoDocumento { get; set; }

            //--------------------------------------------------------------------------------
            //referenciass personales
            [Display(Name = "Nombres")]
            [Required(ErrorMessage = " Este campo no puede ir vacío")]
            [StringLength(50, MinimumLength = 3, ErrorMessage = "La propiedad {0} debe tener {1} caracteres como máximo y {2} como mínimo")]
            public String NombresReferencia { get; set; }

            [Display(Name = "Primer apeliido")]
            [Required(ErrorMessage = " Este campo no puede ir vacío")]
            [StringLength(50, MinimumLength = 3, ErrorMessage = "La propiedad {0} debe tener {1} caracteres como máximo y {2} como mínimo")]
            public String PrimerApellidoReferencia { get; set; }

            [Display(Name = "Segundo apellido")]
            [Required(ErrorMessage = " Este campo no puede ir vacío")]
            [StringLength(50, MinimumLength = 3, ErrorMessage = "La propiedad {0} debe tener {1} caracteres como máximo y {2} como mínimo")]
            public String SegundoApellidoReferencia { get; set; }

            [Display(Name = "Cargo que ocupa")]
            [Required(ErrorMessage = " Este campo no puede ir vacío")]
            [StringLength(50, MinimumLength = 4, ErrorMessage = "La propiedad {0} debe tener {1} caracteres como máximo y {2} como mínimo")]
            public String CargoReferencia { get; set; }

            [Display(Name = "Teléfono fijo ")]
            [Required(ErrorMessage = " El campo no puede ir vacío")]
            [RegularExpression("^[0-9]*$", ErrorMessage = "* Solo se permiten números.")]
            [DataType(DataType.PhoneNumber)]
            public string TelefonoFijoReferencia { get; set; }

            [Display(Name = "Extención")]
            public String ExtTelefonoReferencia { get; set; }


            [Display(Name = "Teléfono móvil ")]
            [Required(ErrorMessage = " El campo no puede ir vacío")]
            [RegularExpression("^[0-9]*$", ErrorMessage = "* Solo se permiten números.")]
            [DataType(DataType.PhoneNumber)]
            public string TelefonoMovilReferencia { get; set; }

            [Display(Name = "Usuario")]
            public int InformacionPersonalID { get; set; }
            public virtual InformacionPersonal InformacionPersonal { get; set; }

            [Display(Name = "Tipo de parentesco")]
            public int ParentescoReferenciaID { get; set; }
            public virtual ParentescoReferencia ParentescoReferencia { get; set; }

            [Display(Name = "Tipo de referencia ")]
            public int TipoReferenciaID { get; set; }
            public virtual TipoReferencia TipoReferencia { get; set; }

            //------------------------------------------------------------------------------------------------------
            // informacion laboral

            [Display(Name = "Trabaja actualmente?")]
            [Required(ErrorMessage = " El campo no puede ir vacío")]
            public String TrabajaActualmente { get; set; }

            [Display(Name = "Jefe inmediato - Nombres")]
            [Required(ErrorMessage = " El campo no puede ir vacío")]
            [StringLength(50, MinimumLength = 3, ErrorMessage = "La propiedad {0} debe tener {1} caracteres como máximo y {2} como mínimo")]
            public String NombresJefeLaboral { get; set; }

            [Display(Name = "Jefe inmediato- Apellido")]
            [Required(ErrorMessage = " El campo no puede ir vacío")]
            [StringLength(50, MinimumLength = 3, ErrorMessage = "La propiedad {0} debe tener {1} caracteres como máximo y {2} como mínimo")]
            public String ApellidoJefeLaboral { get; set; }

            [Display(Name = "Jefe inmediato- Teléfono  ")]
            [Required(ErrorMessage = " El campo no puede ir vacío")]
            [RegularExpression("^[0-9]*$", ErrorMessage = "* Solo se permiten números.")]
            [DataType(DataType.PhoneNumber)]
            public string TelefonoJefeLaboral { get; set; }

            [Display(Name = "Nombre de la empresa")]
            [Required(ErrorMessage = " El campo no puede ir vacío")]
            [StringLength(50, MinimumLength = 3, ErrorMessage = "La propiedad {0} debe tener {1} caracteres como máximo y {2} como mínimo")]
            public String NombreEmpresaLaboral { get; set; }

            [Display(Name = "Dirección de la empresa")]
            public String DireccionEmpresaLaboral { get; set; }

            [Display(Name = "Cargo que ocupa en la empresa")]
            [Required(ErrorMessage = " El campo no puede ir vacío")]
            public String CargoOcupacionLaboral { get; set; }

            [Display(Name = "Fecha de ingreso")]
            [DataType(DataType.Date)]
            [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
            public DateTime fechaIngresoLaboral { get; set; }

            

            [Display(Name = "Rango salarial")]
            public int RangoSalarialID { get; set; }
            public virtual RangoSalarial RangoSalarial { get; set; }

            //---------------------------------------------------------------------------------------------------
            //informacion profesional

            [Display(Name = "Estudia actualmente?")]
            [Required(ErrorMessage = " El campo no puede ir vacío")]
            public String EstudiaActualmente { get; set; }

            [Display(Name = "Fecha de terminación")]
            [Required(ErrorMessage = " El campo no puede ir vacío")]
            [DataType(DataType.Date)]
            [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
            public DateTime FechaTerminacionProfesional { get; set; }

            [Display(Name = "Duración del estudio")]
            [Required(ErrorMessage = " El campo no puede ir vacío")]
            public String DuracionProfesional { get; set; }


            

            [Display(Name = "Tipo de estudio")]
            public int TipoEstudioID { get; set; }
            public virtual TipoEstudio TipoEstudio { get; set; }

            [Display(Name = "Nombre carrera profesional")]
            public int CarreraProfesionalID { get; set; }
            public string  CarreraProfesional { get; set; }

            public string NombreCarrera { get; set; }












            

        }
    }
}
