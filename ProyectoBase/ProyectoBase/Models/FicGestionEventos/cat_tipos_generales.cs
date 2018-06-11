using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoBase.Models.FicGestionEventos
{
    public class cat_tipos_generales
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Required(ErrorMessage = "Este campo es requerido")]
        public int IdTipoGeneral { get; set; }

        [MaxLength(100, ErrorMessage = "Este campo no puede contener más de 100 caracteres"), Required(ErrorMessage = "Este campo es requerido")]
        public string DesTipo { get; set; }
        [MaxLength(1, ErrorMessage = "Este campo no puede contener más de 1 caracter"), Required(ErrorMessage = "Este campo es requerido")]
        public string Activo { get; set; }

        public List<cat_generales> Generales {get;set;}
        public List<cat_productos_servicios> ProductosServicios { get; set; }
        public List<res_eventos> Eventos { get; set; }
    }
}