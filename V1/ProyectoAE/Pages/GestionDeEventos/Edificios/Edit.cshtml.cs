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

namespace ProyectoAE.Pages.GestionDeEventos.Edificios
{
    public class EditModel : PageModel
    {
        private readonly ProyectoAE.Models.ApplicationDbContext _context;

        public EditModel(ProyectoAE.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Edificio Edificio { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Edificio = await _context.Edificio.SingleOrDefaultAsync(m => m.Id == id);

            if (Edificio == null)
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

            _context.Attach(Edificio).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EdificioExists(Edificio.Id))
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

        private bool EdificioExists(int id)
        {
            return _context.Edificio.Any(e => e.Id == id);
        }
    }
}
