using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoBase.Models.FicGestionEventos
{
    public class res_evento_horarios
    {
        [Required(ErrorMessage = "Este campo es requerido")]
        public int IdEvento { get; set; }
        
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Required(ErrorMessage = "Este campo es requerido")]
        public int IdHorarioDet { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        public int IdEdificio { get; set; }
        
        [Required(ErrorMessage = "Este campo es requerido")]
        public int IdEspacio { get; set; }
        
        [MaxLength(10, ErrorMessage = "Este campo no puede contener más de 10 caracteres"), Required(ErrorMessage = "Este campo es requerido")]
        public string Dia { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        public DateTime FechaHoraIni { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        public DateTime FechaHoraFin { get; set; }
        [MaxLength(1, ErrorMessage = "Este campo no puede contener más de 1 caracter"), Required(ErrorMessage = "Este campo es requerido")]
        public string Disponible { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        public DateTime FechaReg { get; set; }
        [MaxLength(18, ErrorMessage = "Este campo no puede contener más de 18 caracter"), Required(ErrorMessage = "Este campo es requerido")]
        public string UsuarioReg { get; set; }

        public res_eventos Eventos { get; set; }
        public eva_cat_edificios Edificios { get; set; }
        public eva_cat_espacios Espacios { get; set; }
    }
}
