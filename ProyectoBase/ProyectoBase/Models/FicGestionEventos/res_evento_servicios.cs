using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoBase.Models.FicGestionEventos
{
    public class res_evento_servicios
    {
        [ForeignKey("IdEvento")]
        public int IdEvento { get; set; }
        public virtual res_eventos res_eventos { get; set; }

        public Char Requerido { get; set; }

        [ForeignKey("IdProdServ")]
        public int IdProdServ { get; set; }
        public virtual cat_productos_servicios cat_productos_servicios { get; set; }

        [ForeignKey("IdProdServEsp")]
        public int IdProdServEsp { get; set; }
        public virtual cat_prod_serv_especifico cat_prod_serv_especifico { get; set; }

    }
}
