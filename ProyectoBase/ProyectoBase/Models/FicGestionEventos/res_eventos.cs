using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoBase.Models.FicGestionEventos
{
    public class res_eventos
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Required(ErrorMessage = "Este campo es requerido")]
        public int IdEvento { get; set; }


        [Required(ErrorMessage = "Este campo es requerido")]
        public int IdTipoGenEvento { get; set; }
        
        [Required(ErrorMessage = "Este campo es requerido")]
        public int IdGenEvento { get; set; }
        
        [Required(ErrorMessage = "Este campo es requerido")]
        public int IdPersonaReg { get; set; }
        
        [MaxLength(1000, ErrorMessage = "Este campo no puede contener más de 1000 caracteres"), Required(ErrorMessage = "Este campo es requerido")]
        public string NombreEvento { get; set; }
        [MaxLength(1000, ErrorMessage = "Este campo no puede contener más de 1000 caracteres")]
        public string Observacion { get; set; }
        [MaxLength(3000, ErrorMessage = "Este campo no puede contener más de 3000 caracteres")]
        public string Explicacion { get; set; }
        [MaxLength(1000, ErrorMessage = "Este campo no puede contener más de 1000 caracteres"), Required(ErrorMessage = "Este campo es requerido")]
        public string URL { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        public DateTime FechaIn { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        public DateTime FechaFin { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        public int IdEdificio { get; set; }
        
        [Required(ErrorMessage = "Este campo es requerido")]
        public DateTime FechaReg { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        public int UsuarioReg { get; set; }

        public List<res_evento_cliente_boletos> EventoClientesBoletos { get; set; }
        public List<res_evento_cliente_prod_serv> EventoClienteProdServ { get; set; }
        public List<res_evento_clientes> EventoClientes { get; set; }
        public List<res_evento_estatus> EventoEstatus { get; set; }
        public List<res_evento_horarios> EventoHorarios { get; set; }
        public List<res_evento_servicios> EventoServicios { get; set; }
        public List<res_evento_zona_boletos> EventoZonaBoletos { get; set; }
        public List<res_evento_zonas> EventoZonas { get; set; }

        public cat_tipos_generales TiposGenerales { get; set; }
        public cat_generales Generales { get; set; }
        public rh_cat_personas Personas { get; set; }
        public eva_cat_edificios Edificios { get; set; }
    }
}
