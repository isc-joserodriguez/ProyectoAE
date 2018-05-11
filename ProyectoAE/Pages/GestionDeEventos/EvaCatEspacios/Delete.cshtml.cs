using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProyectoAE.Models;
using ProyectoAE.Models.GestionDeEventos;

namespace ProyectoAE.Pages.GestionDeEventos.EvaCatEspacios
{
    public class DeleteModel : PageModel
    {
        private readonly ProyectoAE.Models.ApplicationDbContext _context;

        public DeleteModel(ProyectoAE.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public eva_cat_espacios eva_cat_espacios { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            eva_cat_espacios = await _context.EvaCatEspacios.SingleOrDefaultAsync(m => m.Id == id);

            if (eva_cat_espacios == null)
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

            eva_cat_espacios = await _context.EvaCatEspacios.FindAsync(id);

            if (eva_cat_espacios != null)
            {
                _context.EvaCatEspacios.Remove(eva_cat_espacios);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
