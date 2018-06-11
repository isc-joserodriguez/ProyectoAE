using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoBase.Models.FicGestionEventos
{
    public class cat_estatus
    {
        [Required(ErrorMessage = "Este campo es requerido")]
        public int IdTipoEstatus { get; set; }
        
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity), Required(ErrorMessage = "Este campo es requerido")]
        public int IdEstatus { get; set; }

        [MaxLength(50, ErrorMessage = "Este campo no puede contener más de 50 caracteres"), Required(ErrorMessage = "Este campo es requerido")]
        public string Clave { get; set; }
        [MaxLength(30, ErrorMessage = "Este campo no puede contener más de 30 caracteres"), Required(ErrorMessage = "Este campo es requerido")]
        public string DesEstatus { get; set; }
        [Required(ErrorMessage = "Este campo es requerido"), MaxLength(1, ErrorMessage = "Este campo no puede contener más de 1 caracteres")]
        public string Activo { get; set; }

        public cat_tipos_estatus TiposEstatus { get; set; }
        public List<res_evento_estatus> EventoEstatus { get; set; }
        public List<res_evento_zona_boleto_estatus> EventoZonaBoletoEstatus { get; set; }
    }
}
