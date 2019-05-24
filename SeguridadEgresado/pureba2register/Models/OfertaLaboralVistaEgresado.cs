using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace pureba2register.Models
{
    public class OfertaLaboralVistaEgresado
    {

        [Key]
        public int OfertaLVEgresadoID { get; set; }
        [DisplayName("Fecha de inicio")]
        [Required(ErrorMessage = " Este campo no puede ir vacío")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaInicio { get; set; }
        [DisplayName("Fecha de finalizacion")]
        [Required(ErrorMessage = " Este campo no puede ir vacío")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaFinal { get; set; }
        [DisplayName("Asunto")]
        public string Asunto { get; set; }
        [DisplayName("Perfil requerido")]
        public string PerfilRequerido { get; set; }
        [DisplayName("Descripción")]
        public string Descripcion { get; set; }
        [Display(Name = "UserName")]
        public string UserName { get; set; }
        [Display(Name = "Estado")]
        public string Estado { get; set; }



        public List<AgregarOferta> Obtener1(int agregarOfertaID)
        {
            var AgregarOferta = new List<AgregarOferta>();
            try
            {
                using (var context = new pureba2registerContext())
                {
                    AgregarOferta = context.AgregarOfertas
                        .Where(x => x.AgregarOfertaID == agregarOfertaID)
                        .ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);

            }

            return AgregarOferta;


        }

        public List<AgregarOferta> Obtener2(string userName)
        {
            var AgregarOferta = new List<AgregarOferta>();
            try
            {
                using (var context = new pureba2registerContext())
                {
                    AgregarOferta = context.AgregarOfertas
                        .Where(x => x.UserName == userName)
                        .ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);

            }

            return AgregarOferta;


        }
    }
}