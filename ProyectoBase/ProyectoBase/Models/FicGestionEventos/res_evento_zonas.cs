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
        [ForeignKey("IdEdificio"), Key, Required]
        public int IdEdificio { get; set; }
        public virtual eva_cat_edificios eva_cat_edificios { get; set; }

        [ForeignKey("IdEspacio"), Key, Required]
        public int IdEspacio { get; set; }
        public virtual eva_cat_espacios eva_cat_espacios { get; set; }

        [ForeignKey("IdEvento"), Key, Required]
        public int IdEvento { get; set; }
        public virtual res_eventos res_eventos { get; set; }

        [ForeignKey("IdZona"), Key, Required]
        public int IdZona { get; set; }
        public virtual res_cat_zonas res_cat_zonas { get; set; }
        [Required]
        public DateTime FechaReg { get; set; }
        [MaxLength(20), Required]
        public string UsuarioReg { get; set; }
        [MaxLength(255), Required]
        public string RutaImagen { get; set; }
        
    }
}
