using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace pureba2register.Models
{
    public class Departamento
    {
        [Key]
        public int DepartamentoID { get; set; }

        [Display(Name = "Nombre departamento")]
        [Required(ErrorMessage = " El campo no puede ir vacío")]
        public String NombreDepartamento { get; set; }

        public virtual ICollection<Municipio> Municipios { get; set; }

    }
}