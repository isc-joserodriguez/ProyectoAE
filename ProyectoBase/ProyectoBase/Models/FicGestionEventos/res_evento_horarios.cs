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
        [ForeignKey("IdEvento")]
        public int IdEvento { get; set; }
        public virtual res_eventos res_eventos { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdHorarioDet { get; set; }

        [ForeignKey("IdEdificio")]
        public int IdEdificio { get; set; }
        public virtual eva_cat_edificios eva_cat_edificios { get; set; }

        [ForeignKey("IdEspacio")]
        public int IdEspacio { get; set; }
        public virtual eva_cat_espacios eva_cat_espacios { get; set; }

        public string Dia { get; set; }
        public DateTime FechaHoraIni { get; set; }
        public DateTime FechaHoraFin { get; set; }
        public Char Disponible { get; set; }
        public DateTime FechaReg { get; set; }
        public Char UsuarioReg { get; set; }

    }
}
