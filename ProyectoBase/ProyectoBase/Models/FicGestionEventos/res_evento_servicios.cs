using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoBase.Models.FicGestionEventos
{
    public class res_evento_servicios
    {
        [Key, Required(ErrorMessage = "Este campo es requerido")]
        public int IdEvento { get; set; }
        
        [MaxLength(1, ErrorMessage = "Este campo no puede contener más de 1 caracter"), Required(ErrorMessage = "Este campo es requerido")]
        public string Requerido { get; set; }

        [Key, Required(ErrorMessage = "Este campo es requerido")]
        public int IdProdServ { get; set; }
        
        [Key, Required(ErrorMessage = "Este campo es requerido")]
        public int IdProdServEsp { get; set; }
        

        public res_eventos Eventos { get; set; }
        public cat_productos_servicios ProductosSErvicios { get; set; }
        public cat_prod_serv_especifico ProdServEspecifico { get; set; }
    }

    
}
