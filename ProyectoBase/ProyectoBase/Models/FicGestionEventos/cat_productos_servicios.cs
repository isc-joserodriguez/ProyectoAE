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
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string ClaveProdServ { get; set; }
        public string CodigoBarras { get; set; }
        public string DesProdServ { get; set; }
        public string ProductoServicio { get; set; }

        [ForeignKey("IdTipoGenProdServ")]
        public int IdTipoGenProdServ { get; set; }
        public virtual cat_tipos_generales cat_tipos_generales { get; set; }

        [ForeignKey("IdGenProdServ")]
        public int IdGenProdServ { get; set; }
        public virtual cat_generales cat_generales { get; set; }



    }
}