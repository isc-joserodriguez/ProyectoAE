using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProyectoAE.Models;
using ProyectoAE.Models.GestionDeEventos;

namespace ProyectoAE.Pages.GestionDeEventos.EvaCatEspacios
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
        public eva_cat_espacios eva_cat_espacios { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.EvaCatEspacios.Add(eva_cat_espacios);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}