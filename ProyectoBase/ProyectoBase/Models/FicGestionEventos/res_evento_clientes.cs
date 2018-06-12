using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoBase.Models.FicGestionEventos
{
    public class res_evento_clientes
    {
        [ForeignKey("IdEvento"), Required(ErrorMessage = "Este campo es requerido")]
        public int IdEvento { get; set; }
        public virtual res_eventos res_eventos { get; set; }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Required(ErrorMessage = "Este campo es requerido")]
        public int IdReservaCliente { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        public int IdClienteReserva { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        public DateTime FechaRegistro { get; set; }
    }
}