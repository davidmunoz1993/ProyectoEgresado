using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace pureba2register.Models
{
    public class Municipio
    {
        [Key]
        public int MunicipioID { get; set; }

        [Display(Name = " Nombre Municipio")]
        [Required(ErrorMessage = " El campo no puede ir vacío")]
        public String NombreMunicipio { get; set; }

        public int DepartamentoID { get; set; }
        public virtual Departamento Departamento { get; set; }

        public virtual ICollection<InformacionPersonal> InformacionPersonals { get; set; }

    }
}