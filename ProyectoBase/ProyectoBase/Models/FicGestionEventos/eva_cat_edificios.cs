using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoBase.Models.FicGestionEventos
{
    public class eva_cat_edificios
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Required(ErrorMessage = "Este campo es requerido")]
        public int IdEdificio { get; set; }

        [MaxLength(20, ErrorMessage = "Este campo no puede contener más de 20 caracteres"), Required(ErrorMessage = "Este campo es requerido")]
        public string Clave { get; set; }
        [MaxLength(10, ErrorMessage = "Este campo no puede contener más de 10 caracteres"), Required(ErrorMessage = "Este campo es requerido")]
        public string Alias { get; set; }
        [MaxLength(50, ErrorMessage = "Este campo no puede contener más de 50 caracteres"), Required(ErrorMessage = "Este campo es requerido")]
        public string DesEdificio { get; set; }
        
        public int Prioridad { get; set; }

        public List<eva_cat_espacios> Espacios { get; set; }
        public List<res_cat_zonas> Zonas { get; set; }
        public List<res_evento_horarios> EventoHorarios { get; set; }
        public List<res_evento_zona_boletos> EventoZonaBoletos { get; set; }
        public List<res_zonas_servicios> ZonasServicios { get; set; }
        public List<res_evento_zonas> EventoZonas { get; set; }
        public List<res_eventos> Eventos { get; set; }
    }
}