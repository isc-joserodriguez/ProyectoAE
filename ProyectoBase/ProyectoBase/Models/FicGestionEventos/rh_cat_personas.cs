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
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPersona { get; set; }

        public int IdInstituto { get; set; }
        [MaxLength(20)]
        public string NumControl { get; set; }
        [MaxLength(100)]
        public string Nombre { get; set; }
        [MaxLength(60)]
        public string ApPaterno { get; set; }
        [MaxLength(60)]
        public string ApMaterno { get; set; }
        [MaxLength(10)]
        public string RFC { get; set; }
        [MaxLength(25)]
        public string CURP { get; set; }
        public string TipoPersona { get; set; }
        public string Sexo { get; set; }
        [MaxLength(255)]
        public string RutaFoto { get; set; }
        [MaxLength(20)]
        public string Alias { get; set; }
        public DateTime FechaNac { get; set; }
    }
}