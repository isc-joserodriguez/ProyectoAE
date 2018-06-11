using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoBase.Models.FicGestionEventos
{
    public class cat_productos_servicios
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Required(ErrorMessage = "Este campo es requerido")]
        public int IdProdServ { get; set; }
        [MaxLength(20, ErrorMessage = "Este campo no puede contener más de 20 caracteres"), Required(ErrorMessage = "Este campo es requerido")]
        public string ClaveProdServ { get; set; }
        [MaxLength(50, ErrorMessage = "Este campo no puede contener más de 50 caracteres"), Required(ErrorMessage = "Este campo es requerido")]
        public string CodigoBarras { get; set; }
        [MaxLength(200, ErrorMessage = "Este campo no puede contener más de 200 caracteres"), Required(ErrorMessage = "Este campo es requerido")]
        public string DesProdServ { get; set; }
        [MaxLength(1, ErrorMessage = "Este campo no puede contener más de 1 caracteres"), Required(ErrorMessage = "Este campo es requerido")]
        public string ProductoServicio { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        public int IdTipoGenProdServ { get; set; }
        
        [ Required(ErrorMessage = "Este campo es requerido")]
        public int IdGenProdServ { get; set; }
        
        public List<cat_prod_serv_especifico> ProductoServicioEspecifico { get; set; }
        public cat_tipos_generales TiposGenerales { get; set; }
        public cat_generales Generales { get; set; }
        public List<res_evento_cliente_prod_serv> EventoClienteProdServ { get; set; }
        public List<res_evento_servicios> EventoServicios { get; set; }
        public List<res_zonas_servicios> ZonasServicios { get; set; }
    }
}