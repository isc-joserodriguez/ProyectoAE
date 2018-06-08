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
<<<<<<< HEAD
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdEventoServ { get; set; }

        [ForeignKey("IdEvento")]
=======
        [ForeignKey("IdEvento"), Key, Required(ErrorMessage = "Este campo es requerido")]
>>>>>>> 8e959b05e541a34fbeed99bf11184ad25419e79e
        public int IdEvento { get; set; }
        public virtual res_eventos res_eventos { get; set; }

        [MaxLength(1, ErrorMessage = "Este campo no puede contener más de 1 caracter"), Required(ErrorMessage = "Este campo es requerido")]
        public string Requerido { get; set; }

        [ForeignKey("IdProdServ"), Key, Required(ErrorMessage = "Este campo es requerido")]
        public int IdProdServ { get; set; }
        public virtual cat_productos_servicios cat_productos_servicios { get; set; }

        [ForeignKey("IdProdServEsp"), Key, Required(ErrorMessage = "Este campo es requerido")]
        public int IdProdServEsp { get; set; }
        public virtual cat_prod_serv_especifico cat_prod_serv_especifico { get; set; }

        

    }

    
}
