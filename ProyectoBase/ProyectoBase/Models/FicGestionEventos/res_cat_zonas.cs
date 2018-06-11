using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoBase.Models.FicGestionEventos
{
    public class res_cat_zonas
    {
        public int IdEdificio { get; set; }

        public int IdEspacio { get; set; }
        
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Required(ErrorMessage = "Este campo es requerido")]
        public int IdZona { get; set; }

        [MaxLength(225, ErrorMessage = "Este campo no puede contener más de 225 caracteres"), Required(ErrorMessage = "Este campo es requerido")]
        public string DesZona { get; set; }
        public int CapacidadPer { get; set; }
        public int Filas { get; set; }
        public int AsientosPorFila { get; set; }

        public eva_cat_edificios Edificios { get; set; }
        public eva_cat_espacios Espacios { get; set; }
        public List<res_evento_zona_boletos> EventoZonaBoletos { get; set; }
        public List<res_zonas_servicios> ZonasServicios { get; set; }
        public List<res_evento_zonas> EventoZonas { get; set; }
    }
}