using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProyectoBase.Models;
using ProyectoBase.Models.FicGestionEventos;

namespace ProyectoBase.Pages.FicGestionEventos.EventoZonas
{
    public class IndexModel : PageModel
    {
        private readonly ProyectoBase.Models.ApplicationDbContext _context;

        public IndexModel(ProyectoBase.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<res_evento_zonas> res_evento_zonas { get;set; }
        public res_evento_horarios res_evento_horarios { get; set; }
        public int IdEdificio { get; set; }
        public int IdEspacio { get; set; }
        public int IdEvento { get; set; }
        public int IdHorario { get; set; }

        public async Task<IActionResult> OnGetAsync(int edificio, int espacio, int evento, int horario)
        {
            IdEdificio = edificio;
            IdEspacio = espacio;
            IdEvento = evento;
            IdHorario = horario;

            IQueryable<res_evento_zonas> Res_Evento_Zona= from s in _context.res_evento_zonas
                                                                select s;

            res_evento_zonas = await _context.res_evento_zonas.ToListAsync();
            res_evento_horarios = await _context.res_evento_horarios.SingleOrDefaultAsync(m => m.IdHorarioDet == horario);

            if (res_evento_horarios == null)
            {
                return NotFound();
            }

            res_evento_zonas = await Res_Evento_Zona.Where(m =>
            m.IdEvento == evento &&
            m.IdEdificio == edificio &&
            m.IdEspacio == espacio)
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

        public String Zona(string ID)
        {
            var Tipos = _context.res_cat_zonas;
            foreach (res_cat_zonas d in Tipos)
            {
                if (ID == d.IdZona.ToString())
                {
                    return d.DesZona;
                }
            }
            return "Desconocido";
        }
    }
}
