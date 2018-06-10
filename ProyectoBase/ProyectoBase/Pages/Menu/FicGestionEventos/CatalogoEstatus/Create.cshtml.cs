using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProyectoBase.Models;
using ProyectoBase.Models.FicGestionEventos;

namespace ProyectoBase.Pages.Menu.FicGestionEventos.CatalogoEstatus
{
    public class CreateModel : PageModel
    {
        private readonly ProyectoBase.Models.ApplicationDbContext _context;

        public CreateModel(ProyectoBase.Models.ApplicationDbContext context)
        {
            _context = context;
            getTipoEstatus();
            getActivo();
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public cat_estatus cat_estatus { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.cat_estatus.Add(cat_estatus);
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

        public List<SelectListItem> TipoEstatus = new List<SelectListItem>();
        public void getTipoEstatus()
        {
            var Tipos = _context.cat_tipos_estatus;
            foreach (cat_tipos_estatus d in Tipos)
            {
                if(d.Activo.Equals("S"))
                TipoEstatus.Add(new SelectListItem
                {
                    Text = d.DesTipoEstatus,
                    Value = d.IdTipoEstatus.ToString()
                });
            }
        }
    }
}