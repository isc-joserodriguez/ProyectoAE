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
        [ForeignKey("IdEdificio"), Key, Required(ErrorMessage = "Este campo es requerido")]
        public int IdEdificio { get; set; }
        public virtual eva_cat_edificios eva_cat_edificios { get; set; }

        [ForeignKey("IdEspacio"), Key, Required(ErrorMessage = "Este campo es requerido")]
        public int IdEspacio { get; set; }
        public virtual eva_cat_espacios eva_cat_espacios { get; set; }

        [ForeignKey("IdEvento"), Key, Required(ErrorMessage = "Este campo es requerido")]   
        public int IdEvento { get; set; }
        public virtual res_eventos res_eventos { get; set; }

        [ForeignKey("IdZona"), Key, Required(ErrorMessage = "Este campo es requerido")]
        public int IdZona { get; set; }
        public virtual res_cat_zonas res_cat_zonas { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        public DateTime FechaReg { get; set; }
        [MaxLength(20, ErrorMessage = "Este campo no puede contener más de 20 caracteres"), Required(ErrorMessage = "Este campo es requerido")]
        public string UsuarioReg { get; set; }
        [MaxLength(255, ErrorMessage = "Este campo no puede contener más de 255 caracteres"), Required(ErrorMessage = "Este campo es requerido")]
        public string RutaImagen { get; set; }
        
    }
}
