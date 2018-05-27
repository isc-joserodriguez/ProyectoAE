using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProyectoAE.Models;
using ProyectoAE.Models.GestionDeEventos;

namespace ProyectoAE.Pages.GestionDeEventos.ResEventoHorario
{
    public class DetailsModel : PageModel
    {
        private readonly ProyectoAE.Models.ApplicationDbContext _context;

        public DetailsModel(ProyectoAE.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        public Res_eventos_horarios Res_eventos_horarios { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Res_eventos_horarios = await _context.ResEventoHorario.SingleOrDefaultAsync(m => m.Id == id);

            if (Res_eventos_horarios == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
