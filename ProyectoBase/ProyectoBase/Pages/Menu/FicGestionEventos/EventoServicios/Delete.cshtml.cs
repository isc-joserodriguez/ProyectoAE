using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProyectoBase.Models;
using ProyectoBase.Models.FicGestionEventos;

namespace ProyectoBase.Pages.Menu.FicGestionEventos.EventoServicios
{
    public class DeleteModel : PageModel
    {
        private readonly ProyectoBase.Models.ApplicationDbContext _context;

        public DeleteModel(ProyectoBase.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public res_evento_servicios res_evento_servicios { get; set; }
        public int IdEvento { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id, int evento)
        {
            if (id == null)
            {
                return NotFound();
            }
            IdEvento = evento;

            res_evento_servicios = await _context.res_evento_servicios.SingleOrDefaultAsync(m => m.IdEventoServ == id);

            if (res_evento_servicios == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            res_evento_servicios = await _context.res_evento_servicios.FindAsync(id);

            if (res_evento_servicios != null)
            {
                _context.res_evento_servicios.Remove(res_evento_servicios);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index", new { id= res_evento_servicios.IdEvento});
        }
    }
}
