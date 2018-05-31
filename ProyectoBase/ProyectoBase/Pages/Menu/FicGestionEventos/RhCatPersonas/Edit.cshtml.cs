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

namespace ProyectoBase.Pages.Menu.FicGestionEventos.RhCatPersonas
{
    public class EditModel : PageModel
    {
        private readonly ProyectoBase.Models.ApplicationDbContext _context;

        public EditModel(ProyectoBase.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public rh_cat_personas rh_cat_personas { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            getSexo();

            rh_cat_personas = await _context.rh_cat_personas.SingleOrDefaultAsync(m => m.IdPersona == id);

            if (rh_cat_personas == null)
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

            _context.Attach(rh_cat_personas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!rh_cat_personasExists(rh_cat_personas.IdPersona))
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

        private bool rh_cat_personasExists(int id)
        {
            return _context.rh_cat_personas.Any(e => e.IdPersona == id);
        }

        public List<SelectListItem> Sexo = new List<SelectListItem>();
        public void getSexo()
        {
            //if(d.Activo.Equals("A"))
            Sexo.Add(new SelectListItem
            {
                Text = "Masculino",
                Value = "M"
            });
            Sexo.Add(new SelectListItem
            {
                Text = "Femenino",
                Value = "F"
            });
        }
    }
}
