using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoAE.Models.GestionDeEventos
{
    public class Res_Eventos
    {
        public int Id { get; set; }
        //public int IdEvento { get; set; }
        public String Orador { get; set; }
        public String NombreEvento { get; set; }
        public String Observaciones { get; set; }
        public String Explicaciones { get; set; }
        public String Url { get; set; }
        public String FechaInicio { get; set; }
        public String FechaFin { get; set; }
    }
}
