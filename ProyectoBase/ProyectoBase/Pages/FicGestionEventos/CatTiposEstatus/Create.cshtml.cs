using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProyectoBase.Models;
using ProyectoBase.Models.FicGestionEventos;

namespace ProyectoBase.Pages.FicGestionEventos.CatTiposEstatus
{
    public class CreateModel : PageModel
    {
        private readonly ProyectoBase.Models.ApplicationDbContext _context;

        public CreateModel(ProyectoBase.Models.ApplicationDbContext context)
        {
            _context = context;
            getActivo();
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public cat_tipos_estatus cat_tipos_estatus { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.cat_tipos_estatus.Add(cat_tipos_estatus);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

        public List<SelectListItem> Activo = new List<SelectListItem>();
        public void getActivo()
        {
            //if(d.Activo.Equals("A"))
            Activo.Add(new SelectListItem
            {
                Text = "Activo",
                Value = "S"
            });
            Activo.Add(new SelectListItem
            {
                Text = "Inactivo",
                Value = "N"
            });
        }
    }
}