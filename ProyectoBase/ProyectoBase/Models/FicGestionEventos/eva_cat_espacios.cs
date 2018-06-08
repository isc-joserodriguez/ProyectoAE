using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace ProyectoBase.Models.FicGestionEventos
{
    public class eva_cat_espacios
    {
        [ForeignKey("IdEdificio"), Required(ErrorMessage = "Este campo es requerido")]
        public int IdEdificio { get; set; }
        public virtual eva_cat_edificios eva_cat_edificios { get; set; }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Required(ErrorMessage = "Este campo es requerido")]
        public int IdEspacio { get; set; }


        [MaxLength(20, ErrorMessage = "Este campo no puede contener más de 20 caracteres"), Required(ErrorMessage = "Este campo es requerido")]
        public string Clave { get; set; }
        [MaxLength(10, ErrorMessage = "Este campo no puede contener más de 10 caracteres"), Required(ErrorMessage = "Este campo es requerido")]
        public string Alias { get; set; }
        [MaxLength(50, ErrorMessage = "Este campo no puede contener más de 50 caracteres"), Required(ErrorMessage = "Este campo es requerido")]
        public string DesEspacio { get; set; }
        public int Capacidad { get; set; }
        public int Prioridad { get; set; }

    }
}