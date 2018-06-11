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
        [Required(ErrorMessage = "Este campo es requerido")]
        public int IdReservaCliente { get; set; }
        
        [Required(ErrorMessage = "Este campo es requerido")]
        public int IdEvento { get; set; }
        
        [Required(ErrorMessage = "Este campo es requerido")]
        public int IdBoleto { get; set; }
        
        [Required(ErrorMessage = "Este campo es requerido")]
        public int IdPersona { get; set; }
        
        public string ConfirmaAsistencia { get; set; }
        [MaxLength(60, ErrorMessage = "Este campo no puede contener más de 60 caracteres"), Required(ErrorMessage = "Este campo es requerido")]
        public string Nombre { get; set; }

        public res_evento_clientes EventoClientes { get; set; }
        public  res_eventos Eventos { get; set; }
        public res_evento_zona_boletos EventoZonaBoleto { get; set; }
        public rh_cat_personas Personas { get; set; }
    }
}
