using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoBase.Models.FicGestionEventos
{
    public class res_evento_zonas
    {
        [Key, Required(ErrorMessage = "Este campo es requerido")]
        public int IdEdificio { get; set; }
        
        [Key, Required(ErrorMessage = "Este campo es requerido")]
        public int IdEspacio { get; set; }
        
        [Key, Required(ErrorMessage = "Este campo es requerido")]   
        public int IdEvento { get; set; }
        
        [Key, Required(ErrorMessage = "Este campo es requerido")]
        public int IdZona { get; set; }
        
        [Required(ErrorMessage = "Este campo es requerido")]
        public DateTime FechaReg { get; set; }
        [MaxLength(20, ErrorMessage = "Este campo no puede contener más de 20 caracteres"), Required(ErrorMessage = "Este campo es requerido")]
        public string UsuarioReg { get; set; }
        [MaxLength(255, ErrorMessage = "Este campo no puede contener más de 255 caracteres"), Required(ErrorMessage = "Este campo es requerido")]
        public string RutaImagen { get; set; }

        public eva_cat_edificios Edificios { get; set; }
        public eva_cat_espacios Espacios { get; set; }
        public res_eventos Eventos { get; set; }
        public res_cat_zonas Zonas { get; set; }
    }
}
