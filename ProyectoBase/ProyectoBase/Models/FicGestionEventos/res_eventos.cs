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
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Required(ErrorMessage = "Este campo es requerido")]
        public int IdEvento { get; set; }


        [ForeignKey("IdTipoGenEvento"), Required(ErrorMessage = "Este campo es requerido")]
        public int IdTipoGenEvento { get; set; }
        public virtual cat_tipos_generales cat_tipos_generales { get; set; }

        [ForeignKey("IdGenEvento"), Required(ErrorMessage = "Este campo es requerido")]
        public int IdGenEvento { get; set; }
        public virtual cat_generales cat_generales { get; set; }

        [ForeignKey("IdPersonaReg"), Required(ErrorMessage = "Este campo es requerido")]
        public int IdPersonaReg { get; set; }
        public virtual rh_cat_personas rh_cat_personas { get; set; }

        [MaxLength(1000), Required(ErrorMessage = "Este campo es requerido")]
        public string NombreEvento { get; set; }
        [MaxLength(1000)]
        public string Observacion { get; set; }
        [MaxLength(3000)]
        public string Explicacion { get; set; }
        [MaxLength(1000), Required(ErrorMessage = "Este campo es requerido")]
        public string URL { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        public DateTime FechaIn { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        public DateTime FechaFin { get; set; }

        [ForeignKey("IdEdificio"), Required(ErrorMessage = "Este campo es requerido")]
        public int IdEdificio { get; set; }
        public virtual eva_cat_edificios eva_cat_edificios { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        public DateTime FechaReg { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        public int UsuarioReg { get; set; }

    }
}
