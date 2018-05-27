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
        [ForeignKey("IdEdificio")]
        public int IdEdificio { get; set; }
        public virtual eva_cat_edificios eva_cat_edificios { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdEspacio { get; set; }

        public string Clave { get; set; }
        public string Alias { get; set; }
        public string DesEspacio { get; set; }
        public int Capacidad { get; set; }
        public int Prioridad { get; set; }

    }
}