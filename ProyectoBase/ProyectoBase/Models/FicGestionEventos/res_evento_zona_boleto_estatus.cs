using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoBase.Models.FicGestionEventos
{
    public class res_evento_zona_boleto_estatus
    {
        [ForeignKey("IdBoleto"), Required]
        public int IdBoleto { get; set; }
        public virtual res_evento_zona_boletos res_evento_zona_boletos { get; set; }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Required]
        public int IdEstatusDet { get; set; }

        [Required]
        public DateTime FechaEstatus { get; set; }

        [ForeignKey("IdTipoEstatus"), Required]
        public int IdTipoEstatus { get; set; }
        public virtual cat_tipos_estatus cat_tipos_estatus { get; set; }

        [ForeignKey("IdEstatus"), Required]
        public int IdEstatus { get; set; }
        public virtual cat_estatus cat_estatus { get; set; }

        [MaxLength(1), Required]
        public string Actual { get; set; }
        [MaxLength(500)]
        public string Observacion { get; set; }
        [MaxLength(50), Required]
        public string UsuarioReg { get; set; }

    }
}
