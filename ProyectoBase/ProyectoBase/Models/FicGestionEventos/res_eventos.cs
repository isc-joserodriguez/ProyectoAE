using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoBase.Models.FicGestionEventos
{
    public class res_eventos
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdEvento { get; set; }


        [ForeignKey("IdTipoGenEvento")]
        public int IdTipoGenEvento { get; set; }
        public virtual cat_tipos_generales cat_tipos_generales { get; set; }

        [ForeignKey("IdGenEvento")]
        public int IdGenEvento { get; set; }
        public virtual cat_generales cat_generales { get; set; }

        [ForeignKey("IdPersonaReg")]
        public int IdPersonaReg { get; set; }
        public virtual rh_cat_personas rh_cat_personas { get; set; }

        public string NombreEvento { get; set; }
        public string Observacion { get; set; }
        public string Explicacion { get; set; }
        public string URL { get; set; }
        public DateTime FechaIn { get; set; }
        public DateTime FechaFin { get; set; }

        [ForeignKey("IdEdificio")]
        public int IdEdificio { get; set; }
        public virtual eva_cat_edificios eva_cat_edificios { get; set; }

        public DateTime FechaReg { get; set; }
        public int UsuarioReg { get; set; }

    }
}
