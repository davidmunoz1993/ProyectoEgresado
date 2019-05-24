using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace pureba2register.Models
{
    public class TipoReferencia
    {
        [Key]
        public int TipoReferenciaID { get; set; }

        [Display(Name = "Tipo de referencia")]
        [Required(ErrorMessage = " El campo no puede ir vacío")]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "La propiedad {0} debe tener {1} caracteres como máximo y {2} como mínimo")]
        public String NombreTipoReferencia { get; set; }

        public virtual ICollection<ReferenciasPersonales> ReferenciasPersonales { get; set; }
    }
}