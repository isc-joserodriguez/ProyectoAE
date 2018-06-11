using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoBase.Models.FicGestionEventos
{
    public class res_zonas_servicios
    {
        [Key, Required(ErrorMessage = "Este campo es requerido")]
        public int IdEdificio { get; set; }
        
        [Key, Required(ErrorMessage = "Este campo es requerido")]
        public int IdEspacio { get; set; }
        
        [Key, Required(ErrorMessage = "Este campo es requerido")]
        public int IdZona { get; set; }
        
        [Key, Required(ErrorMessage = "Este campo es requerido")]
        public int IdProdServ { get; set; }
        
        [Key, Required(ErrorMessage = "Este campo es requerido")]
        public int IdProdServEsp { get; set; }
        
        public eva_cat_edificios Edificios { get; set; }
        public eva_cat_espacios Espacios { get; set; }
        public res_cat_zonas Zonas { get; set; }
        public cat_productos_servicios ProductosServicios { get; set; }
        public cat_prod_serv_especifico ProdServEspecifico { get; set; }
    }

}
