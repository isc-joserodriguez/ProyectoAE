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
        public int Id { get; set; }

        public string Clave { get; set; }
        public string DesGeneral { get; set; }
        public string Activo { get; set; }
    }
}