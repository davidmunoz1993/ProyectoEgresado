﻿using System.Web;
using System.Web.Optimization;

namespace pureba2register
{
    public class BundleConfig
    {
        // Para obtener más información sobre las uniones, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/jquery.dataTables.min").Include(
          "~/Scripts/jquery.dataTables.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/datatables").Include(
          "~/Scripts/datatables.js"));
            bundles.Add(new ScriptBundle("~/bundles/boostrap.min").Include(
          "~/Scripts/bootstrap.min.js"));

            bundles.Add(new StyleBundle("~/Content/jquery.dataTables.min").Include(
                                "~/Content/jquery.dataTables.min.css"));



            // Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información. De este modo, estará
            // para la producción, use la herramienta de compilación disponible en https://modernizr.com para seleccionar solo las pruebas que necesite.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/Departamentos").Include(
                     "~/Scripts/Departamentos.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
        }
    }
}