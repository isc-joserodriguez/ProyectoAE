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

namespace ProyectoBase.Pages.FicGestionEventos.CatalogoGenerales
{
    public class EditModel : PageModel
    {
        private readonly ProyectoBase.Models.ApplicationDbContext _context;

        public EditModel(ProyectoBase.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public cat_generales cat_generales { get; set; }

        public List<SelectListItem> TiposGenerales = new List<SelectListItem>();

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            getActivo();
            getTiposGenerales();

            cat_generales = await _context.cat_generales.SingleOrDefaultAsync(m => m.IdGeneral == id);

            if (cat_generales == null)
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

            _context.Attach(cat_generales).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!cat_generalesExists(cat_generales.IdGeneral))
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

        private bool cat_generalesExists(int id)
        {
            return _context.cat_generales.Any(e => e.IdGeneral == id);
        }

        public void getTiposGenerales()
        {
            var Tipos = _context.cat_tipos_generales;
            foreach (cat_tipos_generales d in Tipos)
            {
                if(d.Activo.Equals("S"))
                TiposGenerales.Add(new SelectListItem
                {
                    Text = d.DesTipo,
                    Value = d.IdTipoGeneral.ToString()
                });
            }
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
