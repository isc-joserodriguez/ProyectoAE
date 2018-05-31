using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProyectoBase.Models;
using ProyectoBase.Models.FicGestionEventos;

namespace ProyectoBase.Pages.Menu.FicGestionEventos.CatalogoGenerales
{
    public class CreateModel : PageModel
    {
        private readonly ProyectoBase.Models.ApplicationDbContext _context;

        public CreateModel(ProyectoBase.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            getTiposGenerales();
            getActivo();
            return Page();
        }

        [BindProperty]
        public cat_generales cat_generales { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.cat_generales.Add(cat_generales);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

        public List<SelectListItem> TiposGenerales = new List<SelectListItem>();
        public void getTiposGenerales()
        {
            var Tipos = _context.cat_tipos_generales;
            foreach (cat_tipos_generales d in Tipos)
            {
                //if(d.Activo.Equals("A"))
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