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
        [ForeignKey("IdEvento"), Required(ErrorMessage = "Este campo es requerido")]
        public int IdEvento { get; set; }
        public virtual res_eventos res_eventos { get; set; }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Required(ErrorMessage = "Este campo es requerido")]
        public int IdHorarioDes { get; set; }

        [ForeignKey("IdEdificio"), Required(ErrorMessage = "Este campo es requerido")]
        public int IdEdificio { get; set; }
        public virtual eva_cat_edificios eva_cat_edificios { get; set; }

        [ForeignKey("IdEspacio"), Required(ErrorMessage = "Este campo es requerido")]
        public int IdEspacio { get; set; }
        public virtual eva_cat_espacios eva_cat_espacios { get; set; }

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

    }
}
