using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoBase.Models.FicGestionEventos
{
    public class cat_prod_serv_especifico
    {
        [ForeignKey("IdProdServ"), Required(ErrorMessage = "Este campo es requerido")]
        public int IdProdServ { get; set; }
        public virtual cat_productos_servicios cat_productos_servicios { get; set; }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Required(ErrorMessage = "Este campo es requerido")]
        public int IdProdServEsp { get; set; }

        [MaxLength(20, ErrorMessage = "Este campo no puede contener más de 20 caracteres"), Required(ErrorMessage = "Este campo es requerido")]
        public string ClaveProdServEsp { get; set; }
        [MaxLength(200, ErrorMessage = "Este campo no puede contener más de 200 caracteres"), Required(ErrorMessage = "Este campo es requerido")]
        public string DesProdServEsp { get; set; }

    }
}