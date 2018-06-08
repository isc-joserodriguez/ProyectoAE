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
        [ForeignKey("IdReservaCliente"), Required(ErrorMessage = "Este campo es requerido")]
        public int IdReservaCliente { get; set; }
        public virtual res_evento_clientes res_evento_clientes { get; set; }

        [ForeignKey("IdEvento"), Required(ErrorMessage = "Este campo es requerido")]
        public int IdEvento { get; set; }
        public virtual res_eventos res_eventos { get; set; }

        [ForeignKey("IdBoleto"), Required(ErrorMessage = "Este campo es requerido")]
        public int IdBoleto { get; set; }
        public virtual res_evento_zona_boletos res_evento_zona_boletos { get; set; }

        [ForeignKey("IdPersona"), Required(ErrorMessage = "Este campo es requerido")]
        public int IdPersona { get; set; }
        public virtual rh_cat_personas rh_cat_personas { get; set; }

        public string ConfirmaAsistencia { get; set; }
        [MaxLength(60, ErrorMessage = "Este campo no puede contener más de 60 caracteres"), Required(ErrorMessage = "Este campo es requerido")]
        public string Nombre { get; set; }
    }
}
