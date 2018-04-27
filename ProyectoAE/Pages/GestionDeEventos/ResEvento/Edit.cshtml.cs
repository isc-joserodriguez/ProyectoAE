using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoAE.Models;
using ProyectoAE.Models.GestionDeEventos;

namespace ProyectoAE.Pages.GestionDeEventos.ResEvento
{
    public class EditModel : PageModel
    {
        private readonly ProyectoAE.Models.ApplicationDbContext _context;

        public EditModel(ProyectoAE.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Res_Eventos Res_Eventos { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Res_Eventos = await _context.ResEvento.SingleOrDefaultAsync(m => m.Id == id);

            if (Res_Eventos == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Res_Eventos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Res_EventosExists(Res_Eventos.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool Res_EventosExists(int id)
        {
            return _context.ResEvento.Any(e => e.Id == id);
        }
    }
}
