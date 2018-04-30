using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoAE.Models.GestionDeEventos
{
    public class Res_eventos_horarios
    {
        public int Id { get; set; }
        //public int IdHorario { get; set; }
        public DateTime FechaHoraInicio { get; set; }
        public DateTime FechaHoraFin { get; set; }
        public DateTime FechaHoraRegistro { get; set; }

    }
}
