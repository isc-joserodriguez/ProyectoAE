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
        [ForeignKey("IdEvento"), Required]
        public int IdEvento { get; set; }
        public virtual res_eventos res_eventos { get; set; }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Required]
        public int IdHorarioDes { get; set; }

        [ForeignKey("IdEdificio"), Required]
        public int IdEdificio { get; set; }
        public virtual eva_cat_edificios eva_cat_edificios { get; set; }

        [ForeignKey("IdEspacio"), Required]
        public int IdEspacio { get; set; }
        public virtual eva_cat_espacios eva_cat_espacios { get; set; }

        [MaxLength(10), Required]
        public string Dia { get; set; }
        [Required]
        public DateTime FechaHoraIni { get; set; }
        [Required]
        public DateTime FechaHoraFin { get; set; }
        [MaxLength(1), Required]
        public string Disponible { get; set; }
        [Required]
        public DateTime FechaReg { get; set; }
        [MaxLength(18), Required]
        public string UsuarioReg { get; set; }

    }
}
