using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProyectoBase.Models;
using ProyectoBase.Models.FicGestionEventos;

namespace ProyectoBase.Pages.FicGestionEventos.EventoServicios
{
    public class IndexModel : PageModel
    {
        private readonly ProyectoBase.Models.ApplicationDbContext _context;

        public IndexModel(ProyectoBase.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<res_evento_servicios> res_evento_servicios { get;set; }
        public res_eventos res_eventos { get; set; }
        public int IdEvento { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            IdEvento = id;
            IQueryable<res_evento_servicios> Res_Evento_Servicios = from s in _context.res_evento_servicios
                                                                    select s;

            res_evento_servicios = await _context.res_evento_servicios.ToListAsync();
            res_eventos = await _context.res_eventos.SingleOrDefaultAsync(m => m.IdEvento == id);

            if (res_eventos == null)
            {
                return NotFound();
            }

            res_evento_servicios = await Res_Evento_Servicios.Where(m => m.IdEvento == IdEvento)
                .AsNoTracking()
                .ToListAsync();
            return Page();
        }

        public String TipoGenEvento(string ID)
        {
            var Tipos = _context.cat_tipos_generales;
            foreach (cat_tipos_generales d in Tipos)
            {
                if (ID == d.IdTipoGeneral.ToString())
                {
                    return d.DesTipo;
                }
            }
            return "Desconocido";
        }

        public String PersonaReg(string ID)
        {
            var Tipos = _context.rh_cat_personas;
            foreach (rh_cat_personas d in Tipos)
            {
                if (ID == d.IdPersona.ToString())
                {
                    return d.Nombre;
                }
            }
            return "Desconocido";
        }

        public String GenEvento(string ID)
        {
            var Tipos = _context.cat_generales;
            foreach (cat_generales d in Tipos)
            {
                if (ID == d.IdGeneral.ToString())
                {
                    return d.Clave;
                }
            }
            return "Desconocido";
        }

        public String Edificio(string ID)
        {
            var Tipos = _context.eva_cat_edificios;
            foreach (eva_cat_edificios d in Tipos)
            {
                if (ID == d.IdEdificio.ToString())
                {
                    return d.Clave;
                }
            }
            return "Desconocido";
        }

        public String getProductoServico(string ID)
        {
            var Tipos = _context.cat_productos_servicios;
            foreach (cat_productos_servicios d in Tipos)
            {
                if (ID == d.IdProdServ.ToString())
                {
                    return d.ClaveProdServ;
                }
            }
            return "Desconocido";
        }

        public String getProductoServicoEsp(string ID, string PS)
        {
            var Tipos = _context.cat_prod_serv_especifico;
            foreach (cat_prod_serv_especifico d in Tipos)
            {
                if (ID == d.IdProdServEsp.ToString() && PS == d.IdProdServ.ToString())
                {
                    return d.ClaveProdServEsp;
                }
            }
            return "Desconocido";
        }

        public String getRequerido(string ID)
        {
            if (ID.Equals("S")) return "SI";
            if (ID.Equals("N")) return "NO";
            return "Desconocido";
        }


    }
}
