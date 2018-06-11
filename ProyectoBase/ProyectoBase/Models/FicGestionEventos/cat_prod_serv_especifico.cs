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
        [Required(ErrorMessage = "Este campo es requerido")]
        public int IdProdServ { get; set; }
        
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Required(ErrorMessage = "Este campo es requerido")]
        public int IdProdServEsp { get; set; }

        [MaxLength(20, ErrorMessage = "Este campo no puede contener más de 20 caracteres"), Required(ErrorMessage = "Este campo es requerido")]
        public string ClaveProdServEsp { get; set; }
        [MaxLength(200, ErrorMessage = "Este campo no puede contener más de 200 caracteres"), Required(ErrorMessage = "Este campo es requerido")]
        public string DesProdServEsp { get; set; }

        public cat_productos_servicios ProductosServicios { get; set; }
        public List<res_evento_cliente_prod_serv> EventoClienteProdServ { get; set; }
        public List<res_evento_servicios> EventoServicios { get; set; }
        public List<res_zonas_servicios> ZonasServicios { get; set; }
    }
}