using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoBase.Models.FicGestionEventos
{
    public class res_evento_zona_boletos
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity), Required(ErrorMessage = "Este campo es requerido")]
        public int IdBoleto { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        public int IdEvento { get; set; }
        
        [Required(ErrorMessage = "Este campo es requerido")]
        public int IdEdificio { get; set; }
        
        [Required(ErrorMessage = "Este campo es requerido")]
        public int IdEspacio { get; set; }
        
        [Required(ErrorMessage = "Este campo es requerido")]
        public int IdZona { get; set; }
        
        [MaxLength(20, ErrorMessage = "Este campo no puede contener más de 20 caracteres"), Required(ErrorMessage = "Este campo es requerido")]
        public string NumBoleto { get; set; }
        [MaxLength(20, ErrorMessage = "Este campo no puede contener más de 20 caracteres"), Required(ErrorMessage = "Este campo es requerido")]
        public string DesBoleto { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        public float Precio { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        public float IVA { get; set; }
        [MaxLength(50, ErrorMessage = "Este campo no puede contener más de 50 caracteres"), Required(ErrorMessage = "Este campo es requerido")]
        public string Ubicacion { get; set; }

        public List<res_evento_cliente_boletos> EventoClientesBoletos { get; set; }
        public List<res_evento_zona_boleto_estatus> EventoZonaBoletoEstatus { get; set; }
        public res_eventos Eventos { get; set; }
        public eva_cat_edificios Edificios { get; set; }
        public eva_cat_espacios Espacios { get; set; }
        public res_cat_zonas Zonas { get; set; }
    }
}