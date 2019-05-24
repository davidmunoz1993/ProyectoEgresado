using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace pureba2register.Models
{
    public class TipoEstudio
    {
        [Key]
        public int TipoEstudioID { get; set; }

        [Display(Name = "Tipo de estudio")]
        [Required(ErrorMessage = " El campo no puede ir vacío")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "La propiedad {0} debe tener {1} caracteres como máximo y {2} como mínimo")]
        public String NombreTipoEstudio { get; set; }

        public virtual ICollection<InformacionProfesional> InformacionProfesionals { get; set; }
    }
}