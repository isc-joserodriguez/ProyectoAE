using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProyectoBase.Models;
using ProyectoBase.Models.FicGestionEventos;

namespace ProyectoBase.Pages.FicGestionEventos.RhCatPersonas
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
            getSexo();
            getTipoPersona();
            return Page();
        }

        [BindProperty]
        public rh_cat_personas rh_cat_personas { get; set; }

        

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.rh_cat_personas.Add(rh_cat_personas);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
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

        public List<SelectListItem> TipoPersona = new List<SelectListItem>();
        public void getTipoPersona()
        {
            //if(d.Activo.Equals("A"))
            TipoPersona.Add(new SelectListItem
            {
                Text = "Fisica",
                Value = "F"
            });
            TipoPersona.Add(new SelectListItem
            {
                Text = "Moral",
                Value = "M"
            });
        }
    }
}