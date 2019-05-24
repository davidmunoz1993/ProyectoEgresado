using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace pureba2register.Models
{
    public class UsuarioXOferta
    {
        [Key]
        public int UsuarioXOfertaID { get; set; }
        public string Usuario { get; set; }
        public int Oferta { get; set; }


        public List<UsuarioXOferta> Obtener1(int OfertaID)
        {
            var usuarioXOferta = new List<UsuarioXOferta>();
            try
            {
                using (var context = new pureba2registerContext())
                {
                    usuarioXOferta = context.UsuarioXOfertas
                        .Where(x => x.Oferta == OfertaID)
                        .ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);

            }

            return usuarioXOferta;


        }

        public List<UsuarioXOferta> Obtener2(string id)
        {
            var usuarioXOferta = new List<UsuarioXOferta>();
            try
            {
                using (var context = new pureba2registerContext())
                {
                    usuarioXOferta = context.UsuarioXOfertas
                        .Where(x => x.Usuario == id )
                        .ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);

            }

            return usuarioXOferta;


        }
    }
}