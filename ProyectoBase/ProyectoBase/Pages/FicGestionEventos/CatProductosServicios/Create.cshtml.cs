using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProyectoBase.Models;
using ProyectoBase.Models.FicGestionEventos;

namespace ProyectoBase.Pages.FicGestionEventos.CatProductoServicios
{
    public class CreateModel : PageModel
    {
        private readonly ProyectoBase.Models.ApplicationDbContext _context;

        public CreateModel(ProyectoBase.Models.ApplicationDbContext context)
        {
            _context = context;
            getProductosServicios();
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public cat_productos_servicios cat_productos_servicios { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.cat_productos_servicios.Add(cat_productos_servicios);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

        public List<SelectListItem> ProductoServicio = new List<SelectListItem>();
        public void getProductosServicios()
        {
            var Tipos = _context.cat_generales;
            ProductoServicio.Add(new SelectListItem
            {
                Text = "Producto",
                Value = "P"
            });
            ProductoServicio.Add(new SelectListItem
            {
                Text = "Servicio",
                Value = "S"
            });
        }
    }
}