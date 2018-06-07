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
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Required]
        public int IdEdificio { get; set; }

        [MaxLength(20), Required]
        public string Clave { get; set; }
        [MaxLength(10), Required]
        public string Alias { get; set; }
        [MaxLength(50), Required]
        public string DesEdificio { get; set; }
        
        public int Prioridad { get; set; }
    }
}