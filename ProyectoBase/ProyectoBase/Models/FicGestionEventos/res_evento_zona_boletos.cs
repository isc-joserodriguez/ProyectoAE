using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoBase.Models.FicGestionEventos
{
    public class res_evento_zona_boletos
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity), Required]
        public int IdBoleto { get; set; }

        [ForeignKey("IdEvento"), Required]
        public int IdEvento { get; set; }
        public virtual res_eventos res_eventos { get; set; }

        [ForeignKey("IdEdificio"), Required]
        public int IdEdificio { get; set; }
        public virtual eva_cat_edificios eva_cat_edificios { get; set; }

        [ForeignKey("IdEspacio"), Required]
        public int IdEspacio { get; set; }
        public virtual eva_cat_espacios eva_cat_espacios { get; set; }

        [ForeignKey("IdZona"), Required]
        public int IdZona { get; set; }
        public virtual res_cat_zonas res_cat_zonas { get; set; }
        [MaxLength(20), Required]
        public string NumBoleto { get; set; }
        [MaxLength(20), Required]
        public string DesBoleto { get; set; }
        [Required]
        public float Precio { get; set; }
        [Required]
        public float IVA { get; set; }
        [MaxLength(50), Required]
        public string Ubicacion { get; set; }





    }
}