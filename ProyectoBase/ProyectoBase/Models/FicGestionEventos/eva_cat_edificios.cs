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

        [MaxLength(20), Required(ErrorMessage = "Este campo es requerido")]
        public string Clave { get; set; }
        [MaxLength(10), Required(ErrorMessage = "Este campo es requerido")]
        public string Alias { get; set; }
        [MaxLength(50), Required(ErrorMessage = "Este campo es requerido")]
        public string DesEdificio { get; set; }
        
        public int Prioridad { get; set; }
    }
}