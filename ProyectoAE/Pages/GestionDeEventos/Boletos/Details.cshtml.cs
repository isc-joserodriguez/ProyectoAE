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
    public class DetailsModel : PageModel
    {
        private readonly ProyectoAE.Models.ApplicationDbContext _context;

        public DetailsModel(ProyectoAE.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        public Boleto Boleto { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Boleto = await _context.Boletos.SingleOrDefaultAsync(m => m.Id == id);

            if (Boleto == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
