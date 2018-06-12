using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoBase.Models.FicGestionEventos
{
    public class cat_productos_servicios
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Required(ErrorMessage = "Este campo es requerido")]
        public int IdProdServ { get; set; }
        [MaxLength(20, ErrorMessage = "Este campo no puede contener más de 20 caracteres"), Required(ErrorMessage = "Este campo es requerido")]
        public string ClaveProdServ { get; set; }
        [MaxLength(50, ErrorMessage = "Este campo no puede contener más de 50 caracteres"), Required(ErrorMessage = "Este campo es requerido")]
        public string CodigoBarras { get; set; }
        [MaxLength(200, ErrorMessage = "Este campo no puede contener más de 200 caracteres"), Required(ErrorMessage = "Este campo es requerido")]
        public string DesProdServ { get; set; }
        [MaxLength(1, ErrorMessage = "Este campo no puede contener más de 1 caracteres"), Required(ErrorMessage = "Este campo es requerido")]
        public string ProductoServicio { get; set; }

        [ForeignKey("IdTipoGenProdServ"), Required(ErrorMessage = "Este campo es requerido")]
        public int IdTipoGenProdServ { get; set; }
        public virtual cat_tipos_generales cat_tipos_generales { get; set; }

        [ForeignKey("IdGenProdServ"), Required(ErrorMessage = "Este campo es requerido")]
        public int IdGenProdServ { get; set; }
        public virtual cat_generales cat_generales { get; set; }



    }
}