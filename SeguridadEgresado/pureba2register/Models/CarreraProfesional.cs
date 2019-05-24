using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace pureba2register.Models
{
    public class CarreraProfesional
    {
        [Key]
        public int CarreraProfesionalID { get; set; }

        [Display(Name = "Nombre carrera profesional")]
        [Required(ErrorMessage = " El campo no puede ir vacío")]
        [StringLength(60, MinimumLength = 4, ErrorMessage = "La propiedad {0} debe tener {1} caracteres como máximo y {2} como mínimo")]
        public String NombreCarrera { get; set; }

        [Display(Name = "Descripción de la carrera")]
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = " El campo no puede ir vacío")]
        public String DescripcionCarrera { get; set; }

        public virtual ICollection<InformacionProfesional> InformacionProfesionals { get; set; }
    }
}