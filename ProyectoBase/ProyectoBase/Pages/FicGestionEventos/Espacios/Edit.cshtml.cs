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

namespace ProyectoBase.Pages.FicGestionEventos.Espacios
{
    public class EditModel : PageModel
    {
        private readonly ProyectoBase.Models.ApplicationDbContext _context;

        public EditModel(ProyectoBase.Models.ApplicationDbContext context)
        {
            _context = context;
            getEdificios();
        }

        [BindProperty]
        public eva_cat_espacios eva_cat_espacios { get; set; }
        public int IdEdificio { get; set; }


        public List<SelectListItem> Edificios = new List<SelectListItem>();

        public async Task<IActionResult> OnGetAsync(int? id, int edificio)
        {
            if (id == null)
            {
                return NotFound();
            }

            eva_cat_espacios = await _context.eva_cat_espacios.SingleOrDefaultAsync(m => m.IdEspacio == id);

            if (eva_cat_espacios == null)
            {
                return NotFound();
            }
            IdEdificio = edificio;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(eva_cat_espacios).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!eva_cat_espaciosExists(eva_cat_espacios.IdEspacio))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index", new { id= eva_cat_espacios.IdEdificio });
        }

        private bool eva_cat_espaciosExists(int id)
        {
            return _context.eva_cat_espacios.Any(e => e.IdEspacio == id);
        }

        public void getEdificios()
        {
            var Tipos = _context.eva_cat_edificios;
            foreach (eva_cat_edificios d in Tipos)
            {
                Edificios.Add(new SelectListItem
                {
                    Text = d.Clave,
                    Value = d.IdEdificio.ToString()
                });
            }
        }

        public String Edificio(string ID)
        {
            var Tipos = _context.eva_cat_edificios;
            foreach (eva_cat_edificios d in Tipos)
            {
                if (ID == d.IdEdificio.ToString())
                {
                    return d.Clave;
                }
            }
            return "Desconocido";
        }
    }
}
