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
        public string NumControl { get; set; }
        public string Nombre { get; set; }
        public string ApPaterno { get; set; }
        public string ApMaterno { get; set; }
        public string RFC { get; set; }
        public string CURP { get; set; }
        public string TipoPersona { get; set; }
        public string Sexo { get; set; }
        public string RutaFoto { get; set; }
        public string Alias { get; set; }
        public DateTime FechaNac { get; set; }
    }
}