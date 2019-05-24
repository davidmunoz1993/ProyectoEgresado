using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace pureba2register.Models
{
    public class InformacionProfesional
    {
        [Key]
        public int InformacionProfesionalID { get; set; }

        [Display(Name = "Estudia actualmente?")]
        [Required(ErrorMessage = " El campo no puede ir vacío")]
        public String EstudiaActualmente { get; set; }

        [Display(Name = "Fecha de terminación")]
        [Required(ErrorMessage = " El campo no puede ir vacío")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaTerminacionProfesional { get; set; }

        [Display(Name = "Duración del estudio")]
        [Required(ErrorMessage = " El campo no puede ir vacío")]
        public String DuracionProfesional { get; set; }


        [Display(Name = "Usuario")]
        public int InformacionPersonalID { get; set; }
        public virtual InformacionPersonal InformacionPersonal { get; set; }

        [Display(Name = "Tipo de estudio")]
        public int TipoEstudioID { get; set; }
        public virtual TipoEstudio TipoEstudio { get; set; }

        [Display(Name = "Nombre carrera profesional")]
        public int CarreraProfesionalID { get; set; }
        public virtual CarreraProfesional CarreraProfesional { get; set; }


        [Display(Name = "Nombre de usuario")]
        public string UserName { get; set; }

        public List<InformacionProfesional> Obtener(string userName)
        {
            var informacionProfesionals = new List<InformacionProfesional>();
            try
            {
                using (var context = new pureba2registerContext())
                {
                    informacionProfesionals = context.InformacionProfesionals
                        .Where(x => x.UserName == userName)
                        .ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);

            }

            return informacionProfesionals;


        }


    }
}