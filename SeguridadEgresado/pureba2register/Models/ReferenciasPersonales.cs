using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace pureba2register.Models
{
    public class ReferenciasPersonales
    {
        [Key]
        public int ReferenciasPersonalesID { get; set; }


        [Display(Name = "Nombres")]
        [Required(ErrorMessage = " Este campo no puede ir vacío")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "La propiedad {0} debe tener {1} caracteres como máximo y {2} como mínimo")]
        public String NombresReferencia { get; set; }

        [Display(Name = "Primer apeliido")]
        [Required(ErrorMessage = " Este campo no puede ir vacío")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "La propiedad {0} debe tener {1} caracteres como máximo y {2} como mínimo")]
        public String PrimerApellidoReferencia { get; set; }

        [Display(Name = "Segundo apellido")]
        [Required(ErrorMessage = " Este campo no puede ir vacío")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "La propiedad {0} debe tener {1} caracteres como máximo y {2} como mínimo")]
        public String SegundoApellidoReferencia { get; set; }

        [Display(Name = "Cargo que ocupa")]
        [Required(ErrorMessage = " Este campo no puede ir vacío")]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "La propiedad {0} debe tener {1} caracteres como máximo y {2} como mínimo")]
        public String CargoReferencia { get; set; }

        [Display(Name = "Teléfono fijo ")]
        [Required(ErrorMessage = " El campo no puede ir vacío")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "* Solo se permiten números.")]
        [DataType(DataType.PhoneNumber)]
        public string TelefonoFijoReferencia { get; set; }

        [Display(Name = "Extención")]
        public String ExtTelefonoReferencia { get; set; }


        [Display(Name = "Teléfono móvil ")]
        [Required(ErrorMessage = " El campo no puede ir vacío")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "* Solo se permiten números.")]
        [DataType(DataType.PhoneNumber)]
        public string TelefonoMovilReferencia { get; set; }

        [Display(Name = "Usuario")]
        public int InformacionPersonalID { get; set; }
        public virtual InformacionPersonal InformacionPersonal { get; set; }

        [Display(Name = "Tipo de parentesco")]
        public int ParentescoReferenciaID { get; set; }
        public virtual ParentescoReferencia ParentescoReferencia { get; set; }

        [Display(Name = "Tipo de referencia ")]
        public int TipoReferenciaID { get; set; }
        public virtual TipoReferencia TipoReferencia { get; set; }
        [Display(Name = "Nombre de usuario")]
        public string UserName { get; set; }


        public List<ReferenciasPersonales> Obtener(string userName)
        {
            var referenciasPersonales = new List<ReferenciasPersonales>();
            try
            {
                using (var context = new pureba2registerContext())
                {
                    referenciasPersonales = context.ReferenciasPersonales
                    .Where(x => x.UserName == userName)
                    .ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);

            }

            return referenciasPersonales;


        }


    }
}