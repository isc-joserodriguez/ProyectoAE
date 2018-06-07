using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoBase.Models.FicGestionEventos
{
    public class rh_cat_personas
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Required(ErrorMessage = "Este campo es requerido")]
        public int IdPersona { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        public int IdInstituto { get; set; }
        [RegularExpression("^[0-9]*$", ErrorMessage = "Solo se aceptan números"),MaxLength(20, ErrorMessage = "Este campo no puede contener más de 20 caracteres"), Required(ErrorMessage = "Este campo es requerido")]
        public string NumControl { get; set; }
        [MaxLength(100, ErrorMessage = "Este campo no puede contener más de 100 caracteres"), Required(ErrorMessage = "Este campo es requerido")]
        public string Nombre { get; set; }
        [MaxLength(60, ErrorMessage = "Este campo no puede contener más de 60 caracteres")]
        public string ApPaterno { get; set; }
        [MaxLength(60, ErrorMessage = "Este campo no puede contener más de 60 caracteres")]
        public string ApMaterno { get; set; }
        [MaxLength(10, ErrorMessage = "Este campo no puede contener más de 10 caracteres")]
        public string RFC { get; set; }
        [MaxLength(25, ErrorMessage = "Este campo no puede contener más de 25 caracteres"), Required(ErrorMessage = "Este campo es requerido")]
        public string CURP { get; set; }
        [MaxLength(1, ErrorMessage = "Este campo no puede contener más de 1 caracter"), Required(ErrorMessage = "Este campo es requerido")]
        public string TipoPersona { get; set; }
        [MaxLength(1, ErrorMessage = "Este campo no puede contener más de 1 caracter"), Required(ErrorMessage = "Este campo es requerido")]
        public string Sexo { get; set; }
        [MaxLength(255, ErrorMessage = "Este campo no puede contener más de 255 caracteres")]
        public string RutaFoto { get; set; }
        [MaxLength(20, ErrorMessage = "Este campo no puede contener más de 20 caracteres")]
        public string Alias { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        public DateTime FechaNac { get; set; }
    }
}