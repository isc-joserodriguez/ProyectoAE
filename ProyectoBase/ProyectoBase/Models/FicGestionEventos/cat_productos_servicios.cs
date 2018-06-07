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
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Required]
        public int IdProdServ { get; set; }
        [MaxLength(20), Required]
        public string ClaveProdServ { get; set; }
        [MaxLength(50), Required]
        public string CodigoBarras { get; set; }
        [MaxLength(200), Required]
        public string DesProdServ { get; set; }
        [MaxLength(1), Required]
        public string ProductoServicio { get; set; }

        [ForeignKey("IdTipoGenProdServ"), Required]
        public int IdTipoGenProdServ { get; set; }
        public virtual cat_tipos_generales cat_tipos_generales { get; set; }

        [ForeignKey("IdGenProdServ"), Required]
        public int IdGenProdServ { get; set; }
        public virtual cat_generales cat_generales { get; set; }



    }
}