using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoBase.Models.FicGestionEventos
{
    public class cat_estatus
    {
        [ForeignKey("IdTipoEstatus"), Required]
        public int IdTipoEstatus { get; set; }
        public virtual cat_tipos_estatus cat_tipos_estatus { get; set; }
        
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity), Required]
        public int IdEstatus { get; set; }

        [MaxLength(50), Required]
        public string Clave { get; set; }
        [MaxLength(30), Required]
        public string DesEstatus { get; set; }
        [Required, MaxLength(1)]
        public string Activo { get; set; }
    }
}
