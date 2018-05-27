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
    }
}
