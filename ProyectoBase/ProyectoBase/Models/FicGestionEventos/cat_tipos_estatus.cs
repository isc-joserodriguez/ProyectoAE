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
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Required(ErrorMessage = "Este campo es requerido")]
        public int IdTipoEstatus { get; set; }

        [MaxLength(30, ErrorMessage = "Este campo no puede contener más de 30 caracteres"), Required(ErrorMessage = "Este campo es requerido")]
        public string DesTipoEstatus { get; set; }
        [MaxLength(1, ErrorMessage = "Este campo no puede contener más de 1 caracter"), Required(ErrorMessage = "Este campo es requerido")]
        public string Activo { get; set; }
    }
}