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
        [ForeignKey("IdProdServ"), Required]
        public int IdProdServ { get; set; }
        public virtual cat_productos_servicios cat_productos_servicios { get; set; }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Required]
        public int IdProdServEsp { get; set; }

        [MaxLength(20), Required]
        public string ClaveProdServEsp { get; set; }
        [MaxLength(200), Required]
        public string DesProdServEsp { get; set; }

    }
}