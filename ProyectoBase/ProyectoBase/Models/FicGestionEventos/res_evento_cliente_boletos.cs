using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoBase.Models.FicGestionEventos
{
    public class res_evento_cliente_boletos
    {
        [ForeignKey("IdReservaCliente"), Required]
        public int IdReservaCliente { get; set; }
        public virtual res_evento_clientes res_evento_clientes { get; set; }

        [ForeignKey("IdEvento"), Required]
        public int IdEvento { get; set; }
        public virtual res_eventos res_eventos { get; set; }

        [ForeignKey("IdBoleto"), Required]
        public int IdBoleto { get; set; }
        public virtual res_evento_zona_boletos res_evento_zona_boletos { get; set; }

        [ForeignKey("IdPersona"), Required]
        public int IdPersona { get; set; }
        public virtual rh_cat_personas rh_cat_personas { get; set; }

        public string ConfirmaAsistencia { get; set; }
        [MaxLength(60), Required]
        public string Nombre { get; set; }
    }
}
