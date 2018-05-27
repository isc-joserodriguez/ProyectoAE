using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProyectoAE.Models;
using ProyectoAE.Models.GestionDeEventos;

namespace ProyectoAE.Pages.GestionDeEventos.ResEvento
{
    public class CreateModel : PageModel
    {
        private readonly ProyectoAE.Models.ApplicationDbContext _context;

        public CreateModel(ProyectoAE.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Res_Eventos Res_Eventos { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.ResEvento.Add(Res_Eventos);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}