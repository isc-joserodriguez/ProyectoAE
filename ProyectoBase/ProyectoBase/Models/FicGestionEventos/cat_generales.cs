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
        [Required(ErrorMessage = "Este campo es requerido")]
        public int IdTipoGeneral { get; set; }
        
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Required(ErrorMessage = "Este campo es requerido")]
        public int IdGeneral { get; set; }

        [MaxLength(20, ErrorMessage = "Este campo no puede contener más de 20 caracteres"), Required(ErrorMessage = "Este campo es requerido")]
        public string Clave { get; set; }
        [MaxLength(100, ErrorMessage = "Este campo no puede contener más de 100 caracteres"), Required(ErrorMessage = "Este campo es requerido")]
        public string DesGeneral { get; set; }
        [Required(ErrorMessage = "Este campo es requerido"), MaxLength(1, ErrorMessage = "Este campo no puede contener más de 1 caracter")]
        public string Activo { get; set; }

        public cat_tipos_generales TiposGenerales { get; set; }
        public List<cat_productos_servicios> ProductosServicios { get; set; }
        public List<res_eventos> Eventos { get; set; }
    }
}