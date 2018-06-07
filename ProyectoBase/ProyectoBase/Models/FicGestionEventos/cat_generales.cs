using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoBase.Models.FicGestionEventos
{
    public class cat_generales
    {
        [ForeignKey("IdTipoGeneral"), Required]
        public int IdTipoGeneral { get; set; }
        public virtual cat_tipos_generales cat_tipos_generales { get; set; }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Required]
        public int IdGeneral { get; set; }

        [MaxLength(20), Required]
        public string Clave { get; set; }
        [MaxLength(100), Required]
        public string DesGeneral { get; set; }
        [Required, MaxLength(1)]
        public string Activo { get; set; }
    }
}