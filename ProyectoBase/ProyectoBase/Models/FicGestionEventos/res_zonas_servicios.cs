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
        [ForeignKey("IdEdificio"), Key, Required(ErrorMessage = "Este campo es requerido")]
        public int IdEdificio { get; set; }
        public virtual eva_cat_edificios eva_cat_edificios { get; set; }

        [ForeignKey("IdEspacio"), Key, Required(ErrorMessage = "Este campo es requerido")]
        public int IdEspacio { get; set; }
        public virtual eva_cat_espacios eva_cat_espacios { get; set; }

        [ForeignKey("IdZona"), Key, Required(ErrorMessage = "Este campo es requerido")]
        public int IdZona { get; set; }
        public virtual res_cat_zonas res_cat_zonas { get; set; }

        [ForeignKey("IdProdServ"), Key, Required(ErrorMessage = "Este campo es requerido")]
        public int IdProdServ { get; set; }
        public virtual cat_productos_servicios cat_productos_servicios { get; set; }

        [ForeignKey("IdProdServEsp"), Key, Required(ErrorMessage = "Este campo es requerido")]
        public int IdProdServEsp { get; set; }
        public virtual cat_prod_serv_especifico cat_prod_serv_especifico { get; set; }
    }

}
