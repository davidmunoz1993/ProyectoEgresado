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
    public class OfertaLaboralVistaEgresadoesController : Controller
    {
        private pureba2registerContext db = new pureba2registerContext();
        private AgregarOferta agregarOferta = new AgregarOferta();
        private UsuarioXOferta usuarioXOferta = new UsuarioXOferta();


        // GET: OfertaLaboralVistaEgresadoes
        public ActionResult Index()
        {
            //return View(db.AgregarOfertas.ToList());

            List<datos> Ofertas = db.Database.SqlQuery<datos>("MuestraEstado").ToList();
            ViewBag.MuestraEstado = Ofertas;
            return View();
        }

        
        




        [HttpPost]
        public ActionResult Details(UsuarioXOferta usuarioXOferta)
        {

            var name = User.Identity.Name;
            string idUsuario = "";
            var datos = db.Database.SqlQuery<datos>("Select id from AspNetUsers where UserName = '" + name + "'").ToList();

            foreach (var item in datos)
            {
                idUsuario = item.Id;
                break;
            }

            usuarioXOferta.Usuario = idUsuario;
            if (ModelState.IsValid)
            {
                db.UsuarioXOfertas.Add(usuarioXOferta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(usuarioXOferta);
        }


        // GET: AgregarOfertas/Details/5
       // [Authorize(Roles = "Empresa")]
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


        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "AgregarOfertaID,FechaInicio,FechaFinal,Asunto,PerfilRequerido,Descripcion,UserName,Estado")] AgregarOferta agregarOferta)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.AgregarOfertas.Add(agregarOferta);
        //        db.SaveChanges();
        //        return RedirectToAction("Ver");
        //    }

        //    return View(agregarOferta);
        //}

    }

    

    public class datos
    {
        public int AgregarOfertaID { get; set; }
        public string Id { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinal { get; set; }
        public string Asunto { get; set; }
        public string PerfilRequerido { get; set; }
        public string Descripcion { get; set; }
        public string UserName { get; set; }
        public string Estado { get; set; }

    }




}
        

