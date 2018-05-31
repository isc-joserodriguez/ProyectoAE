using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoBase.Models;
using ProyectoBase.Models.FicGestionEventos;

namespace ProyectoBase.Pages.Menu.FicGestionEventos.CatTiposGenerales
{
    public class EditModel : PageModel
    {
        private readonly ProyectoBase.Models.ApplicationDbContext _context;

        public EditModel(ProyectoBase.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public cat_tipos_generales cat_tipos_generales { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            getActivo();

            cat_tipos_generales = await _context.cat_tipos_generales.SingleOrDefaultAsync(m => m.IdTipoGeneral == id);

            if (cat_tipos_generales == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(cat_tipos_generales).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!cat_tipos_generalesExists(cat_tipos_generales.IdTipoGeneral))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool cat_tipos_generalesExists(int id)
        {
            return _context.cat_tipos_generales.Any(e => e.IdTipoGeneral == id);
        }

        public List<SelectListItem> Activo = new List<SelectListItem>();
        public void getActivo()
        {
            //if(d.Activo.Equals("A"))
            Activo.Add(new SelectListItem
            {
                Text = "Activo",
                Value = "A"
            });
            Activo.Add(new SelectListItem
            {
                Text = "Inactivo",
                Value = "I"
            });
        }
    }
}
