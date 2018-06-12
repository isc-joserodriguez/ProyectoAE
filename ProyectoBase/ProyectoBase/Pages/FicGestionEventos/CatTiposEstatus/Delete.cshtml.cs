using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProyectoBase.Models;
using ProyectoBase.Models.FicGestionEventos;

namespace ProyectoBase.Pages.FicGestionEventos.CatTiposEstatus
{
    public class DeleteModel : PageModel
    {
        private readonly ProyectoBase.Models.ApplicationDbContext _context;

        public DeleteModel(ProyectoBase.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public cat_tipos_estatus cat_tipos_estatus { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            cat_tipos_estatus = await _context.cat_tipos_estatus.SingleOrDefaultAsync(m => m.IdTipoEstatus == id);

            if (cat_tipos_estatus == null)
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

            cat_tipos_estatus = await _context.cat_tipos_estatus.FindAsync(id);

            if (cat_tipos_estatus != null)
            {
                _context.cat_tipos_estatus.Remove(cat_tipos_estatus);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }

        public String Activo(string letra)
        {
            if (letra == "S")
            {
                return "Activo";
            }
            if (letra == "N")
            {
                return "Inactivo";
            }
            return "Desconocido";
        }
    }
}
