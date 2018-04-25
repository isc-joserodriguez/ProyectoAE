using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoAE.Models.GestionDeEventos
{
    public class Boleto
    {
        public int Id { get; set; }
        public int IdZona { get; set; }
        public int IdEvento { get; set; }
        public float Importe { get; set; }
        public float PrecioIva { get; set; }
    }
}
