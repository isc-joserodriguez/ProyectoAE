using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoBase.Models.FicGestionEventos
{
    public class res_evento_cliente_boletos
    {
        public int Id { get; set; }

        [ForeignKey("IdReservaCliente")]
        public int IdReservaCliente { get; set; }
        public virtual res_evento_clientes res_evento_clientes { get; set; }

        [ForeignKey("IdEvento")]
        public int IdEvento { get; set; }
        public virtual res_eventos res_eventos { get; set; }

        [ForeignKey("IdBoleto")]
        public int IdBoleto { get; set; }
        public virtual res_evento_zona_boletos res_evento_zona_boletos { get; set; }

        [ForeignKey("IdPersona")]
        public int IdPersona { get; set; }
        public virtual rh_cat_personas rh_cat_personas { get; set; }
    }
}
