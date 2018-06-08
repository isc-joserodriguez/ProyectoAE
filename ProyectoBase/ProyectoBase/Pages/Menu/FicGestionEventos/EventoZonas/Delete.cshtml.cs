using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProyectoBase.Models;
using ProyectoBase.Models.FicGestionEventos;

namespace ProyectoBase.Pages.Menu.FicGestionEventos.EventoZonas
{
    public class DeleteModel : PageModel
    {
        private readonly ProyectoBase.Models.ApplicationDbContext _context;

        public DeleteModel(ProyectoBase.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public res_evento_zonas res_evento_zonas { get; set; }
        public int IdEdificio { get; set; }
        public int IdEspacio { get; set; }
        public int IdEvento { get; set; }
        public int IdHorario { get; set; }

        public async Task<IActionResult> OnGetAsync(int edificio, int espacio, int evento, int zona, int horario)
        {
            IdEdificio = edificio;
            IdEspacio = espacio;
            IdEvento = evento;
            IdHorario = horario;
            res_evento_zonas = await _context.res_evento_zonas.SingleOrDefaultAsync(m =>
            m.IdEdificio == edificio &&
            m.IdEspacio == espacio &&
            m.IdEvento == evento &&
            m.IdZona == zona);

            if (res_evento_zonas == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int edificio, int espacio, int evento, int zona, int IDhorario)
        {
            res_evento_zonas = await _context.res_evento_zonas.SingleOrDefaultAsync(m =>
            m.IdEdificio == edificio &&
            m.IdEspacio == espacio &&
            m.IdEvento == evento &&
            m.IdZona == zona);

            if (res_evento_zonas != null)
            {
                _context.res_evento_zonas.Remove(res_evento_zonas);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index", new {
                edificio = res_evento_zonas.IdEdificio,
                espacio = res_evento_zonas.IdEspacio,
                evento = res_evento_zonas.IdEvento,
                horario = IDhorario
            });
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
