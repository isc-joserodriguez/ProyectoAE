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
        [ForeignKey("IdEvento"), Required]
        public int IdEvento { get; set; }
        public virtual res_eventos res_eventos { get; set; }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Required]
        public int IdReservaCliente { get; set; }
        [Required]
        public int IdClienteReserva { get; set; }
        [Required]
        public DateTime FechaRegistro { get; set; }
    }
}