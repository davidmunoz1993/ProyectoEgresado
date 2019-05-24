using pureba2register.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace pureba2register.Controllers
{
    public class HomeController : Controller
    {
        private pureba2registerContext db = new pureba2registerContext();
        public ActionResult Index()
        {
            List<datos> usuarios = db.Database.SqlQuery<datos>("prueba").ToList();
            ViewBag.prueba = usuarios;
            return View();
        }

        public class datos
        {
            public String UserName { get; set; }

        }


        public ActionResult About()
        {
            List<datos> usuarios = db.Database.SqlQuery<datos>("prueba").ToList();
            ViewBag.prueba = usuarios;
            return View();
        }

        public ActionResult Contact()
        {
            List<datos> usuarios = db.Database.SqlQuery<datos>("prueba").ToList();
            ViewBag.prueba = usuarios;
            return View();
        }
    }
}