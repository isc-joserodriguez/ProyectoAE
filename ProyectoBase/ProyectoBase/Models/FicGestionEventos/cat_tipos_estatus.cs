using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoBase.Models.FicGestionEventos
{
    public class cat_tipos_estatus
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Required]
        public int IdTipoEstatus { get; set; }

        [MaxLength(30), Required]
        public string DesTipoEstatus { get; set; }
        [MaxLength(1), Required]
        public string Activo { get; set; }
    }
}