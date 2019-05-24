using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace pureba2register.Models
{
    public class RangoSalarial
    {

        [Key]
        public int RangoSalarialID { get; set; }

        [Display(Name = "Rango salarial")]
        [Required(ErrorMessage = " El campo no puede ir vacío")]
        public String CantidadRangoSalarial { get; set; }

        public virtual ICollection<InformacionLaboral> InformacionLaborals { get; set; }
    }
}