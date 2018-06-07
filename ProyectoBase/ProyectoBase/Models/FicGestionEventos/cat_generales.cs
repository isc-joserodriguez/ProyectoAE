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
        [ForeignKey("IdTipoGeneral")]
        public int IdTipoGeneral { get; set; }
        public virtual cat_tipos_generales cat_tipos_generales { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdGeneral { get; set; }

        [MaxLength(20)]
        public string Clave { get; set; }
        [MaxLength(100)]
        public string DesGeneral { get; set; }
        public string Activo { get; set; }
    }
}