using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoAE.Models.GestionDeEventos
{
    public class res_evento_zona_boletos
    {
        public int IdBoleto { get; set; }
        public int IdEvento { get; set; }
        public int IdEdificio { get; set; }
        public int IdEspacio { get; set; }
        public int IdZona { get; set; }
        public String NumBoleto { get; set; }
        public String DesBoleto { get; set; }
        public float Iva { get; set; }
        public float Precio { get; set; }
    }
}
