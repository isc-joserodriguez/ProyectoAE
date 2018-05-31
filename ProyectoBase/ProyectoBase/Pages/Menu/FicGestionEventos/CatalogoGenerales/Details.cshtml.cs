using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProyectoBase.Models;
using ProyectoBase.Models.FicGestionEventos;

namespace ProyectoBase.Pages.Menu.FicGestionEventos.CatalogoGenerales
{
    public class DetailsModel : PageModel
    {
        private readonly ProyectoBase.Models.ApplicationDbContext _context;

        public DetailsModel(ProyectoBase.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        public cat_generales cat_generales { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            cat_generales = await _context.cat_generales.SingleOrDefaultAsync(m => m.IdGeneral == id);

            if (cat_generales == null)
            {
                return NotFound();
            }
            return Page();
        }

        public String Activo(string letra)
        {
            if (letra == "A")
            {
                return "Activo";
            }
            if (letra == "I")
            {
                return "Inactivo";
            }
            return "Desconocido";
        }
    }
}
