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
        [Required(ErrorMessage = "Este campo es requerido")]
        public int IdEvento { get; set; }
        
        [Required(ErrorMessage = "Este campo es requerido")]
        public int IdReservaCliente { get; set; }
        
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Required(ErrorMessage = "Este campo es requerido")]
        public int IdReservaServDet { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        public int IdProdServ { get; set; }
        
        [Required(ErrorMessage = "Este campo es requerido")]
        public int IdProdServEsp { get; set; }
        
        public float Cantidad { get; set; }
        public float Precio { get; set; }
        public float IVA { get; set; }
        public int IdUnidadMedida { get; set; }
        public float Importe { get; set; }

        public res_eventos Eventos { get; set; }
        public res_evento_clientes EventoClientes { get; set; }
        public cat_productos_servicios ProductosServicios { get; set; }
        public cat_prod_serv_especifico ProductoServicioEspecifico { get; set; }
    }
}
