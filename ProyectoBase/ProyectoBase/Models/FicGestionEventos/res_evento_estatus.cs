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
        [ForeignKey("IdEvento")]
        public int IdEvento { get; set; }
        public virtual res_eventos res_eventos { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdEstatusDet { get; set; }

        public DateTime FechaEstatus { get; set; }

        [ForeignKey("IdTipoEstatus")]
        public int IdTipoEstatus { get; set; }
        public virtual cat_tipos_estatus cat_tipos_estatus { get; set; }

        [ForeignKey("IdEstatus")]
        public int IdEstatus { get; set; }
        public virtual cat_estatus cat_estatus { get; set; }

        public string Actual { get; set; }
        public string Observacion { get; set; }
        public string UsuarioReg { get; set; }



    }
}
