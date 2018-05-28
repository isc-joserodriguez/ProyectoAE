using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoBase.Models.FicGestionEventos
{
    public class res_evento_cliente_prod_serv
    {
        [ForeignKey("IdEvento")]
        public int IdEvento { get; set; }
        public virtual res_eventos res_eventos { get; set; }

        [ForeignKey("IdReservaCliente")]
        public int IdReservaCliente { get; set; }
        public virtual res_evento_clientes res_evento_clientes { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("IdProdServ")]
        public int IdProdServ { get; set; }
        public virtual cat_productos_servicios cat_productos_servicios { get; set; }

        [ForeignKey("IdProdServEsp")]
        public int IdProdServEsp { get; set; }
        public virtual cat_prod_serv_especifico cat_prod_serv_especifico { get; set; }

        public float Cantidad { get; set; }
        public float Precio { get; set; }
        public float IVA { get; set; }
        public int IdUnidadMedida { get; set; }
        public float Importe { get; set; }


    }
}
