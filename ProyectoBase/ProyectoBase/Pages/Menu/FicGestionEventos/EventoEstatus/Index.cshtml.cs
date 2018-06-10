using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProyectoBase.Models;
using ProyectoBase.Models.FicGestionEventos;

namespace ProyectoBase.Pages.Menu.FicGestionEventos.EventoEstatus
{
    public class IndexModel : PageModel
    {
        private readonly ProyectoBase.Models.ApplicationDbContext _context;

        public IndexModel(ProyectoBase.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<res_evento_estatus> res_evento_estatus { get;set; }
        public res_eventos res_eventos { get; set; }
        public int IdEvento { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            IQueryable<res_evento_estatus> eventos = from s in _context.res_evento_estatus
                                                     select s;

            res_evento_estatus = await _context
                .res_evento_estatus
                .ToListAsync();
            res_eventos = await _context
                .res_eventos
                .SingleOrDefaultAsync(m => m.IdEvento == id);
            if (res_eventos == null)
            {
                return NotFound();
            }
            IdEvento = res_eventos.IdEvento;
            res_evento_estatus = await eventos.Where(m => m.IdEvento == IdEvento)
                .AsNoTracking()
                .ToListAsync();
            return Page();
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

        public String Espacio(string ID)
        {
            var Tipos = _context.eva_cat_espacios;
            foreach (eva_cat_espacios d in Tipos)
            {
                if (ID == d.IdEspacio.ToString())
                {
                    return d.Clave;
                }
            }
            return "Desconocido";
        }

        public String Evento(string ID)
        {
            var Tipos = _context.res_eventos;
            foreach (res_eventos d in Tipos)
            {
                if (ID == d.IdEvento.ToString())
                {
                    return d.NombreEvento;
                }
            }
            return "Desconocido";
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

        public String getEstatus(String id)
        {
            if (id == "6") return "Activo";
            if (id == "7") return "InActivo";
            return "Desconocido";
        }

        public String getActual(String id)
        {
            if (id == "S") return "SI";
            if (id == "N") return "NO";
            return "Desconocido";
        }
    }
}
