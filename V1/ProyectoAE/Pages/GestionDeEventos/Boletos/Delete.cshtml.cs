using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProyectoAE.Models;
using ProyectoAE.Models.GestionDeEventos;

namespace ProyectoAE.Pages.GestionDeEventos.Boletos
{
    public class DeleteModel : PageModel
    {
        private readonly ProyectoAE.Models.ApplicationDbContext _context;

        public DeleteModel(ProyectoAE.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public res_evento_zona_boletos Boleto { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Boleto = await _context.res_evento_zona_boletos.SingleOrDefaultAsync(m => m.IdBoleto == id);

            if (Boleto == null)
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

            Boleto = await _context.res_evento_zona_boletos.FindAsync(id);

            if (Boleto != null)
            {
                _context.res_evento_zona_boletos.Remove(Boleto);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
