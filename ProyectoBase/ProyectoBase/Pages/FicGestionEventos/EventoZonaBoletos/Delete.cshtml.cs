using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProyectoBase.Models;
using ProyectoBase.Models.FicGestionEventos;

namespace ProyectoBase.Pages.FicGestionEventos.EventoZonaBoletos
{
    public class DeleteModel : PageModel
    {
        private readonly ProyectoBase.Models.ApplicationDbContext _context;

        public DeleteModel(ProyectoBase.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public res_evento_zona_boletos res_evento_zona_boletos { get; set; }
        public int IdEdificio { get; set; }
        public int IdEspacio { get; set; }
        public int IdEvento { get; set; }
        public int IdZona { get; set; }
        public int IdHorario { get; set; }

        public async Task<IActionResult> OnGetAsync(int id,int edificio, int espacio, int evento, int zona, int horario)
        {
            IdEdificio = edificio;
            IdEspacio = espacio;
            IdEvento = evento;
            IdZona = zona;
            IdHorario = horario;

            res_evento_zona_boletos = await _context.res_evento_zona_boletos.SingleOrDefaultAsync(m => m.IdBoleto == id);

            if (res_evento_zona_boletos == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id, int IdHorario_)
        {

            res_evento_zona_boletos = await _context.res_evento_zona_boletos.FindAsync(id);

            if (res_evento_zona_boletos != null)
            {
                _context.res_evento_zona_boletos.Remove(res_evento_zona_boletos);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index", new {edificio = res_evento_zona_boletos.IdEdificio,
                espacio = res_evento_zona_boletos.IdEspacio,
                evento = res_evento_zona_boletos.IdEvento,
                zona = res_evento_zona_boletos.IdZona,
                horario = IdHorario_
            });
        }
    }
}

