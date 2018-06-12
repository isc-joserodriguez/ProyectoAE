using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoBase.Models.FicGestionEventos
{
    public class res_cat_zonas
    {
        [ForeignKey("IdEdificio"), Required(ErrorMessage = "Este campo es requerido")]
        public int IdEdificio { get; set; }
        public virtual eva_cat_edificios eva_cat_edificios { get; set; }

        [ForeignKey("IdEspacio"), Required(ErrorMessage = "Este campo es requerido")]
        public int IdEspacio { get; set; }
        public virtual eva_cat_espacios eva_cat_espacios { get; set; }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Required(ErrorMessage = "Este campo es requerido")]
        public int IdZona { get; set; }

        [MaxLength(225, ErrorMessage = "Este campo no puede contener más de 225 caracteres"), Required(ErrorMessage = "Este campo es requerido")]
        public string DesZona { get; set; }
        public int CapacidadPer { get; set; }
        public int Filas { get; set; }
        public int AsientosPorFila { get; set; }
    }
}