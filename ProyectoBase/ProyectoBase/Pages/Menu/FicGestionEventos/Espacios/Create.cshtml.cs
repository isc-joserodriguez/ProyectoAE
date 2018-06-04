using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProyectoBase.Models;
using ProyectoBase.Models.FicGestionEventos;

namespace ProyectoBase.Pages.Menu.FicGestionEventos.Espacios
{
    public class CreateModel : PageModel
    {
        private readonly ProyectoBase.Models.ApplicationDbContext _context;

        public CreateModel(ProyectoBase.Models.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet(int id)
        {
            IdEdificio = id;
            return Page();
        }

        [BindProperty]
        public eva_cat_espacios eva_cat_espacios { get; set; }
        public int IdEdificio { get; set; }

        public List<SelectListItem> Edificios = new List<SelectListItem>();

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.eva_cat_espacios.Add(eva_cat_espacios);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index", new { id = eva_cat_espacios.IdEdificio });
        }

        public String Edificio(string ID)
        {
            var Tipos = _context.eva_cat_edificios;
            foreach (eva_cat_edificios d in Tipos)
            {
                if (ID == d.IdEdificio.ToString())
                {
                    return d.DesEdificio;
                }
            }
            return "Desconocido";
        }
    }
}