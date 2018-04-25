using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoAE.Models.GestionDeEventos
{
    public class Edificio
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string DetalleUbicacion { get; set; }
        public int Capacidad { get; set; }
        public char Disponibilidad { get; set; }
        public string Observaciones { get; set; }
        public float CoorX { get; set; }
        public float CoorY { get; set; }
    }
}
