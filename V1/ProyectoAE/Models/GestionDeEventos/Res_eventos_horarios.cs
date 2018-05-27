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
        public int IdEdificio { get; set; }
        public int IdEspacio { get; set; }
        public TimeSpan FechaHoraInicio { get; set; }
        public TimeSpan FechaHoraFin { get; set; }
        public string Fecha  { get; set; }
        public DateTime FechaHoraRegistro { get; set; }
        

    }
}
