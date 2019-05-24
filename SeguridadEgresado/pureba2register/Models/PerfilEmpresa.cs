using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace pureba2register.Models
{
    public class PerfilEmpresa
    {

        [Key]
        public int CrearPerfilEmpresaID { get; set; }
        [Display(Name = "Nombre Empresa")]
        public string NombreEmpresa { get; set; }
        [Display(Name = "Correo")]
        public char Correo { get; set; }
        [Display(Name = "Nit de la empresa")]
        public int Nit { get; set; }
        [Display(Name = "Dirección empresa")]
        public string DireccionEmpresa { get; set; }
        [Display(Name = "Número de egresados")]
        public int NumeroEgresado { get; set; }

        [Display(Name = "Descripción empresa")]
        [DataType(DataType.MultilineText)]
        public string DescripccionEmpresa { get; set; }

        [Display(Name = "Nombre de usuario")]
        public string UserName { get; set; }

        [Display(Name = "Imagen ")]
        public  byte[] Imagen { get; set; }


        public List<PerfilEmpresa> Obtener(string userName)
        {
            var perfilEmpresa = new List<PerfilEmpresa>();
            try
            {
                using (var context = new pureba2registerContext())
                {
                    perfilEmpresa = context.PerfilEmpresas
                    .Where(x => x.UserName == userName)
                    .ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);

            }

            return perfilEmpresa;


        }
    }
}


