using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoBase.Models.FicGestionEventos
{
    public class res_evento_estatus
    {
        [Required(ErrorMessage = "Este campo es requerido")]
        public int IdEvento { get; set; }
        
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Required(ErrorMessage = "Este campo es requerido")]
        public int IdEstatusDet { get; set; }

        public DateTime FechaEstatus { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        public int IdTipoEstatus { get; set; }
        
        [Required(ErrorMessage = "Este campo es requerido")]
        public int IdEstatus { get; set; }
        
        [MaxLength(1, ErrorMessage = "Este campo no puede contener más de 1 caracter"), Required(ErrorMessage = "Este campo es requerido")]
        public string Actual { get; set; }
        [MaxLength(500, ErrorMessage = "Este campo no puede contener más de 500 caracteres")]
        public string Observacion { get; set; }
        [MaxLength(50, ErrorMessage = "Este campo no puede contener más de 50 caracteres"), Required(ErrorMessage = "Este campo es requerido")]
        public string UsuarioReg { get; set; }

        public res_eventos Eventos { get; set; }
        public cat_tipos_estatus TiposEstatus { get; set; }
        public cat_estatus Estatus { get; set; }
    }
}
